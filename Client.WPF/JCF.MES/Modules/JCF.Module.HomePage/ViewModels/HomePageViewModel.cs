using JCF.Module.HomePage.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Module.HomePage.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
       

        public HomePageViewModel()
        {
            
        }

        private string _title = nameof(HomePageView);
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
