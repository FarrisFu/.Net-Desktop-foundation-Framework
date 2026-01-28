using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using DryIoc;
using JCF.MES.Views;
using JCF.Module.Login;
using JCF.Module.Main;
using JCF.Service;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.MES
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManager = Container.Resolve<IRegionManager>();
            //regionManager.RequestNavigate("MainRegion", "MainView");
            regionManager.RequestNavigate("MainRegion", "LoginView");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            ServiceRegistrar.RegisterServices(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LoginModule>();
            moduleCatalog.AddModule<MainModule>();
        }

        /// <summary>
        /// 加载模块目录
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }
    }
}
