using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using SimhapuriServices.Mobile.Models;
using Xamarin.Forms;

namespace SimhapuriServices.Mobile.ViewModels
{
    public class FeeDetailsViewModel : BaseViewModel
    {
        private Command<string> _searchCommand;
        public FeeDetailsViewModel()
        {
            Title = "Fee Details";
            FeeList = new ObservableCollection<DisplayObject>();
        }
        
        public FeeStructure FeeDetails { get; set; }

        public Command<string> SearchCommand => _searchCommand ?? new Command<string>(this.OnSearchCommand);
        
        public ObservableCollection<DisplayObject> FeeList { get; set; } 

        private async void OnSearchCommand(string obj)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://simhapuriservices.azurewebsites.net/fee/" + obj);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<FeeStructure>(responseString);
       
            // TODO: This SHIT has to be done because of a nasty bug in Collection View with grouping.
            FeeList.Clear();
            var feeDetails = GetDisplayObjects(result);
            //var studentDetails = GetDisplayObjects(result.student);

            //FeeList.Add(new DisplayObject("Student Details","adf"){IsHeader = true});
            //foreach (var studentDetail in studentDetails)
            //{
            //    FeeList.Add(studentDetail);
            //}
            
            FeeList.Add(new DisplayObject("Fee Details","adf"){IsHeader = true});
            foreach (var feeDetail in feeDetails)
            {
                FeeList.Add(feeDetail);
            }

            this.OnPropertyChanged(nameof(FeeList));
            FeeDetails = result;
        }

        private static IEnumerable<DisplayObject> GetDisplayObjects(object result)
        {
            return result
                .GetType()
                .GetProperties()
                .Where(e => e.GetCustomAttributes(typeof(DisplayAttribute), true).Any())
                .OrderBy(e =>
                {
                    var order = e.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault();

                    return ((DisplayAttribute) order)?.GetOrder() ?? 0;
                } )
                .Select(prop => new DisplayObject(((DisplayAttribute)prop.GetCustomAttributes(typeof(DisplayAttribute)).FirstOrDefault())?.Name, GetPropertyDisplayFormattedValue(result, prop.Name)))
                .ToList();
        }

        private static string GetPropertyDisplayFormattedValue(object value, string path)
        {
            var currentType = value.GetType();
            var currentDataFormatString = "{0}";

            foreach (var propertyName in path.Split('.'))
            {
                var property = currentType.GetProperty(propertyName);
                var currentDisplayFormatAttribute = (DisplayFormatAttribute)property.GetCustomAttributes(typeof(DisplayFormatAttribute), true).FirstOrDefault();
                if (currentDisplayFormatAttribute != null)
                {
                    currentDataFormatString = currentDisplayFormatAttribute.DataFormatString;
                }
                value = property.GetValue(value, null);
                currentType = property.PropertyType;
            }
            return string.Format(currentDataFormatString, value);
        }
    }
}