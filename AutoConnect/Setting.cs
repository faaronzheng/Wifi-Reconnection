using System;
using System.Windows.Forms;
using System.Xml;
/*
 * version: 1.1
 * author: faaron
 * e-mail: faaronzheng@gmail.com
 */
namespace AutoConnect
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            //初始化comboBox控件
            Authentication_comboBox.Items.Add("WPAPSK");
            Authentication_comboBox.Items.Add("WPA2PSK");
            Encryption_comboBox.Items.Add("AES");
            Encryption_comboBox.Items.Add("TKIP");
            Authentication_comboBox.SelectedIndex = 0;
            Encryption_comboBox.SelectedIndex = 0;
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ShutDown_numericUpDown.Value.ToString()) < 10)
            {
                MessageBox.Show("请确保自动关机时间不小于10分钟！");
            }
            else
            {
                try
                {
                    //保存设置
                    XmlDocument doc = new XmlDocument();
                    doc.Load("setting.xml");
                    XmlNode basic = doc.SelectSingleNode("setting").FirstChild;
                    XmlElement elem = (XmlElement)basic;
                    elem.SetAttribute("timeout", ShutDown_numericUpDown.Value.ToString());
                    elem.SetAttribute("authen", Authentication_comboBox.SelectedItem.ToString());
                    elem.SetAttribute("encry", Encryption_comboBox.SelectedItem.ToString());
                    doc.Save("setting.xml");
                    MessageBox.Show("保存成功！");
                }
                catch (Exception err)
                {
                    MessageBox.Show("保存失败！"+err.Message);
                }
                
            }
        }

        private void ResetXml_button_Click(object sender, EventArgs e)
        {
            //重新创建xml文件
            XmlOP reset = new XmlOP();
            reset.creXml();
        }

        private void CancleSD_button_Click(object sender, EventArgs e)
        {
            //撤销关机
            State cancle = new State();
            cancle.useCmd("shutdown -a");
            MessageBox.Show("撤销成功！");

        }
    }
}
