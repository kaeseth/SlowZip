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
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;

namespace SlowZip
{
    public partial class MainWindow : Form
    {
        private bool running = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void startBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = "F:\\Test";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string index = fbd.SelectedPath;
                this.logCom.Text += "正准备压缩目录："+index;
                ZipThread zip = new ZipThread(this,index);
                zip.setBtn = this.setBtn;
                zip.logger = this.logger;
                zip.lc = this.loggerClear;
                zip.setBtn = this.setBtn;
                zip.logger = this.logger;
                Thread thread = new Thread(new ThreadStart(zip.Start));
                thread.Start();
            }
        }

        private void logCom_TextChanged(object sender, EventArgs e)
        {
            logCom.SelectionStart = logCom.Text.Length;
            logCom.ScrollToCaret();
        }

        private void setBtn(bool temp)
        {
            this.startBtn.Enabled = temp;
        }
        
        private void logger(string message)
        {
            this.logCom.Text += message;
        }

        private void loggerClear()
        {
            this.logCom.Text = "";
        }

    }
}
