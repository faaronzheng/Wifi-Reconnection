using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoConnect
{
    public partial class Crack : Form
    {

        private List<long> allComobo=new List<long>(); 
        private int passwordNumber=0;
        private WIFISSID targetSSID=null;
        private String authen=null;
        private String encry=null;
        private Thread allcombo = null;
        private Thread cracking = null;
        private Thread watch = null;
        private CrackPassword cp = null;

        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        public extern static bool InternetGetConnectedState(out int conState, int reder);

        public Crack(WIFISSID SSID, String authen, String encry)
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            targetSSID = SSID;
            this.authen = authen;
            this.encry = encry;
            cp = new CrackPassword(targetSSID, authen, encry, passwordNumber);
        }

        private void Crack_Load(object sender, EventArgs e)
        {
            PasswordNumber_numericUpDown.Value = 8;
            Form_comboBox.Items.Add("纯数字");
        //    Form_comboBox.Items.Add("字母+数字");
        //    Form_comboBox.Items.Add("数字+标点");
       //     Form_comboBox.Items.Add("字母+标点");
      //      Form_comboBox.Items.Add("数字+字母+标点");
            Form_comboBox.SelectedIndex = 0;
            MessageBox.Show("仅供娱乐！破解所需时间极其漫长！");
        }

        private void PasswordNumber_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            passwordNumber = Convert.ToInt32(PasswordNumber_numericUpDown.Value);
        }

        //public delegate String crackDelgate();                                             //声明委托

        //public void AsyncCallbackImpl(IAsyncResult ar)
        //{
        //    crackDelgate iss = ar.AsyncState as crackDelgate;
        //    password = iss.EndInvoke(ar);
        //}   

        private void StartCrack_button_Click(object sender, EventArgs e)
        {
            if (StartCrack_button.Text.Equals("开始破解"))
            {
                StartCrack_button.Text = "停止破解";
                Info_label.Text = "正在玩命破解中···";
                this.Refresh();
               
                allcombo = new Thread(cp.AllCombo);
                allcombo.IsBackground = true;
                allcombo.Start();
                cracking = new Thread(cp.Cracking);
                cracking.IsBackground = true;
                cracking.Start();
                //crackDelgate cd = new crackDelgate(cp.Cracking);
                //AsyncCallback callback = new AsyncCallback(this.AsyncCallbackImpl);
                //cd.BeginInvoke(callback, cd);
                watch = new Thread(wifiState);
                watch.IsBackground = true;
                watch.Start();
            }
            else
            {
                StartCrack_button.Text = "开始破解";
                Info_label.Text = "";
                this.Refresh();
                allcombo.Abort();
                cracking.Abort();
                watch.Abort();
 
            }
        
        }


       private void wifiState()
        {
           
            int Desc = 0;
            while(true)
            {
                Thread.Sleep(6000);
         //       Info_label2.Text = cp.crackingNumber.ToString();
                if (InternetGetConnectedState(out Desc, 0))       //有网络连接 
                {
                    MessageBox.Show("破解成功！密码是：" + cp.password);
                    allcombo.Abort();
                    cracking.Abort();                  
                    watch.Abort();
                }

            }
        }

       
    }
}
