using JCF.Module.TabHost.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.TabHost
{
    [Module(ModuleName = "TabHostModule", OnDemand = true)]
    public class TabHostModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("TabHostRegin", typeof(TabHostView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}