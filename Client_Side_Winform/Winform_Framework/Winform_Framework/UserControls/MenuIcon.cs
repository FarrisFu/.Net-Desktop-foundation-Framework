using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Windows.Forms;

namespace Winform_Framework
{
    public partial class MenuIcon : UserControl
    {
        private string textShow;

        public string TextShow
        {
            get { return textShow; }
            set 
            {
                textShow = value;
                label1.Text = value;
            }
        }
        private Image imageShow;

        public Image ImageShow
        {
            get { return imageShow; }
            set 
            { 
                imageShow = value;
                pictureBox1.Image = value;
            }
        }


        public MenuIcon()
        {
            InitializeComponent();
        }
    }
}
