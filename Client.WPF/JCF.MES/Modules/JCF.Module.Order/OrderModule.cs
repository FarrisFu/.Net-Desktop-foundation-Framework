using JCF.Module.Order.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.Order
{
    [Module(ModuleName = "OrderModule", OnDemand = true)]
    public class OrderModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<OrderView>(nameof(OrderView));
        }
    }
}