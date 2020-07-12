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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDMHang hang = new frmDMHang();
            hang.Show();
         
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

        private void button2_Click(object sender, EventArgs e)
        {
            frmNhanvien nhanvien = new frmNhanvien();
            nhanvien.Show();
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thongKeDoanhThu thongKe = new thongKeDoanhThu();
            thongKe.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmTimHDBan hDBan = new frmTimHDBan();
            hDBan.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmDMKhachhang dMKhachhang = new frmDMKhachhang();
            dMKhachhang.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
