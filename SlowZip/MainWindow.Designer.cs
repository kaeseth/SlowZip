namespace SlowZip
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.logCom = new System.Windows.Forms.TextBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logCom
            // 
            this.logCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logCom.Location = new System.Drawing.Point(0, 0);
            this.logCom.Multiline = true;
            this.logCom.Name = "logCom";
            this.logCom.ReadOnly = true;
            this.logCom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logCom.Size = new System.Drawing.Size(448, 418);
            this.logCom.TabIndex = 0;
            this.logCom.TextChanged += new System.EventHandler(this.logCom_TextChanged);
            // 
            // startBtn
            // 
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startBtn.Location = new System.Drawing.Point(0, 395);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(448, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 418);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.logCom);
            this.Name = "MainWindow";
            this.Text = "SlowZip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logCom;
        private System.Windows.Forms.Button startBtn;
    }
}

