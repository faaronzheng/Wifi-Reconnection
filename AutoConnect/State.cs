using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
/*
 * version: 1.1
 * author: faaron
 * e-mail: faaronzheng@gmail.com
 */
namespace AutoConnect
{
    class State
    {
        private Wifi wifi = null;
        public Boolean AutoConFlag = false;                          //是否进行重连标志 
        public bool timeout = false;                                 //是否超时标志
        int time = 0;
        private Stopwatch sw = null;                                 //计时      
        private WIFISSID targetSSID=null;
        private String pswd=null;
        public Boolean connectResult = true;
        //检测网络状态
        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        public extern static bool InternetGetConnectedState(out int conState, int reder);

        public State(WIFISSID SSID,String pswd,String authen,String encry,int time)
        {
            targetSSID=SSID;
            this.pswd=pswd;
            wifi = new Wifi(SSID,pswd,authen,encry);
            sw = new Stopwatch();         
            this.time = time*60000;
        }
        public State()
        { }



        #region  重连线程
        public void AutoConThread()
        {
            int Desc = 0;
            while (true)
            {
                if (InternetGetConnectedState(out Desc, 0))       //有网络连接               
                {                                                     
                    sw.Reset();                //重置时间
                    continue;
                }
                else
                {
                    AutoConFlag = true;
                    sw.Start();                //开始计时
                    Thread.Sleep(1000);
                }
                if (AutoConFlag)
                {
                    Boolean result=wifi.ConnectToSSID();             //连接wifi
                    if (result==false)
                    {
                        connectResult = result;
                    }                
                    AutoConFlag = false;
                    Thread.Sleep(60000);
                }

                Thread.Sleep(10000);
            }       
        }
        #endregion


        #region 调用Cmd
        public void useCmd(string str)
        {
            System.Diagnostics.Process process = new Process();
            //StartInfo获取或设置要传递给Process的Start方法的属性.为ProcessStartInfo类型
            process.StartInfo.FileName = "cmd.exe";
            //设置UseShellExecute以指定是否使用操作系统外壳程序启动进程
            process.StartInfo.UseShellExecute = false;
            //使进程从文件或其他设备获取输入
            process.StartInfo.RedirectStandardInput = true;
            //向文件或其他设备返回输出
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            //给命令行传入关机命令
            process.StandardInput.WriteLine(str);
            process.StandardInput.WriteLine("exit");
            process.Close();
        }
        #endregion


        #region 断网关机线程
        public void monitorThread()                                        
        {
            while (true)
            {
                if (Convert.ToInt32(sw.ElapsedMilliseconds) > time)
                {
                    timeout = true;
                }
                if (timeout)
                {
                    useCmd("shutdown -s -t 600");
                    timeout = false;
                }
                Thread.Sleep(10000);
 
            }
        }

        #endregion
    }
}
