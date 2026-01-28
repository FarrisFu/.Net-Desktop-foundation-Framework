using JCF.Common;
using JCF.Common.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JCF.Module.TabHost.ViewModels
{
    public class TabHostViewModel : BindableBase
    {
       
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
        public TabHostViewModel(IRegionManager region,  IEventAggregator eventAggregator)
        {
           
            this.regionManager = region;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<OpenMenuEvent>().Subscribe(OpenMenu, ThreadOption.UIThread);
        }
        #region Action
        private void OpenMenu(MenuItem value)
        {
            regionManager.RequestNavigate("TabRegion", value.ViewName);
        }
        #endregion


        #region 通知属性      
        #endregion

        #region 命令
        

        private DelegateCommand<object> _CloseCommand;
        public DelegateCommand<object> CloseCommand =>
            _CloseCommand ?? (_CloseCommand = new DelegateCommand<object>(ExecuteCloseCommand));

        void ExecuteCloseCommand(object obj)
        {
            regionManager.Regions["TabRegion"].Remove(obj);
        }
        #endregion
    }

}
