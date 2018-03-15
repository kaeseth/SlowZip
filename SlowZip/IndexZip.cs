using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SlowZip
{
    class IndexZip
    {
        /*
         * 一个目录压缩的实例
         * */

        private string root;//要压缩文件夹的根目录，上一层目录
        private string index;//要压缩的文件路径
        private string zip;//zip文件路径
        private ZipOutputStream zipStream;//压缩文件流
        private Queue<string> queue;//一个要处理的文件的队列
        public IndexZip(string index)
        {
            this.index = index;
            this.root= Directory.GetParent(this.index).FullName+"\\";
            this.zip = this.index + ".zip";
            this.zipStream = new ZipOutputStream(File.Create(this.zip));
            this.zipStream.SetLevel(6);
            this.queue = new Queue<string>();
            this.queue.Enqueue(this.index);
        }

        public void Zip()
        {
            string path = this.queue.Dequeue();
            while (path != null && path != "")
            {
                if (Directory.Exists(path))
                {
                    //如果当前是目录
                    string[] indexs = Directory.GetDirectories(path);
                    if (indexs != null && indexs.Length > 0)
                    {
                        foreach(string tempindex in indexs)
                        {
                            this.queue.Enqueue(tempindex);
                        }
                    }

                    string[] files = Directory.GetFiles(path);
                    if (files != null && files.Length > 0)
                    {
                        foreach(string file in files)
                        {
                            this.queue.Enqueue(file);
                        }
                    }

                }else if (File.Exists(path))
                {
                    //如果当前是文件
                    string file = path.Replace(root, "");
                    ZipEntry entry = new ZipEntry(file);
                    this.zipStream.PutNextEntry(entry);
                    FileStream fs = File.OpenRead(path);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    this.zipStream.Write(buffer, 0, buffer.Length);
                    fs.Flush();
                    fs.Dispose();
                    fs = null;
                }

                //path = this.queue.Dequeue();
                if (this.queue.Count > 0)
                {
                    path = this.queue.Dequeue();
                }
                else
                {
                    path = null;
                }

            }
            this.zipStream.Flush();
            this.zipStream.Finish();
            this.zipStream.Close();
            
        }
        
        public void Close()
        {
            this.zipStream.Dispose();
            this.zipStream = null;
            this.queue.Clear();
            this.queue = null;
            this.root = null;
            this.index = null;
            this.zip = null;
        }

    }
}
