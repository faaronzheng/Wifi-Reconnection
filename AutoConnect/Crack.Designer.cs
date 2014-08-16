namespace AutoConnect
{
    partial class Crack
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
            this.Crack_panel = new System.Windows.Forms.Panel();
            this.StartCrack_button = new System.Windows.Forms.Button();
            this.Form_comboBox = new System.Windows.Forms.ComboBox();
            this.Form_label = new System.Windows.Forms.Label();
            this.PasswordNumber_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PasswordNumber_label = new System.Windows.Forms.Label();
            this.Info_label = new System.Windows.Forms.Label();
            this.Crack_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordNumber_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Crack_panel
            // 
            this.Crack_panel.AutoSize = true;
            this.Crack_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Crack_panel.Controls.Add(this.Info_label);
            this.Crack_panel.Controls.Add(this.StartCrack_button);
            this.Crack_panel.Controls.Add(this.Form_comboBox);
            this.Crack_panel.Controls.Add(this.Form_label);
            this.Crack_panel.Controls.Add(this.PasswordNumber_numericUpDown);
            this.Crack_panel.Controls.Add(this.PasswordNumber_label);
            this.Crack_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Crack_panel.Location = new System.Drawing.Point(0, 0);
            this.Crack_panel.Name = "Crack_panel";
            this.Crack_panel.Size = new System.Drawing.Size(284, 221);
            this.Crack_panel.TabIndex = 0;
            // 
            // StartCrack_button
            // 
            this.StartCrack_button.Location = new System.Drawing.Point(105, 146);
            this.StartCrack_button.Name = "StartCrack_button";
            this.StartCrack_button.Size = new System.Drawing.Size(75, 23);
            this.StartCrack_button.TabIndex = 6;
            this.StartCrack_button.Text = "开始破解";
            this.StartCrack_button.UseVisualStyleBackColor = true;
            this.StartCrack_button.Click += new System.EventHandler(this.StartCrack_button_Click);
            // 
            // Form_comboBox
            // 
            this.Form_comboBox.FormattingEnabled = true;
            this.Form_comboBox.Location = new System.Drawing.Point(122, 92);
            this.Form_comboBox.Name = "Form_comboBox";
            this.Form_comboBox.Size = new System.Drawing.Size(121, 20);
            this.Form_comboBox.TabIndex = 5;
            // 
            // Form_label
            // 
            this.Form_label.AutoSize = true;
            this.Form_label.Location = new System.Drawing.Point(43, 97);
            this.Form_label.Name = "Form_label";
            this.Form_label.Size = new System.Drawing.Size(65, 12);
            this.Form_label.TabIndex = 4;
            this.Form_label.Text = "密码组成：";
            // 
            // PasswordNumber_numericUpDown
            // 
            this.PasswordNumber_numericUpDown.Location = new System.Drawing.Point(122, 42);
            this.PasswordNumber_numericUpDown.Name = "PasswordNumber_numericUpDown";
            this.PasswordNumber_numericUpDown.Size = new System.Drawing.Size(120, 21);
            this.PasswordNumber_numericUpDown.TabIndex = 3;
            this.PasswordNumber_numericUpDown.ValueChanged += new System.EventHandler(this.PasswordNumber_numericUpDown_ValueChanged);
            // 
            // PasswordNumber_label
            // 
            this.PasswordNumber_label.AutoSize = true;
            this.PasswordNumber_label.Location = new System.Drawing.Point(42, 49);
            this.PasswordNumber_label.Name = "PasswordNumber_label";
            this.PasswordNumber_label.Size = new System.Drawing.Size(65, 12);
            this.PasswordNumber_label.TabIndex = 2;
            this.PasswordNumber_label.Text = "密码位数：";
            // 
            // Info_label
            // 
            this.Info_label.AutoSize = true;
            this.Info_label.Location = new System.Drawing.Point(103, 186);
            this.Info_label.Name = "Info_label";
            this.Info_label.Size = new System.Drawing.Size(0, 12);
            this.Info_label.TabIndex = 7;
            // 
            // Crack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.Crack_panel);
            this.Name = "Crack";
            this.Text = "暴力破解";
            this.Load += new System.EventHandler(this.Crack_Load);
            this.Crack_panel.ResumeLayout(false);
            this.Crack_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordNumber_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Crack_panel;
        private System.Windows.Forms.Button StartCrack_button;
        private System.Windows.Forms.ComboBox Form_comboBox;
        private System.Windows.Forms.Label Form_label;
        private System.Windows.Forms.NumericUpDown PasswordNumber_numericUpDown;
        private System.Windows.Forms.Label PasswordNumber_label;
        private System.Windows.Forms.Label Info_label;

    }
}