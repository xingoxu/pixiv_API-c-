namespace pixiv_demo
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.user_id_mode = new System.Windows.Forms.RadioButton();
            this.my_favourite_mode = new System.Windows.Forms.RadioButton();
            this.single_mode = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_doing = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.login_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_doing.SuspendLayout();
            this.login_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(373, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "get preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 113);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "download";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.user_id_mode);
            this.groupBox1.Controls.Add(this.my_favourite_mode);
            this.groupBox1.Controls.Add(this.single_mode);
            this.groupBox1.Location = new System.Drawing.Point(10, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 128);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择下载模式";
            // 
            // user_id_mode
            // 
            this.user_id_mode.AutoSize = true;
            this.user_id_mode.Location = new System.Drawing.Point(14, 93);
            this.user_id_mode.Name = "user_id_mode";
            this.user_id_mode.Size = new System.Drawing.Size(117, 17);
            this.user_id_mode.TabIndex = 2;
            this.user_id_mode.TabStop = true;
            this.user_id_mode.Text = "按作者id多张下载";
            this.user_id_mode.UseVisualStyleBackColor = true;
            // 
            // my_favourite_mode
            // 
            this.my_favourite_mode.AutoSize = true;
            this.my_favourite_mode.Location = new System.Drawing.Point(14, 61);
            this.my_favourite_mode.Name = "my_favourite_mode";
            this.my_favourite_mode.Size = new System.Drawing.Size(121, 17);
            this.my_favourite_mode.TabIndex = 1;
            this.my_favourite_mode.TabStop = true;
            this.my_favourite_mode.Text = "我的收藏多张下载";
            this.my_favourite_mode.UseVisualStyleBackColor = true;
            // 
            // single_mode
            // 
            this.single_mode.AutoSize = true;
            this.single_mode.Location = new System.Drawing.Point(14, 29);
            this.single_mode.Name = "single_mode";
            this.single_mode.Size = new System.Drawing.Size(93, 17);
            this.single_mode.TabIndex = 0;
            this.single_mode.TabStop = true;
            this.single_mode.Text = "按单张id下载";
            this.single_mode.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(166, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 95);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(272, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 151);
            this.panel1.TabIndex = 7;
            // 
            // panel_doing
            // 
            this.panel_doing.BackColor = System.Drawing.SystemColors.Window;
            this.panel_doing.Controls.Add(this.progressBar1);
            this.panel_doing.Controls.Add(this.label1);
            this.panel_doing.Location = new System.Drawing.Point(127, 44);
            this.panel_doing.Name = "panel_doing";
            this.panel_doing.Size = new System.Drawing.Size(207, 61);
            this.panel_doing.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(184, 24);
            this.progressBar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作执行中...";
            // 
            // login_panel
            // 
            this.login_panel.Controls.Add(this.button1);
            this.login_panel.Location = new System.Drawing.Point(371, 10);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(97, 35);
            this.login_panel.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "这里输入id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 145);
            this.Controls.Add(this.login_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_doing);
            this.Name = "Form1";
            this.Text = "pixiv_demo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_doing.ResumeLayout(false);
            this.panel_doing.PerformLayout();
            this.login_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton user_id_mode;
        private System.Windows.Forms.RadioButton my_favourite_mode;
        private System.Windows.Forms.RadioButton single_mode;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_doing;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel login_panel;
        private System.Windows.Forms.Label label2;
    }
}

