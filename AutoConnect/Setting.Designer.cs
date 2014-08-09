namespace AutoConnect
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.ShutDown_label1 = new System.Windows.Forms.Label();
            this.ShutDown_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ShutDown_label2 = new System.Windows.Forms.Label();
            this.Setting_panel = new System.Windows.Forms.Panel();
            this.CancleSD_button = new System.Windows.Forms.Button();
            this.ResetXml_button = new System.Windows.Forms.Button();
            this.Save_button = new System.Windows.Forms.Button();
            this.Encryption_comboBox = new System.Windows.Forms.ComboBox();
            this.Encryption_label = new System.Windows.Forms.Label();
            this.Authentication_comboBox = new System.Windows.Forms.ComboBox();
            this.Authentication_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ShutDown_numericUpDown)).BeginInit();
            this.Setting_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShutDown_label1
            // 
            this.ShutDown_label1.AutoSize = true;
            this.ShutDown_label1.Location = new System.Drawing.Point(149, 25);
            this.ShutDown_label1.Name = "ShutDown_label1";
            this.ShutDown_label1.Size = new System.Drawing.Size(29, 12);
            this.ShutDown_label1.TabIndex = 0;
            this.ShutDown_label1.Text = "断网";
            // 
            // ShutDown_numericUpDown
            // 
            this.ShutDown_numericUpDown.Location = new System.Drawing.Point(184, 22);
            this.ShutDown_numericUpDown.Name = "ShutDown_numericUpDown";
            this.ShutDown_numericUpDown.Size = new System.Drawing.Size(120, 21);
            this.ShutDown_numericUpDown.TabIndex = 1;
            this.ShutDown_numericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ShutDown_label2
            // 
            this.ShutDown_label2.AutoSize = true;
            this.ShutDown_label2.Location = new System.Drawing.Point(306, 26);
            this.ShutDown_label2.Name = "ShutDown_label2";
            this.ShutDown_label2.Size = new System.Drawing.Size(53, 12);
            this.ShutDown_label2.TabIndex = 0;
            this.ShutDown_label2.Text = "分后关机";
            // 
            // Setting_panel
            // 
            this.Setting_panel.Controls.Add(this.CancleSD_button);
            this.Setting_panel.Controls.Add(this.ResetXml_button);
            this.Setting_panel.Controls.Add(this.Save_button);
            this.Setting_panel.Controls.Add(this.Encryption_comboBox);
            this.Setting_panel.Controls.Add(this.Encryption_label);
            this.Setting_panel.Controls.Add(this.Authentication_comboBox);
            this.Setting_panel.Controls.Add(this.Authentication_label);
            this.Setting_panel.Controls.Add(this.ShutDown_numericUpDown);
            this.Setting_panel.Controls.Add(this.ShutDown_label1);
            this.Setting_panel.Controls.Add(this.ShutDown_label2);
            this.Setting_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Setting_panel.Location = new System.Drawing.Point(0, 0);
            this.Setting_panel.Name = "Setting_panel";
            this.Setting_panel.Size = new System.Drawing.Size(469, 363);
            this.Setting_panel.TabIndex = 2;
            // 
            // CancleSD_button
            // 
            this.CancleSD_button.Location = new System.Drawing.Point(310, 214);
            this.CancleSD_button.Name = "CancleSD_button";
            this.CancleSD_button.Size = new System.Drawing.Size(91, 23);
            this.CancleSD_button.TabIndex = 8;
            this.CancleSD_button.Text = "撤销自动关机";
            this.CancleSD_button.UseVisualStyleBackColor = true;
            this.CancleSD_button.Click += new System.EventHandler(this.CancleSD_button_Click);
            // 
            // ResetXml_button
            // 
            this.ResetXml_button.Location = new System.Drawing.Point(63, 214);
            this.ResetXml_button.Name = "ResetXml_button";
            this.ResetXml_button.Size = new System.Drawing.Size(91, 23);
            this.ResetXml_button.TabIndex = 7;
            this.ResetXml_button.Text = "重置.xml文件";
            this.ResetXml_button.UseVisualStyleBackColor = true;
            this.ResetXml_button.Click += new System.EventHandler(this.ResetXml_button_Click);
            // 
            // Save_button
            // 
            this.Save_button.Location = new System.Drawing.Point(196, 300);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(75, 23);
            this.Save_button.TabIndex = 6;
            this.Save_button.Text = "保存";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Encryption_comboBox
            // 
            this.Encryption_comboBox.FormattingEnabled = true;
            this.Encryption_comboBox.Location = new System.Drawing.Point(184, 116);
            this.Encryption_comboBox.Name = "Encryption_comboBox";
            this.Encryption_comboBox.Size = new System.Drawing.Size(121, 20);
            this.Encryption_comboBox.TabIndex = 5;
            // 
            // Encryption_label
            // 
            this.Encryption_label.AutoSize = true;
            this.Encryption_label.Location = new System.Drawing.Point(125, 118);
            this.Encryption_label.Name = "Encryption_label";
            this.Encryption_label.Size = new System.Drawing.Size(65, 12);
            this.Encryption_label.TabIndex = 4;
            this.Encryption_label.Text = "加密方式：";
            // 
            // Authentication_comboBox
            // 
            this.Authentication_comboBox.FormattingEnabled = true;
            this.Authentication_comboBox.Location = new System.Drawing.Point(184, 69);
            this.Authentication_comboBox.Name = "Authentication_comboBox";
            this.Authentication_comboBox.Size = new System.Drawing.Size(121, 20);
            this.Authentication_comboBox.TabIndex = 3;
            // 
            // Authentication_label
            // 
            this.Authentication_label.AutoSize = true;
            this.Authentication_label.Location = new System.Drawing.Point(125, 73);
            this.Authentication_label.Name = "Authentication_label";
            this.Authentication_label.Size = new System.Drawing.Size(65, 12);
            this.Authentication_label.TabIndex = 2;
            this.Authentication_label.Text = "认证方式：";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 363);
            this.Controls.Add(this.Setting_panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setting";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShutDown_numericUpDown)).EndInit();
            this.Setting_panel.ResumeLayout(false);
            this.Setting_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ShutDown_label1;
        private System.Windows.Forms.NumericUpDown ShutDown_numericUpDown;
        private System.Windows.Forms.Label ShutDown_label2;
        private System.Windows.Forms.Panel Setting_panel;
        private System.Windows.Forms.ComboBox Authentication_comboBox;
        private System.Windows.Forms.Label Authentication_label;
        private System.Windows.Forms.Button Save_button;
        private System.Windows.Forms.ComboBox Encryption_comboBox;
        private System.Windows.Forms.Label Encryption_label;
        private System.Windows.Forms.Button ResetXml_button;
        private System.Windows.Forms.Button CancleSD_button;
    }
}