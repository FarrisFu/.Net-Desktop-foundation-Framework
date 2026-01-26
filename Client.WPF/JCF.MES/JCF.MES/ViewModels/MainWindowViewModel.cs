using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows;

namespace JCF.MES.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IModuleManager moduleManager;
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
        ? new GridLength(200)
        : new GridLength(60);
        #endregion

        #region 命令
        public DelegateCommand ToggleMenuCommand { get; }
        #endregion


        public MainWindowViewModel(IModuleManager moduleManager)
        {
            ToggleMenuCommand = new DelegateCommand(() =>
            {
                IsMenuExpanded = !IsMenuExpanded;
                RaisePropertyChanged(nameof(MenuWidth));
            });
            this.moduleManager = moduleManager;
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
    }
}
