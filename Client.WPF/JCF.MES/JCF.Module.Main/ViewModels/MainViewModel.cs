using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace JCF.Module.Main.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IModuleManager moduleManager;

        public MainViewModel(IModuleManager moduleManager)
        {           
            this.moduleManager = moduleManager;
        }
        #region 通知属性

        private string _title = "JCF.MES系统框架";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isMenuExpanded = true;
        public bool IsMenuExpanded
        {
            get => _isMenuExpanded;
            set => SetProperty(ref _isMenuExpanded, value);
        }
        public GridLength MenuWidth => IsMenuExpanded
        ? new GridLength(150)
        : new GridLength(60);
        #endregion

        #region 命令

        private DelegateCommand _ToggleMenuCommand;
        public DelegateCommand ToggleMenuCommand =>
            _ToggleMenuCommand ?? (_ToggleMenuCommand = new DelegateCommand(ExecuteToggleMenuCommand));

        void ExecuteToggleMenuCommand()
        {
            IsMenuExpanded = !IsMenuExpanded;
            RaisePropertyChanged(nameof(MenuWidth));
        }

        private DelegateCommand _LoadedCommand;
        public DelegateCommand LoadedCommand =>
            _LoadedCommand ?? (_LoadedCommand = new DelegateCommand(ExecuteLoadedCommand));

        void ExecuteLoadedCommand()
        {
            List<string> Menus = new List<string>() { "TopBarModule", "TabHostModule", "LeftMenuModule" };
            foreach (var item in Menus)
            {
                moduleManager.LoadModule(item);
            }
        }
        #endregion

    }
}
