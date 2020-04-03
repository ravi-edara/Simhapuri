using System;
using System.Collections.Generic;
using System.ComponentModel;
using SimhapuriServices.Mobile.ViewModels;
using Xamarin.Forms;

namespace SimhapuriServices.Mobile.Views
{
    [DesignTimeVisible(false)]
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();

            BindingContext = new StudentsViewModel();
        }
    }
}
