using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Xml;

namespace Tetirs
{
    class Config
    {
        private Keys _downKey ;
    
        private Keys _dropDownKey ;
    
        private Keys _moveLeftKey ;
    
        private Keys _moveRightKey ;
    
        private Keys _rotCWKey ;
    
        private Keys _rotCCWKey ;

        
        private int _coorWidth ;
    
        private  int _coorHeight ;
    
        private int  _rectPix ;
    
        private Color _backColor ;

        private  InfoArr info=new InfoArr();

        #region 私有字段的属性
        public Keys DownKey
        {
            get { return _downKey; }
            set { _downKey = value; }
        }

        public Keys DropDownKey
        {
            get { return _dropDownKey; }
            set { _dropDownKey = value; }
        }

        public Keys MoveLeftKey
        {
            get { return _moveLeftKey; }
            set { _moveLeftKey = value; }
        }

        public Keys MoveRightKey
        {
            get { return _moveRightKey; }
            set { _moveRightKey = value; }
        }

        public Keys RotCwKey
        {
            get { return _rotCWKey; }
            set { _rotCWKey = value; }
        }

        public Keys RotCcwKey
        {
            get { return _rotCCWKey; }
            set { _rotCCWKey = value; }
        }

        public int CoorWidth
        {
            get { return _coorWidth; }
            set
            {
                if (value >= 10 && value <= 50)
                {
                    _coorWidth = value;
                }

            }
        }

        public int CoorHeight
        {
            get { return _coorHeight; }
            set
            {
                if (value >= 15&& value <= 50)
                    _coorHeight = value;
            }
        }

        public int RectPix
        {
            get { return _rectPix; }
            set
            {
                if (value >= 10 && value <= 30)
                    _rectPix = value;
            }
        }

        public Color BackColor
        {
            get { return _backColor; }
            set { _backColor = value; }
        }

        public InfoArr Info
        {
            get { return info; }
            set { info = value; }
        }

        #endregion

        public void LoadFromXmlFile()
        {
            XmlTextReader reader;

            if (File.Exists("BlockSet.xml"))
            {  //优先读取文件夹中的"BlockSet.xml"文件.
                reader = new XmlTextReader("BlockSet.xml");
            }

            else
            {
                //若不存在"BlockSet.xml"文件,则读取程序内部的.
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream sm = asm.GetManifestResourceStream("Tetirs.BlockSet.xml");
                reader=new XmlTextReader(sm);
            }

            string key = "";
            try
            {

                while (reader.Read())
                {
                    if (reader.NodeType==XmlNodeType.Element)
                    {
                        if (reader.Name=="ID")
                        {
                            key = reader.ReadElementString().Trim();
                            Info.AddType(key,""); 
                        }
                        else if (reader.Name=="Color")
                        {
                            // string aa = Convert.ToString(reader.ReadElementString().Trim());
                            Info[key] = Convert.ToString(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DownKey")
                        {
                            _downKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "DropDownKey")
                        {
                            _dropDownKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveLeftKey")
                        {
                            _moveLeftKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "MoveRightKey")
                        {
                            _moveRightKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RotCWKey")
                        {
                            _rotCWKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RotCCWKey")
                        {
                            _rotCCWKey = (Keys)Convert.ToInt32(reader.ReadElementString().Trim());
                        }

                        else if (reader.Name == "CoorWidth")
                        {
                            _coorWidth = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "CoorHeight")
                        {
                            _coorHeight = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "RectPix")
                        {
                            _rectPix = Convert.ToInt32(reader.ReadElementString().Trim());
                        }
                        else if (reader.Name == "BackColor")
                        {
                            _backColor = Color.FromArgb(Convert.ToInt32(reader.ReadElementString().Trim()));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader!=null)
                {
                    reader.Close();
                }
            }

        }

        public void SaveToXmlFile()
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<BlockSet></BlockSet>");
            XmlNode root = doc.SelectSingleNode("BlockSet");

            #region 写块模型信息
            for (int i = 0; i < Info.Length; i++)
            {
                XmlElement xelType = doc.CreateElement("Type");
                XmlElement xelID = doc.CreateElement("ID");
                xelID.InnerText = ((BlockInfo)Info[i]).GetIDStr();
                xelType.AppendChild(xelID);
                XmlElement xelColor = doc.CreateElement("Color");
                xelColor.InnerText = ((BlockInfo)Info[i]).GetColorStr();
                xelType.AppendChild(xelColor);
                root.AppendChild(xelType);
            }
            #endregion

            #region 写快捷键信息
            XmlElement xelKey = doc.CreateElement("Key");

            XmlElement xelDownKey = doc.CreateElement("DownKey");
            xelDownKey.InnerText = Convert.ToInt32(_downKey).ToString();
            xelKey.AppendChild(xelDownKey);

            XmlElement xelDropDownKey = doc.CreateElement("DropDownKey");
            xelDropDownKey.InnerText = Convert.ToInt32(_dropDownKey).ToString();
            xelKey.AppendChild(xelDropDownKey);


            XmlElement xelMoveLeftKey = doc.CreateElement("MoveLeftKey");
            xelMoveLeftKey.InnerText = Convert.ToInt32(_moveLeftKey).ToString();
            xelKey.AppendChild(xelMoveLeftKey);

            XmlElement xelMoveRightKey = doc.CreateElement("MoveRightKey");
            xelMoveRightKey.InnerText = Convert.ToInt32(_moveRightKey).ToString();
            xelKey.AppendChild(xelMoveRightKey);


            XmlElement xelRotCWKey = doc.CreateElement("RotCWKey");
            xelRotCWKey.InnerText = Convert.ToInt32(_rotCWKey).ToString();
            xelKey.AppendChild(xelRotCWKey);

            XmlElement xelRotCCWKey = doc.CreateElement("RotCCWKey");
            xelRotCCWKey.InnerText = Convert.ToInt32(_rotCCWKey).ToString();
            xelKey.AppendChild(xelRotCCWKey);

            root.AppendChild(xelKey);
            #endregion

            #region 写界面设置信息
            XmlElement xelSurface = doc.CreateElement("Surface");

            XmlElement xelCoorWidth = doc.CreateElement("CoorWidth");
            xelCoorWidth.InnerText = _coorWidth.ToString();
            xelKey.AppendChild(xelCoorWidth);


            XmlElement xelCoorHeight = doc.CreateElement("CoorHeight");
            xelCoorHeight.InnerText = _coorHeight.ToString();
            xelKey.AppendChild(xelCoorHeight);

            XmlElement xelRectPix = doc.CreateElement("RectPix");
            xelRectPix.InnerText = _rectPix.ToString();
            xelKey.AppendChild(xelRectPix);

            XmlElement xelBackColor = doc.CreateElement("BackColor");
            xelBackColor.InnerText = _backColor.ToArgb().ToString();
            xelKey.AppendChild(xelBackColor);


            root.AppendChild(xelSurface);
            #endregion

            doc.Save("BlockSet.xml");

        }

    }
}
