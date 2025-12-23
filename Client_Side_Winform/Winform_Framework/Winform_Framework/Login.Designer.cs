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
            this.label1 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.input1 = new AntdUI.Input();
            this.button1 = new AntdUI.Button();
            this.input2 = new AntdUI.Input();
            this.button2 = new AntdUI.Button();
            this.label4 = new AntdUI.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 17F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(141)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(184, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录界面";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.Location = new System.Drawing.Point(39, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.Location = new System.Drawing.Point(39, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "密  码：";
            // 
            // input1
            // 
            this.input1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.input1.Location = new System.Drawing.Point(143, 88);
            this.input1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.input1.Name = "input1";
            this.input1.Radius = 1;
            this.input1.Size = new System.Drawing.Size(300, 34);
            this.input1.TabIndex = 1;
            this.input1.Text = "input1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(174)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(100, 221);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Radius = 2;
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "登录";
            // 
            // input2
            // 
            this.input2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.input2.Location = new System.Drawing.Point(143, 141);
            this.input2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.input2.Name = "input2";
            this.input2.Radius = 1;
            this.input2.Size = new System.Drawing.Size(300, 34);
            this.input2.TabIndex = 1;
            this.input2.Text = "input1";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(174)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(293, 221);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Radius = 2;
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "退出";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label4.Location = new System.Drawing.Point(13, 318);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(466, 39);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前产线：SP-O-11  | 时间：|  版本：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(480, 360);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.input2);
            this.Controls.Add(this.input1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private AntdUI.Input input1;
        private AntdUI.Button button1;
        private AntdUI.Input input2;
        private AntdUI.Button button2;
        private AntdUI.Label label4;
    }
}