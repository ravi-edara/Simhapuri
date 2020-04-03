using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimhapuriServices.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimhapuriServices.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeeDetailsPage : ContentPage
    {
        public FeeDetailsPage()
        {
            InitializeComponent();
            
            BindingContext = new FeeDetailsViewModel();
        }
    }
}