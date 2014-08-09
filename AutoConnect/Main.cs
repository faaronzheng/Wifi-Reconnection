using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NativeWifi;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Xml;

/*
 * version: 1.1
 * author: faaron
 * e-mail: faaronzheng@gmail.com
 */
namespace AutoConnect
{
    public partial class AutoConnect : Form
    {
        private Wifi wifi=null;                               
        private List<WIFISSID> wifiName = null;              //存储wifi名
        private Boolean isSave = false;                      //是否需要保存到xml
        private Thread monitor = null;                       
        private Thread autoConnect = null;
        private Thread watch = null;
        private Thread shutDown = null;
        private Boolean isThread = false;                    //是否存在线程
        private String authen = null;                        //认证方式
        private String encry = null;                         //加密方式
        private int time = 0;                                //断网超时关机时间
       // private XmlDocument doc = null;
       // private XmlNode node = null;
       // private XmlElement elem = null;
        public AutoConnect()
        {
            InitializeComponent();
            wifi = new Wifi();
            wifiName = new List<WIFISSID>();
         //   doc = new XmlDocument();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        #region  判断是否存在配置文件
        public Boolean IsXML()                           
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("setting.xml");
            }
            catch(Exception err)
            {
                return false;
            }
            return true;
        }
        #endregion


        #region 读取xml配置文件
        public void getStyle()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("setting.xml");
            XmlNode style = doc.SelectSingleNode("setting").FirstChild;
            XmlElement styleEle = (XmlElement)style;
            this.authen = styleEle.GetAttribute("authen");
            this.encry = styleEle.GetAttribute("encry");
            this.time = Convert.ToInt32(styleEle.GetAttribute("timeout"));
        }
        #endregion


        private void AutoConnect_Load(object sender, EventArgs e)
        {
            
            wifiName=wifi.ScanSSID();                      //获取wifi名
            foreach(WIFISSID SSID in wifiName)
            {
                WifiName_comboBox.Items.Add(SSID.SSID);     //显示
            }
            if (!IsXML())
            {
                XmlOP creXml = new XmlOP();
                creXml.creXml();
            }
            getStyle();
    
        }


        private void AutoConnect_button_Click(object sender, EventArgs e)
        {
            AutoConnect_button.Enabled = false;
            if (WifiName_comboBox.Text != "" && WifiPswd_textBox.Text != "")            //合法输入判断
            {         
                WIFISSID targetSSID = new WIFISSID();
                foreach (WIFISSID SSID in wifiName)
                {
                    if (SSID.SSID.Equals(WifiName_comboBox.Text.ToString()))
                    {
                        targetSSID = SSID;
                    }
                }
                State state = new State(targetSSID,WifiPswd_textBox.Text.Trim().ToString(),authen,encry,time);                                     
                autoConnect = new Thread(()=>state.AutoConThread(isSave));
                autoConnect.IsBackground = true;                 //设置线程为后台进程
                //System.Environment.Exit(0); 也可以起到退出后程序完全关闭的效果
                autoConnect.Start();
                watch = new Thread(state.watchThread);
                watch.IsBackground = true;
                watch.Start();
                isThread = true;
               // wifi.ConnectToSSID(targetSSID);
            }
            else                                             
            {
                if (WifiName_comboBox.Text == "")
                {
                    MessageBox.Show("请选择wifi名！");
                }
                if (WifiPswd_textBox.Text != "")
                {
                    MessageBox.Show("请输入密码！");
                }
            }

        }

        private void Setting_button_Click(object sender, EventArgs e)
        {         
            if (isThread)
            {
                AutoConnect_button.Enabled = true;
                monitor.Abort();
                autoConnect.Abort();
                watch.Abort();
                shutDown.Abort();
                isThread = false;
            }
            Form setting = new Setting();
            setting.ShowDialog();
        }

        public void showPswdThread()
        {
            //Thread.Sleep(100);
            XmlDocument doc = new XmlDocument();
            doc.Load("setting.xml");
            XmlNodeList nodeList = doc.SelectSingleNode("setting").ChildNodes;
            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (xe.GetAttribute("ssid").Equals(WifiName_comboBox.SelectedItem.ToString()))
                {
                    WifiPswd_textBox.Text = xe.GetAttribute("pswd");
                }
            }
        }

        private void WifiName_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WifiPswd_textBox.Text != "")
            {
                WifiPswd_textBox.Text = "";
            }
            MethodInvoker mi = new MethodInvoker(showPswdThread);
            BeginInvoke(mi);
            isSave = true;        
            if (isThread)
            {
                AutoConnect_button.Enabled = true;
                monitor.Abort();
                autoConnect.Abort();
                watch.Abort();
                shutDown.Abort();
                isThread = false;
            }

            
            //Thread t = new Thread(showPswdThread);
            //t.Start();
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;              //取消窗体在任务栏的显示 
            this.notifyIcon.Visible = true;          //显示托盘图标 
           // base.OnFormClosing(e);
        }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.ShowInTaskbar = true;
         //       this.notifyIcon.Visible = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
   
}
