
using JCF.Module.HomePage.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.HomePage
{
    [Module(ModuleName = "HomePageModule", OnDemand = true)]
    public class HomePageModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePageView>(nameof(HomePageView));
        }
    }
}