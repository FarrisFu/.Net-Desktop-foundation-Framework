using JCF.Module.Main.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.Main
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //containerProvider.Resolve<IRegionManager>().RegisterViewWithRegion("MainRegion", typeof(MainView));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainView>(nameof(MainView));
        }
    }
}