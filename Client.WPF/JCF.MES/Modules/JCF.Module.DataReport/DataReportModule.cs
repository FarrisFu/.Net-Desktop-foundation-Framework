using JCF.Module.DataReport.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.DataReport
{
    [Module(ModuleName = "DataReportModule", OnDemand = true)]
    public class DataReportModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DataReportView>(nameof(DataReportView));
        }
    }
}