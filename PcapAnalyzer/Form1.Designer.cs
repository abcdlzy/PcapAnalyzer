namespace PcapAnalyzer
{
    partial class Form1
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
            this.Btnreadfile = new System.Windows.Forms.Button();
            this.tbinput = new System.Windows.Forms.TextBox();
            this.tboutput = new System.Windows.Forms.TextBox();
            this.btntransmute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btnreadfile
            // 
            this.Btnreadfile.Location = new System.Drawing.Point(579, 43);
            this.Btnreadfile.Name = "Btnreadfile";
            this.Btnreadfile.Size = new System.Drawing.Size(75, 23);
            this.Btnreadfile.TabIndex = 0;
            this.Btnreadfile.Text = "read";
            this.Btnreadfile.UseVisualStyleBackColor = true;
            this.Btnreadfile.Click += new System.EventHandler(this.Btnreadfile_Click);
            // 
            // tbinput
            // 
            this.tbinput.Location = new System.Drawing.Point(71, 85);
            this.tbinput.Multiline = true;
            this.tbinput.Name = "tbinput";
            this.tbinput.Size = new System.Drawing.Size(442, 121);
            this.tbinput.TabIndex = 1;
            // 
            // tboutput
            // 
            this.tboutput.Location = new System.Drawing.Point(71, 273);
            this.tboutput.Multiline = true;
            this.tboutput.Name = "tboutput";
            this.tboutput.Size = new System.Drawing.Size(442, 121);
            this.tboutput.TabIndex = 2;
            // 
            // btntransmute
            // 
            this.btntransmute.Location = new System.Drawing.Point(603, 229);
            this.btntransmute.Name = "btntransmute";
            this.btntransmute.Size = new System.Drawing.Size(97, 51);
            this.btntransmute.TabIndex = 3;
            this.btntransmute.Text = "button1";
            this.btntransmute.UseVisualStyleBackColor = true;
            this.btntransmute.Click += new System.EventHandler(this.Btntransmute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btntransmute);
            this.Controls.Add(this.tboutput);
            this.Controls.Add(this.tbinput);
            this.Controls.Add(this.Btnreadfile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btnreadfile;
        private System.Windows.Forms.TextBox tbinput;
        private System.Windows.Forms.TextBox tboutput;
        private System.Windows.Forms.Button btntransmute;
    }
}

