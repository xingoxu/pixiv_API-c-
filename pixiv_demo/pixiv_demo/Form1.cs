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
using System.Threading;
using System.Net.Http;
using System.IO;

namespace pixiv_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            token = new CancellationTokenSource();
            single_mode.Checked = true;
            panel1.Enabled = false;
        }
        OAuth auth;
        pixivAPI pixivAPI;
        private async void button1_Click(object sender, EventArgs e)
        {
            string username = "username";
            string password = "password";
            panel1.Enabled = false;
            login_panel.Enabled = false;
            progressBar1.Value = 0;
            panel_doing.BringToFront();
            auth = new OAuth();
            progressBar1.Value = 20;
            var task = auth.authAsync(username, password, token);
            progressBar1.Value = 50;
            bool result = false;
            try {
                result = await task;       
            }
            catch
            {
                panel1.BringToFront();
                login_panel.BringToFront();
                login_panel.Enabled = true;
                return;
            }
            progressBar1.Value = 100;
            if (result)
            {
                MessageBox.Show("登陆成功");
                Debug.WriteLine(auth.User.name);
                pixivAPI = new pixivAPI(auth);
                panel1.Enabled = true;
                panel1.BringToFront();
                login_panel.BringToFront();
                return;
            }

            MessageBox.Show("登录失败");
            panel1.BringToFront();
            login_panel.BringToFront();
            login_panel.Enabled = true;

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || pixivAPI == null) return;

            panel1.Enabled = false;
            progressBar1.Value = 0;
            panel_doing.BringToFront();

            Task<List<string>> task = null;
            if(single_mode.Checked)
            task = Task.Run(() => { return pixivAPI.illust_work_originalPicURL(textBox1.Text); }, token.Token);
            else if (my_favourite_mode.Checked)
            
                task = Task.Run(() =>
                {
                    var json = pixivAPI.my_favourite_works(1, 10, true);
                    if (json == null) return null;

                    List<string> result = new List<string>();
                    foreach(JObject response in json.Value<JArray>("response"))
                    {
                        if (response["work"] == null) continue;
                        if ((response["work"]["age_limit"].Value<string>()).Equals("r18")) continue;
                        result.Add(response["work"]["image_urls"]["large"].Value<string>());
                    }

                    return result;
                }, token.Token);
            
            else if (user_id_mode.Checked)
                task = Task.Run(() =>
                {
                    var json = pixivAPI.user_works(textBox1.Text,1, 10);
                    if (json == null) return null;

                    List<string> result = new List<string>();
                    foreach (JObject response in json.Value<JArray>("response"))
                    {
                        if (response["id"] == null) continue;
                        if ((response["age_limit"].Value<string>()).Equals("r18")) continue;
                        result.Add(response["image_urls"]["large"].Value<string>());
                    }

                    return result;
                }, token.Token);


            if (task == null) return;

            progressBar1.Value = 5;
            List<string> urls = null;
            try {
                urls = await task;
            }
            catch
            {
                progressBar1.Value = 100;
                panel1.Enabled = true;
                panel1.BringToFront();
                login_panel.BringToFront();
                return;
            }

            progressBar1.Value = 20;


            if (urls!=null&&urls.Count!=0)
            {
                Debug.WriteLine(urls[0]);
                listBox1.Items.Clear();
                progressBar1.Maximum = urls.Count * 100;
                var task2 = Task.Factory.StartNew(() =>
                {
                    UpdateUI(() =>
                    {
                        foreach (string x in urls)
                        {
                            listBox1.Items.Add(x);
                            if (progressBar1.Value + 100 <= progressBar1.Maximum) progressBar1.Value += 100;
                        }
                    });
                }, token.Token);

                try
                {
                    await task2;
                }
                catch
                { }
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
        private async void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            progressBar1.Value = 0;
            panel_doing.BringToFront();

            try {
                await DownloadFileAsync(null, (string)listBox1.SelectedItem, null, token);
            }
            catch
            {

            }

            panel1.Enabled = true;
            panel1.BringToFront();
            login_panel.BringToFront();

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            cancel_button_Click(null, null);
            string url = (string)listBox1.SelectedItem;

            if (url == null || url.Equals("")) return;
            if (thread != null && thread.IsAlive)
            {
                try { thread.Abort(); }
                catch
                {
                    cancelbuttonicon.Visible = false;
                    loadingIcon.Visible = false;
                }
            }

            cancelbuttonicon.Visible = true;
            loadingIcon.Visible = true;

            thread = new Thread(() =>
            {
                string path = DownloadFileAsync("temp", url).Result;
                UpdateUI(() =>
                {
                    cancelbuttonicon.Visible = false;
                    loadingIcon.Visible = false;
                    if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                    pictureBox1.Image = Image.FromFile(path);
                });
            });
            thread.Start();
        }
        Thread thread;
        CancellationTokenSource token;
        private void cancel_button_Click(object sender, EventArgs e)
        {
            token.Cancel();
            token.Dispose();
            token = new CancellationTokenSource();
            if (thread != null && thread.IsAlive)
            {
                try { thread.Abort(); }
                catch
                {

                }
                cancelbuttonicon.Visible = false;
                loadingIcon.Visible = false;
            }
        }
        /// <summary>
        /// rewrite the api's downloadfile method with ui exchange
        /// </summary>
        /// <param name="strPathName"></param>
        /// <param name="strUrl"></param>
        /// <param name="header"></param>
        /// <param name="tokensource"></param>
        /// <returns></returns>
        public async Task<string> DownloadFileAsync(string strPathName, string strUrl, Dictionary<string, object> header = null, CancellationTokenSource tokensource = null)
        {
            FileStream FStream = null;
            try
            {
                var task = auth.HttpGetStreamAsync(header, strUrl, tokensource);
                //打开上次下载的文件或新建文件
                int CompletedLength = 0;//记录已完成的大小 
                int progress = 0;//进度
                #region get filename
                string filename = null;

                if (filename != null) filename.Trim(' ');

                if (filename == null || filename.Equals(""))
                {
                    string[] split = strUrl.Split('/');
                    filename = split[split.Length - 1];
                }
                #endregion

                string fileRoute = "";
                if (strPathName == null) fileRoute = filename;
                else {
                    fileRoute = strPathName + '/' + filename;
                    if (!Directory.Exists(strPathName)) Directory.CreateDirectory(strPathName);
                }
                if (File.Exists(fileRoute)) File.Delete(fileRoute);
                FStream = new FileStream(fileRoute, FileMode.Create);

                byte[] btContent = new byte[1024];

                Stream myStream = await task;                 


                if (tokensource != null)
                {
                    await Task.Run(() =>
                    {
                        while ((CompletedLength = myStream.Read(btContent, 0, 1024)) > 0)
                        {
                            FStream.Write(btContent, 0, CompletedLength);
                            progress += CompletedLength;
                            UpdateUI(() =>
                            {
                                progress_label.Visible = true;
                                progress_label.Text = ((double)progress / 1024.0).ToString("f2") + "K";
                            });
                        }
                    }, tokensource.Token);
                }
                else {
                    await Task.Run(() =>
                    {
                        while ((CompletedLength = myStream.Read(btContent, 0, 1024)) > 0)
                        {
                            FStream.Write(btContent, 0, CompletedLength);
                            progress += CompletedLength;
                            UpdateUI(() =>
                            {
                                progress_label.Visible = true;
                                progress_label.Text = ((double)progress / 1024.0).ToString("f2") + "K";
                            });
                        }
                    });
                }
                UpdateUI(() =>
                {
                    progress_label.Visible = false;
                });
                FStream.Close();
                myStream.Close();
                return fileRoute;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                if (FStream != null)
                {
                    FStream.Close();
                    FStream.Dispose();
                }
                throw e;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            if (Directory.Exists("temp")) Directory.Delete("temp", true);
        }

    }
}

