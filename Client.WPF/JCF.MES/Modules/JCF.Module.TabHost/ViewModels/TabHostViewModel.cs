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
        IModuleManager moduleManager;
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
        public TabHostViewModel(IRegionManager region, IModuleManager moduleManager, IEventAggregator eventAggregator)
        {
            this.moduleManager = moduleManager;
            this.regionManager = region;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<OpenMenuEvent>().Subscribe(OpenMenu, ThreadOption.UIThread);
        }
        #region Action
        private void OpenMenu(Menu value)
        {
            regionManager.RequestNavigate("TabRegion", value.ViewName);
        }
        #endregion


        #region 通知属性
        private List<Menu> _Menus = new List<Menu>()
        {
            new Menu(){ Title="首页", ViewName="HomePageView", ModuleName="HomePageModule"},
            new Menu(){ Title="数据统计页", ViewName="OrderView", ModuleName="OrderModule"},
            new Menu(){ Title="订单页", ViewName="DataReportView", ModuleName="DataReportModule"}
        };

        public List<Menu> Menus
        {
            get { return _Menus; }
            set { SetProperty(ref _Menus, value); }
        }
        #endregion

        #region 命令
        private DelegateCommand _LoadedCommand;
        public DelegateCommand LoadedCommand =>
            _LoadedCommand ?? (_LoadedCommand = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {
            foreach (var item in Menus)
            {
                moduleManager.LoadModule(item.ModuleName);
            }

            //foreach (var item in Menus)
            //{
            //    regionManager.RequestNavigate("TabRegion", item.ViewName);
            //}
        }

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
