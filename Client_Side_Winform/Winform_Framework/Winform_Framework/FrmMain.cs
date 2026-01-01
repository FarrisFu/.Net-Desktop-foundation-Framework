using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolHelperClass;
using ToolHelperClass.LocalData.DbEntity;

namespace Winform_Framework
{
    public partial class FrmMain : AntdUI.Window
    {
        Dictionary<string, List<AntdUI.MenuItem>> menuItems = new Dictionary<string, List<AntdUI.MenuItem>>();
        List<MenuEntity> menuList;
        public FrmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //LoadPage();
            menuList = LocalDataService.GetMeunLIst();
            LoadLeftMenu(menuList);
            LoadMainWindowMenu(menuList);
        }

        /// <summary>
        /// 加载主菜单
        /// </summary>
        /// <param name="menuList"></param>
        private void LoadMainWindowMenu(List<MenuEntity> menuList)
        {
            try
            {
                Image image = Image.FromFile($"{Application.StartupPath}/Resources/软件图标.png");
                foreach (var item in menuList)
                {
                    MenuIcon menuIcon = new MenuIcon
                    {
                        TextShow = item.MenuName,
                        ImageShow = image,
                        Tag = item.MenuCode
                        //Margin=new Padding(10)
                    };
                    menuIcon.Click += new EventHandler(MenuIcon_Click);

                    if (item.MenuFatherCode == "General")
                    {
                        flpan1.Controls.Add(menuIcon);
                    }
                    else if (item.MenuFatherCode == "Other")
                    {
                        flpan2.Controls.Add(menuIcon);
                    }
                }
            }
            catch (Exception ex)
            {

                LogService.Error("加载主菜单异常", ex);
                DialogService.Error(this, "错误", "加载主菜单异常");
            }

        }
        private void MenuIcon_Click(object sender, EventArgs e)
        {
            MenuIcon menuIcon = sender as MenuIcon;
            MenuEntity menu = menuList.FirstOrDefault(p => p.MenuCode == menuIcon.Tag.ToString());
            if (menu != null)
            {
                OpenMenu(menu.MenuCode);
            }

            //DialogService.Success(this, $"点击了主菜单图标,tag={pBox.Tag}");
        }
        /// <summary>
        /// 加载左侧菜单
        /// </summary>
        private void LoadLeftMenu(List<MenuEntity> menuList)
        {
            try
            {
                menuLeft.Items.Clear();
                var menu1List = menuList.Where(p => p.MenuType == "1").ToList();
                foreach (var menu1 in menu1List)
                {
                    var rootMenu = new AntdUI.MenuItem()
                    {
                        Text = menu1.MenuName,
                        IconSvg = "UnorderedListOutlined",
                        Tag = menu1.MenuCode
                    };

                    List<MenuEntity> menu2List = menuList.Where(p => p.MenuType == "2" && p.MenuFatherCode == menu1.MenuCode).ToList();
                    menu2List.ForEach(p =>
                    {
                        rootMenu.Sub.Add(new AntdUI.MenuItem()
                        {
                            Text = p.MenuName,
                            IconSvg = "UnorderedListOutlined",
                            Tag = p.MenuCode
                        });
                    });

                    menuLeft.Items.Add(rootMenu);
                }

                /*
                menuItems.Add("菜单1", new List<AntdUI.MenuItem>()
                {
                    new AntdUI.MenuItem(){ Text="子菜单1-1"},
                    new AntdUI.MenuItem(){ Text="子菜单1-2"}
                });
                menuItems.Add("菜单2", new List<AntdUI.MenuItem>()
                {
                    new AntdUI.MenuItem(){ Text="子菜单2-1"},
                    new AntdUI.MenuItem(){ Text="子菜单2-2"}
                });

                foreach (var root in menuItems)
                {
                    var rootMenu = new AntdUI.MenuItem()
                    {
                        Text = "菜单1",
                        IconSvg = "UnorderedListOutlined"
                    };
                    foreach (var item in root.Value)
                    {
                        var subMenu = new AntdUI.MenuItem()
                        {
                            Text = item.Text,
                            IconSvg = "UnorderedListOutlined"
                        };
                        rootMenu.Sub.Add(subMenu);
                    }
                    menuLeft.Items.Add(rootMenu);
                }
                */
            }
            catch (Exception ex)
            {
                LogService.Error("加载左侧菜单异常", ex);
                DialogService.Error(this, "错误", "加载左侧菜单异常");
            }

        }

        /// <summary>
        /// 加载测试页面
        /// </summary>
        private void LoadPage()
        {
            for (int i = 0; i < 4; i++)
            {
                AntdUI.TabPage page = new AntdUI.TabPage() { Text = $"页面{i + 1}" };
                tabsMain.Pages.Add(page);
            }
        }
        /// <summary>
        /// 左侧菜单选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuLeft_SelectChanged(object sender, MenuSelectEventArgs e)
        {
            string menuCode = e.Value.Tag.ToString();
            OpenMenu(menuCode);
        }

        /// <summary>
        /// 打开菜单
        /// </summary>
        /// <param name="menuCode"></param>
        private void OpenMenu(string menuCode)
        {
            try
            {
                foreach (var item in tabsMain.Pages)
                {
                    if (item.Tag != null && item.Tag.ToString() == menuCode)
                    {
                        tabsMain.SelectedTab = item;
                        return;
                    }
                }

                AntdUI.TabPage newPage = new AntdUI.TabPage() { Tag = menuCode };
                foreach (var item in menuList)
                {
                    if (item.MenuCode == menuCode)
                    {
                        Assembly assembly = Assembly.LoadFile($"{Application.StartupPath}/{item.MenuDllName}");
                        Type formType = assembly.GetType($"{item.MenuFunName}.{item.MenuFunName}");
                        if (formType == null)
                        {
                            LogService.Warn(newPage.Text + "菜单对应的窗体类不存在");
                            DialogService.Warn(this, "警告", newPage.Text + "菜单对应的窗体类不存在");
                            return;
                        }

                        //创建窗体实例
                        object parameter = new object();
                        Form formInstance = (Form)Activator.CreateInstance(formType, parameter);
                        formInstance.Text = item.MenuName;
                        formInstance.Tag = item.MenuName;
                        formInstance.TopLevel = false;// 需要将窗体设置为非顶级窗体
                        formInstance.Dock = DockStyle.Fill;
                        formInstance.Show();

                        newPage.Controls.Add(formInstance);
                        newPage.Text = item.MenuName;
                        break;
                    }
                }
                tabsMain.Pages.Add(newPage);
                tabsMain.SelectedTab = newPage;
            }
            catch (Exception ex)
            {
                LogService.Error("打开菜单异常", ex);
                DialogService.Error(this, "错误", "打开菜单异常");
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            if (menuLeft.Collapsed)
                panLeft.Width = (int)(250 * Config.Dpi);
            else
                panLeft.Width = (int)(50 * Config.Dpi);
            btnCollapse.Toggle = !btnCollapse.Toggle;
            menuLeft.Collapsed = !menuLeft.Collapsed;
        }
    }
}
