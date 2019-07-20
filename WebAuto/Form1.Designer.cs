namespace WebAuto
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccoutnPsdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.APToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Inbtn = new System.Windows.Forms.Button();
            this.txtInBusinessNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtOutBusinessNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Outbtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(80, 10);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(255, 21);
            this.txtAccount.TabIndex = 1;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(80, 44);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(255, 21);
            this.txtPassWord.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "登录账户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "登录密码";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.UserToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(383, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartPToolStripMenuItem,
            this.AccoutnPsdToolStripMenuItem,
            this.RecordToolStripMenuItem});
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.StartToolStripMenuItem.Text = "浏览器";
            // 
            // StartPToolStripMenuItem
            // 
            this.StartPToolStripMenuItem.Name = "StartPToolStripMenuItem";
            this.StartPToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.StartPToolStripMenuItem.Text = "启动";
            this.StartPToolStripMenuItem.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // AccoutnPsdToolStripMenuItem
            // 
            this.AccoutnPsdToolStripMenuItem.Name = "AccoutnPsdToolStripMenuItem";
            this.AccoutnPsdToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.AccoutnPsdToolStripMenuItem.Text = "嵌入账号密码";
            this.AccoutnPsdToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // RecordToolStripMenuItem
            // 
            this.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem";
            this.RecordToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.RecordToolStripMenuItem.Text = "打开录入界面";
            this.RecordToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserToolStripMenuItem
            // 
            this.UserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.APToolStripMenuItem});
            this.UserToolStripMenuItem.Name = "UserToolStripMenuItem";
            this.UserToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.UserToolStripMenuItem.Text = "账户";
            // 
            // APToolStripMenuItem
            // 
            this.APToolStripMenuItem.Name = "APToolStripMenuItem";
            this.APToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.APToolStripMenuItem.Text = "保存账户密码";
            this.APToolStripMenuItem.Click += new System.EventHandler(this.APToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(358, 184);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPassWord);
            this.tabPage1.Controls.Add(this.txtAccount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(350, 158);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Inbtn);
            this.tabPage2.Controls.Add(this.txtInBusinessNo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(350, 158);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "进口";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Inbtn
            // 
            this.Inbtn.Location = new System.Drawing.Point(127, 71);
            this.Inbtn.Name = "Inbtn";
            this.Inbtn.Size = new System.Drawing.Size(75, 23);
            this.Inbtn.TabIndex = 2;
            this.Inbtn.Tag = "In";
            this.Inbtn.Text = "填充数据";
            this.Inbtn.UseVisualStyleBackColor = true;
            this.Inbtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtInBusinessNo
            // 
            this.txtInBusinessNo.Location = new System.Drawing.Point(80, 10);
            this.txtInBusinessNo.Name = "txtInBusinessNo";
            this.txtInBusinessNo.Size = new System.Drawing.Size(180, 21);
            this.txtInBusinessNo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "业务编号";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Outbtn);
            this.tabPage3.Controls.Add(this.txtOutBusinessNo);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(350, 158);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "出口";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtOutBusinessNo
            // 
            this.txtOutBusinessNo.Location = new System.Drawing.Point(80, 10);
            this.txtOutBusinessNo.Name = "txtOutBusinessNo";
            this.txtOutBusinessNo.Size = new System.Drawing.Size(180, 21);
            this.txtOutBusinessNo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "业务编号";
            // 
            // Outbtn
            // 
            this.Outbtn.Location = new System.Drawing.Point(127, 71);
            this.Outbtn.Name = "Outbtn";
            this.Outbtn.Size = new System.Drawing.Size(75, 23);
            this.Outbtn.TabIndex = 5;
            this.Outbtn.Tag = "Out";
            this.Outbtn.Text = "填充数据";
            this.Outbtn.UseVisualStyleBackColor = true;
            this.Outbtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(383, 251);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem APToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccoutnPsdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartPToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtInBusinessNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtOutBusinessNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Inbtn;
        private System.Windows.Forms.Button Outbtn;
    }
}

