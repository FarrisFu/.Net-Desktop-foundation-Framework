namespace Winform_Framework
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPassword = new AntdUI.Input();
            this.btnLogin = new AntdUI.Button();
            this.txtUserName = new AntdUI.Input();
            this.btnExit = new AntdUI.Button();
            this.panel1 = new AntdUI.Panel();
            this.panel2 = new AntdUI.Panel();
            this.label2 = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtPassword.Location = new System.Drawing.Point(170, 119);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "请输入密码";
            this.txtPassword.Radius = 1;
            this.txtPassword.Size = new System.Drawing.Size(300, 45);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Variant = AntdUI.TVariant.Underlined;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(137)))), ((int)(((byte)(237)))));
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(170, 182);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Radius = 16;
            this.btnLogin.Size = new System.Drawing.Size(300, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登  录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txtUserName.Location = new System.Drawing.Point(170, 64);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "请输入账号";
            this.txtUserName.Radius = 1;
            this.txtUserName.Size = new System.Drawing.Size(300, 45);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Variant = AntdUI.TVariant.Underlined;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(137)))), ((int)(((byte)(237)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(170, 236);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 16;
            this.btnExit.Size = new System.Drawing.Size(300, 45);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退  出";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(231, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 300);
            this.panel1.TabIndex = 3;
            this.panel1.Text = "panel1";
            // 
            // panel2
            // 
            this.panel2.Back = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(137)))), ((int)(((byte)(237)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Radius = 0;
            this.panel2.Size = new System.Drawing.Size(150, 300);
            this.panel2.TabIndex = 3;
            this.panel2.Text = "panel2";
            // 
            // label2
            // 
            this.label2.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "XXX系统";
            // 
            // label1
            // 
            this.label1.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎 ！";
            // 
            // label3
            // 
            this.label3.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 17F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(298, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "登  录";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Winform_Framework.Properties.Resources.渐变蓝色背景图;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.Input txtPassword;
        private AntdUI.Button btnLogin;
        private AntdUI.Input txtUserName;
        private AntdUI.Button btnExit;
        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Label label2;
        private AntdUI.Label label1;
        private AntdUI.Label label3;
    }
}