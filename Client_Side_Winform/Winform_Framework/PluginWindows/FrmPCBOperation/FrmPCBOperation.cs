using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FrmPCBOperation
{
    public partial class FrmPCBOperation : AntdUI.Window
    {
        public FrmPCBOperation(object parameter = null)
        {
            InitializeComponent();
        }

        private void FrmPCBOperation_Load(object sender, EventArgs e)
        {
            this.lbTitle.Text += this.Text;
        }
    }
}
