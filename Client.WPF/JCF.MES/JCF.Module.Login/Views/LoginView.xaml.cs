using JCF.Module.Login.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace JCF.Module.Login.Views
{
    /// <summary>
    /// Interaction logic for LoginView
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }
        // 处理密码框的密码更改
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;

            // 获取DataContext 中的 ViewModel
            var viewModel = (LoginViewModel)this.DataContext;

            // 更新 ViewModel 中的密码属性viewModel.Password = passwordBox.Password;
            viewModel.Password = passwordBox.Password;
        }
    }
}
