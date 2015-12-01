using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using pixiv_API;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading;

namespace pixiv_demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OAuth auth;
        private void button1_Click(object sender, EventArgs e)
        {
            auth = new OAuth("", "");//please wait for the user has created
            while (auth.User == null)
            {
                Thread.Sleep(100);
            }
            Debug.WriteLine(auth.User.name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pixivAPI = new pixivAPI(auth);
            foreach (string x in pixivAPI.illust_works_original(textBox1.Text))
                Debug.WriteLine(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var pixivAPI = new pixivAPI(auth);
            auth.DownloadFile(null, pixivAPI.illust_works_original(textBox1.Text)[0]);
        }
    }
}

