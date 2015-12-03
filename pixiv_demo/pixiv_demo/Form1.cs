using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using pixiv_API;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace pixiv_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            single_mode.Checked = true;
            panel1.Enabled = false;
        }
        OAuth auth;
        pixivAPI pixivAPI;
        private async void button1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            login_panel.Enabled = false;
            progressBar1.Value = 0;
            panel_doing.BringToFront();

            Task<bool> task = Login("username", "password");
            progressBar1.Value += 10;           
            bool result = await task;
            progressBar1.Value = 100;
            Debug.WriteLine(result);
            if (result)
            {
                MessageBox.Show("登陆成功");
                Debug.WriteLine(auth.User.name);
                pixivAPI = new pixivAPI(auth);
                panel1.Enabled = true;
                panel1.BringToFront();
                login_panel.BringToFront();
            }
            else {
                MessageBox.Show("登录失败");
                panel1.BringToFront();
                login_panel.BringToFront();
                login_panel.Enabled = true;
            }
        }
        private async Task<bool> Login(string username,string password)
        {
            auth = new OAuth();
            progressBar1.Value += 20;
            var task=auth.authAsync(username, password);
            progressBar1.Value = 50;
            bool result = await task;
            progressBar1.Value = 70;
            return result;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            progressBar1.Value = 0;
            panel_doing.BringToFront();

            if (textBox1.Text == "") return;
            if (pixivAPI == null) return;
            var task = Task.Run(() => pixivAPI.illust_work_originalPicURL(textBox1.Text));

            progressBar1.Value = 5;

            var urls = await task;

            progressBar1.Value = 20;


            if (urls!=null||urls.Count==0)
            {
                Debug.WriteLine(urls[0]);
                progressBar1.Maximum = urls.Count * 100;
                var task2 = Task.Run(() =>
                {
                    UpdateUI(() =>
                    {
                        foreach (string x in urls)
                        {
                            listBox1.Items.Add(x);
                            if (progressBar1.Value + 100 <= progressBar1.Maximum) progressBar1.Value += 100;
                        }
                    });

                });

                await task2;

            }
            else {
                Debug.WriteLine("Network Failed");
            }
            progressBar1.Value = 100;
            panel1.Enabled = true;
            panel1.BringToFront();
            login_panel.BringToFront();
        }
        private void UpdateUI(Action uiAction)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(uiAction));
            }
            else
            {
                uiAction();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine((string)listBox1.SelectedItem);
            pixivAPI.DownloadFileAsync(null, (string)listBox1.SelectedItem);
        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            string path = await pixivAPI.DownloadFileAsync("temp", (string)listBox1.SelectedItem);

            pictureBox1.Image = Image.FromFile(path);
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }
    }
}

