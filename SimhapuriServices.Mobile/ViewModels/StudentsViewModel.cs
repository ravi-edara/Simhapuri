using System;
using System.Collections.ObjectModel;
using SimhapuriServices.Mobile.Models;

namespace SimhapuriServices.Mobile.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        public StudentsViewModel()
        {
        }

        private ObservableCollection<Student> Students { get; set; }
    }
}
