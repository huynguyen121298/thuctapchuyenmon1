using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class webfb : Form
    {
        private string url;
        public webfb()
        {
            InitializeComponent();
        }
        
        public webfb(string url) : base()
        {
            this.url = url;
        }
        private void webfb_Load(object sender, EventArgs e)
        {
        //    Text = this.url;
        //    webBrowser.Navigate(this.url);
        //    webBrowser1.Update();
        }
    }
}
