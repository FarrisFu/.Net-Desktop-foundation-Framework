using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JCF.Common
{
    public class MenuGroup : BindableBase
    {
        public string GroupName { get; set; }
        public bool IsVisible { get; set; } = true;

        private List<MenuItem> _Items;
        public List<MenuItem> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }
    }
}
