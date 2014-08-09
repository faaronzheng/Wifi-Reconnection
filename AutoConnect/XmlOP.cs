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
    class XmlOP
    {
        #region 创建xml文件
        public void creXml()    
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "gb2312", "yes");
            doc.AppendChild(dec);
            XmlElement elem1 = doc.CreateElement("", "setting", "");
            doc.AppendChild(elem1);
            XmlNode root = doc.SelectSingleNode("setting");
            XmlElement basic = doc.CreateElement("basic");
            basic.SetAttribute("timeout", "10");
            basic.SetAttribute("authen", "WPAPSK");
            basic.SetAttribute("encry", "AES");
            root.AppendChild(basic);           
            doc.Save("setting.xml");
        }
        #endregion

        #region 添加结点到xml
        public void addXml(string SSID,string pswd)   
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("setting.xml");
            XmlNode root = doc.SelectSingleNode("setting");
            XmlElement elem = doc.CreateElement(SSID);
            elem.SetAttribute("ssid", SSID);
            elem.SetAttribute("pswd", pswd);
            root.AppendChild(elem);
            doc.Save("setting.xml");
        }

        #endregion
    }
}
