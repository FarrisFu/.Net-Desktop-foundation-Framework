using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TopBar.Views;

namespace JCF.Module.TopBar
{
    [Module(ModuleName = "TopBarModule", OnDemand = true)]
    public class TopBarModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("TopBarRegin", typeof(TopBarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}