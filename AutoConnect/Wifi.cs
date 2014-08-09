﻿using NativeWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
/*
 * version: 1.1
 * author: faaron
 * e-mail: faaronzheng@gmail.com
 */
namespace AutoConnect
{
    class WIFISSID
    {
        public string SSID = "NONE";
        public string dot11DefaultAuthAlgorithm = "";
        public string dot11DefaultCipherAlgorithm = "";
        public bool networkConnectable = true;
        public string wlanNotConnectableReason = "";
        public int wlanSignalQuality = 0;
        public WlanClient.WlanInterface wlanInterface = null;
    }

    class Wifi
    {
     //   public List<WIFISSID> ssid = new List<WIFISSID>();
        private String name=null;
        private String pswd=null;
        private Boolean isAdded = false;
        private string authen = null;
        private string encry = null;
        public Wifi(string name,string pswd,string authen,string encry)
        {
            this.name = name;
            this.pswd = pswd;
            this.authen = authen;
            this.encry = encry;

        }
        public Wifi()
        {
        }

      
        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }

        #region 枚举所有无线设备接收到的SSID
        public List<WIFISSID> ScanSSID()
        {
            List<WIFISSID> wifiName = new List<WIFISSID>();
          //  WIFISSID SSID = new WIFISSID();
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    WIFISSID targetSSID = new WIFISSID();
                    targetSSID.wlanInterface = wlanIface;
                    targetSSID.wlanSignalQuality = (int)network.wlanSignalQuality;
                    targetSSID.SSID = GetStringForSSID(network.dot11Ssid);
                    //targetSSID.SSID = Encoding.Default.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength);
                    targetSSID.dot11DefaultAuthAlgorithm = network.dot11DefaultAuthAlgorithm.ToString();
                    targetSSID.dot11DefaultCipherAlgorithm = network.dot11DefaultCipherAlgorithm.ToString();
                    // Console.WriteLine(targetSSID.SSID);
                    //if (targetSSID.SSID == "Tenda_4B8660")
                    //{
                    //    return targetSSID;
                    //}
                    wifiName.Add(targetSSID);
                   
                }
            }
            return wifiName;
        }
        #endregion



        #region 连接到指定的SSID
        public void ConnectToSSID(WIFISSID ssid,Boolean isSave) 
        {      
            //string mac = StringToHex(profileName); 
            //string key = "1213141516";
            //string profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>New{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><MSM><security><authEncryption><authentication>open</authentication><encryption>none</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>networkKey</keyType><protected>false</protected><keyMaterial>{2}</keyMaterial></sharedKey><keyIndex>0</keyIndex></security></MSM></WLANProfile>", profileName, mac, key);
            string profileXml = string.Format("<?xml version=\"1.0\" encoding=\"US-ASCII\"?> <WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><name>{0}</name></SSID></SSIDConfig> <connectionType>ESS</connectionType><connectionMode>auto</connectionMode><autoSwitch>false</autoSwitch><MSM><security><authEncryption><authentication>{1}</authentication><encryption>{2}</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>passPhrase</keyType><protected>false</protected><keyMaterial>{3}</keyMaterial></sharedKey></security></MSM></WLANProfile>",name,authen,encry, pswd);
            //string profileXml2 = "<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>Hacker SSID</name><SSIDConfig><SSID><hex>54502D4C494E4B5F506F636B657441505F433844323632</hex><name>TP-LINK_PocketAP_C8D262</name></SSID>        </SSIDConfig>        <connectionType>ESS</connectionType><connectionMode>manual</connectionMode><MSM> <security><authEncryption><authentication>open</authentication><encryption>none</encryption><useOneX>false</useOneX></authEncryption></security></MSM></WLANProfile>";
            ssid.wlanInterface.SetProfile(Wlan.WlanProfileFlags.AllUser, profileXml, true);
            ssid.wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any,name);
            //string myProfileXML = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><connectionMode>manual</connectionMode><MSM><security><authEncryption><authentication>open</authentication><encryption>none</encryption><useOneX>false</useOneX></authEncryption></security></MSM></WLANProfile>", profileName, mac);
            //ssid.wlanInterface.SetProfile(Wlan.WlanProfileFlags.AllUser, myProfileXML, true);
            //ssid.wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
            //Console.ReadKey();                 
            if (isSave)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("setting.xml");
                XmlNodeList nodeList = doc.SelectSingleNode("setting").ChildNodes;
                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;
                    if (xe.GetAttribute("ssid").Equals(name))
                    {
                        isAdded = true;
                    }
                }
                if (!isAdded)
                {
                    XmlOP xml = new XmlOP();
                    xml.addXml(name, pswd);
                }
            }
        #endregion
        }
     

    }
}
