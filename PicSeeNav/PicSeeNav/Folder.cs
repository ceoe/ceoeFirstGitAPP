using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace PicSeeNav
{
    class Folder
    {
        private string _name;
        private bool _isLoad;
        //应用程序的图片文件目录
        private string _sourcePicDir;
        //应用程序缩略图文件目录
        private string _thumbnailDIR;
        //缩略图Hastable[key ,value] 表
        public Hashtable bmps;

        public Folder(string appPath, string actualDirName)
        {
            _name = actualDirName;
            _sourcePicDir = appPath + "\\图片目录\\" + actualDirName;
            _thumbnailDIR = appPath + "\\缓存目录\\" + actualDirName;
            _isLoad = false;
            if (!Directory.Exists(SourcePicDir))
            {
                Directory.CreateDirectory(SourcePicDir);
            }
            if (!Directory.Exists(ThumbnailDir))
            {
                Directory.CreateDirectory(ThumbnailDir);
            }

        }

        public bool IsLoad
        {
            get { return _isLoad; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string SourcePicDir
        {
            get { return _sourcePicDir; }
        }

        public string ThumbnailDir
        {
            get { return _thumbnailDIR; }
        }

        //通过文件名来获得BITMAP对象, 这个对象是在内存的HASHTABLE中使用key,value来找到的,
        //sourceName似乎只包含了文件名, 不包含路径
        public Bitmap GetThumbnail(string sourceName)
        {
            return (Bitmap)bmps[sourceName];
        }

        //通过文件名取得实际应用程序 -> 图片目录 -> 对应文件夹->图片文件名 中的图片.
        public Bitmap GetImageFromDir(string aName)
        {
            Bitmap bmp = new Bitmap(_sourcePicDir + "\\" + aName);
            return bmp;
        }


        //从应用程序->图片文件夹->指定文件夹  遍历文件夹  中取得图片, 并转化成缩略图并保存. 然后
        //在bmps  hashtable 中建立[文件名->key,  bitmap 缩略图 ->value]
        public void ReadDirPicFileAndCreatThumbAddToBmps(string origPicPath)
        {
            if (bmps == null)
            {
                bmps = new Hashtable();
            }
            foreach (string sourceFile in Directory.GetFiles(origPicPath))
            {
                if (!PicInfo.IsImage(sourceFile))
                {
                    continue;
                }
                string picName = Path.GetFileNameWithoutExtension(sourceFile);
                string thumbnailFile = _thumbnailDIR + "\\" + picName + ".bmp";
                if (!File.Exists(thumbnailFile))
                {
                    //转换成缩略图并保存到对应 缩略图文件夹->文件名 的功能由这个函数实现.
                    CreatThumbnail(sourceFile, thumbnailFile);
                }
                bmps.Add(Path.GetFileName(sourceFile), new Bitmap(thumbnailFile));

            }
            _isLoad = true;
        }

        //给出一个aName的新图片的全路径, 分别生成应用程序图片路径和缓存图片路径
        //并调用CreatThumbnail方法对指定路径的sourcefile生成对应的thumbnail图.
        // 但是似乎没有看到aName没有拷贝过来的语句.!!!!
        public void GeneratThumbToSaveAndLoadtoBmpsFromaName(string aName)
        {
            //将新添加的图片全路径 生成一个BMP形式的缩略图,文件名放入picName中
            string tmpForThumbnail = Path.GetFileNameWithoutExtension(aName) + ".BMP";
            //
            string sourceFile = aName;
            string thumbnailFile = _thumbnailDIR + "\\" + tmpForThumbnail;
            CreatThumbnail(sourceFile, thumbnailFile);
            bmps.Add(Path.GetFileName(sourceFile), new Bitmap(thumbnailFile));
        }

        public bool ThumbnailCallBack()
        {
            return false;
        }
        public void CreatThumbnail(string source, string dest)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallBack);

            Bitmap bmp = new Bitmap(source);

            int x = bmp.Width;
            int y = bmp.Height;
            try
            {
                if (x > 100 && y > 100)
                {
                    float scale = (x > y) ? x / 100f : y / 100f;
                    Image aThumbnail = bmp.GetThumbnailImage((int)(x / scale), (int)(y / scale),
                                                               myCallback, IntPtr.Zero);
                    aThumbnail.Save(dest, ImageFormat.Bmp);

                }
                else
                {
                    bmp.Save(dest, ImageFormat.Bmp);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bmp.Dispose();
            }

        }

        public override string ToString()
        {
            return _name;
        }


        public static Rectangle GetRectFromBounds(Bitmap bmp, Rectangle Bounds)
        {
            int x, y;
            x = Bounds.X + (Bounds.Width - bmp.Width) / 2;
            y = Bounds.Y + (100 - bmp.Height) / 2 + 4;
            return new Rectangle(x, y, bmp.Width, bmp.Height);

        }

        public static Rectangle GetRectFromBounds(int width, int height, Rectangle Bounds)
        {
            int x, y;
            x = Bounds.X + (Bounds.Width - width) / 2;
            y = Bounds.Y + (100 - height) / 2 + 4;
            return new Rectangle(x, y, width, height);

        }


        public void Remove(string aName)
        {
            string picName = Path.GetFileNameWithoutExtension(aName) + ".bmp";
            string sourceFile = _sourcePicDir + "\\" + aName;
            string thumbnailFile = _thumbnailDIR + "\\" + picName;
            try
            {
                Bitmap bmp = (Bitmap)bmps[aName];
                bmps.Remove(aName);
                bmp.Dispose();
                File.Delete(sourceFile);
                File.Delete(thumbnailFile);

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void RemoveDIR()
        {
            foreach (DictionaryEntry de in bmps)
            {
                string aName = de.Key.ToString();
                string picName = Path.GetFileNameWithoutExtension(aName) + ".bmp";
                string sourceFile = _sourcePicDir + "\\" + aName;
                string thumbnailFile = _thumbnailDIR + "\\" + picName;
                Bitmap bmp = (Bitmap)de.Value;
                bmp.Dispose();
                try
                {
                    File.Delete(sourceFile);
                    File.Delete(thumbnailFile);
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            bmps.Clear();
        }



    }
}
