using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SlowZip
{
    class ZipThread
    {
        private bool running;
        public bool Running
        {
            set
            {
                this.running = value;
            }
            get
            {
                return this.running;
            }
        }

        /*
         * 1. 相对目录
         * 2. 当该文件夹下存在子文件夹，先压缩子文件夹，深度优先遍历。
         * 3. 当压缩完目录后，删除原目录
         * 4. 提供压缩文件列表，而不是所有的要压缩项目的根目录
         * 5. 放弃当天的目录压缩，即创建时间不能是今天。
         * 6. 每一个要压缩的目录下的目录，都要创建一个压缩文件。
         * 7. 必须保证单线程，低cpu占用率。
         * 8. 子目录下的子目录不创建单独的压缩文件。（与第二条冲突，优先采用该条）
         * 9. 是否提供判断该目录是否是需要压缩的目录？
         * */

        private Form form;//用来执行界面刷新的对象
        private string index;//要压缩的目录
        private string tempLogger;

        public ZipThread(Form form,string root)
        {
            this.form = form;
            this.index = root;
            this.tempLogger = "";
        }

        public delegate void BtnDisabled(bool temp);
        public BtnDisabled setBtn;

        public delegate void Logger(string message);
        public Logger logger;

        public delegate void LoggerClear();
        public LoggerClear lc;

        public void Start()
        {
            //获取该目录下的所有目录
            this.form.Invoke(setBtn,false);
            if (this.index != null && this.index != "" && Directory.Exists(this.index))
            {
                string[] indexs = Directory.GetDirectories(this.index);
                if (indexs != null && indexs.Length > 0)
                {
                    foreach(string temp in indexs)
                    {

                        DateTime createTime = Directory.GetCreationTime(temp);
                        DateTime now = DateTime.Now;
                        TimeSpan ts = now - createTime;
                        int tsday = ts.Days;
                        if (tsday > 0)
                        {
                            this.form.Invoke(logger, "正在压缩目录：" + temp + "\r\n");
                            IndexZip zip = new IndexZip(temp);
                            zip.Zip();
                            zip.Close();
                            zip = null;
                            Directory.Delete(temp,true);
                        }
                        else
                        {
                            //放弃压缩该目录
                        }
                    }
                }
            }
            else
            {
                this.form.Invoke(this.logger, "Error:当前目录不存在：" + this.index + "\r\n");
            }
            
            this.form.Invoke(this.lc);
            this.form.Invoke(this.setBtn, true);
            this.form = null;
            this.index = null;
        }

    }

}
