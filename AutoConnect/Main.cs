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
     //   private Thread monitor = null;                       
        private Thread autoConnect = null;
        private Thread monitor = null;
     //   private Thread shutDown = null;
        private Boolean isThread = false;                    //是否存在线程
        private String authen = null;                        //认证方式
        private String encry = null;                         //加密方式
        private int time = 0;                                //断网超时关机时间
        private WIFISSID targetSSID;
      //  private Boolean isConnection = true;
       // private XmlDocument doc = null;
       // private XmlNode node = null;
       // private XmlElement elem = null;
        public AutoConnect()
        {
            InitializeComponent();
            wifi = new Wifi();
            wifiName = new List<WIFISSID>();
            targetSSID = new WIFISSID();
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

     //   public delegate Boolean isSuccess();                                             //声明委托

    //    public void AsyncCallbackImpl(IAsyncResult ar)
     //   {
    //        isSuccess iss = ar.AsyncState as isSuccess;
    //        isConnection= iss.EndInvoke(ar);        
    //    }   

        private void AutoConnect_button_Click(object sender, EventArgs e)
        {
            if (AutoConnect_button.Text == "自动重连")
            {
                AutoConnect_button.Text = "取消重连";
                this.Refresh();
                if (!WifiName_comboBox.Text.Equals(""))            //合法输入判断
                {
                    foreach (WIFISSID SSID in wifiName)
                    {
                        if (SSID.SSID.Equals(WifiName_comboBox.Text.ToString()))
                        {
                            targetSSID = SSID;
                            break;
                        }
                    }
                    State state = new State(targetSSID, WifiPswd_textBox.Text.Trim().ToString(), authen, encry, time);
                    //   isSuccess iss=new isSuccess(state.AutoConThread);
                    //   AsyncCallback callback = new AsyncCallback(this.AsyncCallbackImpl);
                    //    iss.BeginInvoke(callback, iss);
                    autoConnect = new Thread(state.AutoConThread);
                    autoConnect.IsBackground = true;                 //设置线程为后台进程
                    //System.Environment.Exit(0); 也可以起到退出后程序完全关闭的效果
                    autoConnect.Start();
                    Thread.Sleep(3000);
                    if (state.connectResult == false)
                    {
                        MessageBox.Show("连接失败！小提示：密码正确和设置正确才能连得上哦！");
                    }

                    monitor = new Thread(state.monitorThread);
                    monitor.IsBackground = true;
                    monitor.Start();
                    isThread = true;
                    // wifi.ConnectToSSID(targetSSID);
                }
                else
                {
                    if (WifiName_comboBox.Text.Equals(""))
                    {
                        MessageBox.Show("请选择wifi！");
                        AutoConnect_button.Enabled = true;
                    }
                }

            }
            else
            {
                AutoConnect_button.Text = "自动重连";
                this.Refresh();
                if (isThread)
                {
                    AutoConnect_button.Enabled = true;
                    //     monitor.Abort();
                    autoConnect.Abort();
                    monitor.Abort();
                    //      shutDown.Abort();
                    isThread = false;
                }
 
            }        
         

        }

        private void Setting_button_Click(object sender, EventArgs e)
        {         
            if (isThread)
            {
                AutoConnect_button.Enabled = true;
           //     monitor.Abort();
                autoConnect.Abort();
                monitor.Abort();
          //      shutDown.Abort();
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
            if (!WifiPswd_textBox.Text.Equals(""))
            {
                WifiPswd_textBox.Text = "";
            }
            MethodInvoker mi = new MethodInvoker(showPswdThread);
            BeginInvoke(mi);    
            if (isThread)
            {
                AutoConnect_button.Enabled = true;
       //         monitor.Abort();
               autoConnect.Abort();
                monitor.Abort();
      //          shutDown.Abort();
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


        private void Crack_button_Click(object sender, EventArgs e)
        {
            if (WifiName_comboBox.Text.Equals(""))
            {
                MessageBox.Show("请先选择要破解的wifi名");
                return;
            }
            foreach (WIFISSID SSID in wifiName)
            {
                if (SSID.SSID.Equals(WifiName_comboBox.Text.ToString()))
                {
                    targetSSID = SSID;
                    break;
                }
            } 
            Crack crack = new Crack(targetSSID,authen,encry);
            crack.ShowDialog();
        }
    }
   
}
