using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Common
{
    public class MenuItem : BindableBase
    {
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        private string _ViewName;
        public string ViewName
        {
            get { return _ViewName; }
            set { SetProperty(ref _ViewName, value); }
        }

        private string _ModuleName;
        public string ModuleName
        {
            get { return _ModuleName; }
            set { SetProperty(ref _ModuleName, value); }
        }
    }
}
