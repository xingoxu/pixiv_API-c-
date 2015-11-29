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

        private void button1_Click(object sender, EventArgs e)
        {
            OAuth auth = new OAuth(username, password);//please wait for the user has created
            while (auth.user == null)
            {
                Thread.Sleep(1000);
            }
            Debug.WriteLine(auth.user.name);
        }
    }
}

