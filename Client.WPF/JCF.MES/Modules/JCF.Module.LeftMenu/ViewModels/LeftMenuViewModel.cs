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

namespace JCF.Module.LeftMenu.ViewModels
{
    public class LeftMenuViewModel : BindableBase
    {
        IEventAggregator eventAggregator;
        IModuleManager moduleManager;
        public LeftMenuViewModel(IEventAggregator eventAggregator, IModuleManager moduleManager)
        {
            Message = "菜单栏";
            //regionManager = region;
            this.eventAggregator = eventAggregator;
            this.moduleManager = moduleManager;

            //for (int i = 0; i < 100; i++)
            //{
            //    Menus.Add(new Menu { Title = "首页" + i, ViewName = "HomePageView", ModuleName = "HomePageModule" });
            //}

        }
        #region 通知属性

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private List<MenuGroup> _Menus = new List<MenuGroup>()
        {
            new MenuGroup(){ GroupName="首页", Items=new List<MenuItem>()
            {
                new MenuItem(){ Title="首页", ViewName="HomePageView", ModuleName="HomePageModule"},
            }
            },
            new MenuGroup(){ GroupName="订单管理", Items=new List<MenuItem>()
            {
                new MenuItem(){ Title="订单", ViewName="OrderView", ModuleName="OrderModule"},
            }
            },
            new MenuGroup(){ GroupName="数据报表", Items=new List<MenuItem>()
            {
                new MenuItem(){ Title="数据统计", ViewName="DataReportView", ModuleName="DataReportModule"}
            }
            },
            new MenuGroup(){ GroupName="用户管理", Items=new List<MenuItem>()
            {
            }
            },
             new MenuGroup(){ GroupName="系统设置", Items=new List<MenuItem>()
            {
            }
            }
        };

        public List<MenuGroup> Menus
        {
            get { return _Menus; }
            set { SetProperty(ref _Menus, value); }
        }
        #endregion
        #region 命令
        private DelegateCommand _LoadedCommand;
        public DelegateCommand LoadedCommand =>
            _LoadedCommand ?? (_LoadedCommand = new DelegateCommand(ExecuteLoadedCommand));

        void ExecuteLoadedCommand()
        {
            foreach (var item in Menus)
            {
                foreach (var menu in item.Items)
                {
                    moduleManager.LoadModule(menu.ModuleName);
                }
            }

            var homepage = Menus.First(p => p.GroupName == "首页");
            OpenCommand.Execute(homepage.Items[0]);
        }

        private DelegateCommand<MenuItem> _OpenCommand;
        public DelegateCommand<MenuItem> OpenCommand =>
            _OpenCommand ?? (_OpenCommand = new DelegateCommand<MenuItem>(ExecuteOpenCommand));

        void ExecuteOpenCommand(MenuItem value)
        {
            //regionManager.RequestNavigate("TabRegion", value.ViewName);
            eventAggregator.GetEvent<OpenMenuEvent>().Publish(value);
        }
        #endregion
    }
}
