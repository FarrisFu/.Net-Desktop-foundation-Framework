using JCF.Domain.Entitys;
using JCF.Module.Order.Views;
using JCF.Service.IServices;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JCF.Module.Order.ViewModels
{
    public class OrderViewModel : BindableBase
    {
        IGetOrderService _GetOrderService;
        public OrderViewModel(IGetOrderService getOrderService)
        {
            _GetOrderService = getOrderService;
        }


        #region 命令
        private DelegateCommand _LoadedCommand;
        public DelegateCommand LoadedCommand =>
            _LoadedCommand ?? (_LoadedCommand = new DelegateCommand(ExecuteLoadedCommand));
        /// <summary>
        /// 页面加载
        /// </summary>
        private async void ExecuteLoadedCommand()
        {
            var result = await _GetOrderService.GetOrders();
            if(result.Success && result.Data != null)
            {
                DataList = result.Data.Orders;
            }
        }
        #endregion

        #region 通知属性
        private string _title = nameof(OrderView);
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<OrderEntity> _DataList;
        public List<OrderEntity> DataList
        {
            get { return _DataList; }
            set { SetProperty(ref _DataList, value); }
        }
        #endregion



    }
}
