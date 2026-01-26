using JCF.Module.LeftMenu.ViewModels;
using JCF.Module.LeftMenu.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.LeftMenu
{
    [Module(ModuleName = "LeftMenuModule", OnDemand = true)]
    public class LeftMenuModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuRegin", typeof(LeftMenuView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}