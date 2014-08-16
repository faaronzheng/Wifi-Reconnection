namespace AutoConnect
{
    partial class AutoConnect
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoConnect));
            this.WifiName_label = new System.Windows.Forms.Label();
            this.WifiPswd_label = new System.Windows.Forms.Label();
            this.WifiPswd_textBox = new System.Windows.Forms.TextBox();
            this.WifiName_comboBox = new System.Windows.Forms.ComboBox();
            this.AutoConnect_button = new System.Windows.Forms.Button();
            this.Setting_button = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Crack_button = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // WifiName_label
            // 
            this.WifiName_label.AutoSize = true;
            this.WifiName_label.Location = new System.Drawing.Point(37, 26);
            this.WifiName_label.Name = "WifiName_label";
            this.WifiName_label.Size = new System.Drawing.Size(47, 12);
            this.WifiName_label.TabIndex = 0;
            this.WifiName_label.Text = "wifi名:";
            // 
            // WifiPswd_label
            // 
            this.WifiPswd_label.AutoSize = true;
            this.WifiPswd_label.Location = new System.Drawing.Point(37, 60);
            this.WifiPswd_label.Name = "WifiPswd_label";
            this.WifiPswd_label.Size = new System.Drawing.Size(59, 12);
            this.WifiPswd_label.TabIndex = 2;
            this.WifiPswd_label.Text = "wifi密码:";
            // 
            // WifiPswd_textBox
            // 
            this.WifiPswd_textBox.Location = new System.Drawing.Point(102, 58);
            this.WifiPswd_textBox.Name = "WifiPswd_textBox";
            this.WifiPswd_textBox.PasswordChar = '*';
            this.WifiPswd_textBox.Size = new System.Drawing.Size(120, 21);
            this.WifiPswd_textBox.TabIndex = 3;
            // 
            // WifiName_comboBox
            // 
            this.WifiName_comboBox.FormattingEnabled = true;
            this.WifiName_comboBox.Location = new System.Drawing.Point(101, 26);
            this.WifiName_comboBox.Name = "WifiName_comboBox";
            this.WifiName_comboBox.Size = new System.Drawing.Size(121, 20);
            this.WifiName_comboBox.TabIndex = 4;
            this.WifiName_comboBox.SelectedIndexChanged += new System.EventHandler(this.WifiName_comboBox_SelectedIndexChanged);
            // 
            // AutoConnect_button
            // 
            this.AutoConnect_button.Location = new System.Drawing.Point(52, 120);
            this.AutoConnect_button.Name = "AutoConnect_button";
            this.AutoConnect_button.Size = new System.Drawing.Size(75, 23);
            this.AutoConnect_button.TabIndex = 5;
            this.AutoConnect_button.Text = "自动重连";
            this.AutoConnect_button.UseVisualStyleBackColor = true;
            this.AutoConnect_button.Click += new System.EventHandler(this.AutoConnect_button_Click);
            // 
            // Setting_button
            // 
            this.Setting_button.Location = new System.Drawing.Point(188, 120);
            this.Setting_button.Name = "Setting_button";
            this.Setting_button.Size = new System.Drawing.Size(75, 23);
            this.Setting_button.TabIndex = 9;
            this.Setting_button.Text = "配置";
            this.Setting_button.UseVisualStyleBackColor = true;
            this.Setting_button.Click += new System.EventHandler(this.Setting_button_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "faaron-wifi";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Crack_button
            // 
            this.Crack_button.Location = new System.Drawing.Point(234, 56);
            this.Crack_button.Name = "Crack_button";
            this.Crack_button.Size = new System.Drawing.Size(75, 23);
            this.Crack_button.TabIndex = 10;
            this.Crack_button.Text = "暴力破解";
            this.Crack_button.UseVisualStyleBackColor = true;
            this.Crack_button.Click += new System.EventHandler(this.Crack_button_Click);
            // 
            // AutoConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 191);
            this.Controls.Add(this.Crack_button);
            this.Controls.Add(this.Setting_button);
            this.Controls.Add(this.AutoConnect_button);
            this.Controls.Add(this.WifiName_comboBox);
            this.Controls.Add(this.WifiPswd_textBox);
            this.Controls.Add(this.WifiPswd_label);
            this.Controls.Add(this.WifiName_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoConnect";
            this.Text = "Faaron-wifi重连";
            this.Load += new System.EventHandler(this.AutoConnect_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WifiName_label;
        private System.Windows.Forms.Label WifiPswd_label;
        private System.Windows.Forms.TextBox WifiPswd_textBox;
        private System.Windows.Forms.ComboBox WifiName_comboBox;
        private System.Windows.Forms.Button AutoConnect_button;
        private System.Windows.Forms.Button Setting_button;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button Crack_button;
    }
}

