using JCF.Service.HttpCore;
using JCF.Service.IServices;
using JCF.Service.ModelRequests;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JCF.Module.Login.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IAuthorizeService _authService;
        private readonly IRegionManager _regionManager;
        public LoginViewModel(IAuthorizeService authService, IRegionManager regionManager)
        {
            _authService = authService;
            _regionManager = regionManager;
            LoginCommand = new DelegateCommand(async () => await Login());
        }
        




        private async Task Login()
        {
            //var result = await _authService.Login(UserName, Password);
            var result = await _authService.Login(new LoginRequest() { UserName = UserName, Password = Password });

            if (result.Success)
            {
                JwtTokenProvider.SetToken(result.Data.Token);
                // 登录成功，导航到 MainView
                _regionManager.RequestNavigate("MainRegion", "MainView");
            }
            else
            {
                Error = "登录失败,请检查用户名和密码是否匹配";
            }
        }
        #region 命令
        public DelegateCommand LoginCommand { get; }


        #endregion
        #region 通知属性
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { SetProperty(ref _UserName, value); }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { SetProperty(ref _Password, value); }
        }

        private string _Error;
        public string Error
        {
            get { return _Error; }
            set { SetProperty(ref _Error, value); }
        }
        #endregion

    }
}
