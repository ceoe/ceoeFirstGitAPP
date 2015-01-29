using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PicSeeNav
{
    class PicInfo
    {
        private string _fullName;
        private string _nameNoExtesion;
        private string _shortName;
        private string _extension;

        public PicInfo(string path)
        {
            FullName = path;
            NameNoExtesion = Path.GetFileNameWithoutExtension(path);
            _shortName = Path.GetFileName(path);
            _extension = Path.GetExtension(FullName);
        }

        public string ShortName
        {
            get { return _shortName; }
        }

        public string NameNoExtesion
        {
            get { return _nameNoExtesion; }

            set
            {
                if (value!=""&&value.IndexOf('.')==-1)
                {
                    _nameNoExtesion = value;
                }
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string GetExtesion()
        {
            return _extension;
        }

        public static bool IsImage(string path)
        {
            string ext = Path.GetExtension(path).ToUpper();
            if (ext == ".BMP" || ext == ".JPEG" || ext == ".JPG" || ext == ".ICO" || ext == ".GIF" || ext == "PNG")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return FullName;
        }




    }

        
    }
