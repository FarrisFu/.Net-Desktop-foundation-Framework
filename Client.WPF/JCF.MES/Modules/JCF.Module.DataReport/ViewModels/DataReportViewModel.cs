using JCF.Module.DataReport.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JCF.Module.DataReport.ViewModels
{
    public class DataReportViewModel : BindableBase
    {
        public DataReportViewModel()
        {

        }
        private string _title = nameof(DataReportView);
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
