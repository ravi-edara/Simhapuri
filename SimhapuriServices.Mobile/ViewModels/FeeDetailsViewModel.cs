using System;
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
            
        }
        
        public FeeStructure FeeDetails { get; set; }

        public Command<string> SearchCommand => _searchCommand ?? new Command<string>(this.OnSearchCommand);
        
        public ObservableCollection<DisplayObject> FeeList { get; set; } = new ObservableCollection<DisplayObject>();

        private async void OnSearchCommand(string obj)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://simhapuriservices.azurewebsites.net/fee/" + obj);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<FeeStructure>(responseString);
            
            FeeList.Clear();
            foreach(var prop in result.GetType().GetProperties()) {
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(result, null));
                Console.WriteLine("{0}={1}", prop.Name,FollowPropertyPath(result, prop.Name));
                
                FeeList.Add(new DisplayObject(prop.Name, FollowPropertyPath(result, prop.Name)));
            }
            FeeDetails = result;
            
        }

        public static string FollowPropertyPath(object value, string path)
        {
            Type currentType = value.GetType();
            DisplayFormatAttribute currentDisplayFormatAttribute;
            string currentDataFormatString = "{0}";

            foreach (string propertyName in path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                currentDisplayFormatAttribute = (DisplayFormatAttribute)property.GetCustomAttributes(typeof(DisplayFormatAttribute), true).FirstOrDefault();
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