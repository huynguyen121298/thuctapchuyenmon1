using DevExpress.DataAccess.DataFederation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public static string quyen;
             
        public Main()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmbookFood frmbook = new frmbookFood();
            frmbook.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (quyen == "Admin")
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("bạn k có quyền");
            }
            if (quyen == "User")
            {
                MessageBox.Show("bạn vui lòng liên hệ để cấp quyền Admin để vào");
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadAcc Acc = new loadAcc();
            Acc.Show();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = ClientRectangle;
            if (rc.IsEmpty)
                return;
            if (rc.Width == 0 || rc.Height == 0)
                return;
            using (LinearGradientBrush brush = new LinearGradientBrush(rc, Color.White, Color.FromArgb(196, 232, 250), 90F))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
            // base.OnPaintBackground(e);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            label12.Text = DateTime.Now.ToLongTimeString();
            label13.Text = DateTime.Now.ToLongDateString();
        }
        private void Form1_Load(object sender, PaintEventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            frmbookFood frmbook = new frmbookFood();
            frmbook.Show();
        }
        

        private void Main_Load(object sender, EventArgs e)
        {
            if (quyen == "User")
            {
                button5.Enabled = false;
                MessageBox.Show("Bạn đang đăng nhập với tư cách là USER");
            }
            if (quyen == "Admin")
            {
                MessageBox.Show("bạn đang đăng nhập với tự cách quản trị viên");
            }
            //linkLabel1.Text = "Click here to get more info.";
            linkLabel1.Links.Add(6, 4, "https://www.facebook.com/topcomngon/");

        }
        int x1 = 700, y1 = 160, a1=1;
        int x2 = 180, y2=160, a2 = 1;

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                panel5.Location = new Point(x, y);
                if (x >= 700)
                {
                    a = -1;

                }
                if (x <= 579)
                {
                    a = 1;
                }

            }
            catch (Exception pnan)
            { }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Program.X = @"";
            new webfb().ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        int x = 579, y = 55, a = 1;
        Random ramdom = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            try
            {
                x2 += a2;
                pictureBox5.Location = new Point(x2, y2);
                if (x2 >= 1200)
                {
                    a2 = -1;

                }
                if (x2 <= 180)
                {
                    a2 = 1;
                }

            }
            catch (Exception ec) 
            { }

            try
            {
                x1 += a1;
                pictureBox4.Location = new Point(x1, y1);
                if (x1 <= 180)
                {
                    a1 = 1;

                }
                if (x1 >= 1200)
                {
                    a1 = -1;
                }

            }
            catch (Exception pnn)
            { }

            

        } 
    }
}
