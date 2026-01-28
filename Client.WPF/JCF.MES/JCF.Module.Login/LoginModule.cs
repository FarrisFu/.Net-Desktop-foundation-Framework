using JCF.Module.Login.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.Login
{
    public class LoginModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //containerProvider.Resolve<IRegionManager>().RegisterViewWithRegion("MainRegion", typeof(LoginView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView>(nameof(LoginView));
        }
    }
}