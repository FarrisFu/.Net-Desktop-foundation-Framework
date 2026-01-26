using JCF.Module.Order.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JCF.Module.Order.ViewModels
{
    public class OrderViewModel : BindableBase
    {
        public OrderViewModel()
        {

        }
        private string _title = nameof(OrderView);
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
