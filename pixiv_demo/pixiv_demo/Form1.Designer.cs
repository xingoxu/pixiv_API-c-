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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelbuttonicon = new System.Windows.Forms.Button();
            this.loadingIcon = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_doing = new System.Windows.Forms.Panel();
            this.progress_label = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.login_panel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.button2.Location = new System.Drawing.Point(373, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "get preview";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(201, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 129);
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
            this.groupBox1.Location = new System.Drawing.Point(10, 24);
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
            this.listBox1.Location = new System.Drawing.Point(166, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 95);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.cancelbuttonicon);
            this.panel1.Controls.Add(this.loadingIcon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 161);
            this.panel1.TabIndex = 7;
            // 
            // cancelbuttonicon
            // 
            this.cancelbuttonicon.BackgroundImage = global::pixiv_demo.Properties.Resources.stop;
            this.cancelbuttonicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelbuttonicon.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.cancelbuttonicon.FlatAppearance.BorderSize = 0;
            this.cancelbuttonicon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbuttonicon.Location = new System.Drawing.Point(350, 15);
            this.cancelbuttonicon.Name = "cancelbuttonicon";
            this.cancelbuttonicon.Size = new System.Drawing.Size(15, 15);
            this.cancelbuttonicon.TabIndex = 9;
            this.cancelbuttonicon.UseVisualStyleBackColor = true;
            this.cancelbuttonicon.Visible = false;
            this.cancelbuttonicon.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // loadingIcon
            // 
            this.loadingIcon.Image = global::pixiv_demo.Properties.Resources.HAPPI_Loading1;
            this.loadingIcon.Location = new System.Drawing.Point(330, 15);
            this.loadingIcon.Name = "loadingIcon";
            this.loadingIcon.Size = new System.Drawing.Size(15, 15);
            this.loadingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loadingIcon.TabIndex = 8;
            this.loadingIcon.TabStop = false;
            this.loadingIcon.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "这里输入id";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(272, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel_doing
            // 
            this.panel_doing.BackColor = System.Drawing.SystemColors.Window;
            this.panel_doing.Controls.Add(this.progress_label);
            this.panel_doing.Controls.Add(this.cancel_button);
            this.panel_doing.Controls.Add(this.progressBar1);
            this.panel_doing.Controls.Add(this.label1);
            this.panel_doing.Location = new System.Drawing.Point(125, 36);
            this.panel_doing.Name = "panel_doing";
            this.panel_doing.Size = new System.Drawing.Size(207, 61);
            this.panel_doing.TabIndex = 0;
            // 
            // progress_label
            // 
            this.progress_label.AutoSize = true;
            this.progress_label.Location = new System.Drawing.Point(69, 39);
            this.progress_label.Name = "progress_label";
            this.progress_label.Size = new System.Drawing.Size(20, 13);
            this.progress_label.TabIndex = 9;
            this.progress_label.Text = "0K";
            this.progress_label.Visible = false;
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(122, 7);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 8;
            this.cancel_button.Text = "取消";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
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
            this.login_panel.Location = new System.Drawing.Point(371, 27);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(97, 35);
            this.login_panel.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(373, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "test_api";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 164);
            this.Controls.Add(this.login_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_doing);
            this.Name = "Form1";
            this.Text = "pixiv_demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.PictureBox loadingIcon;
        private System.Windows.Forms.Button cancelbuttonicon;
        private System.Windows.Forms.Label progress_label;
        private System.Windows.Forms.Button button4;
    }
}

