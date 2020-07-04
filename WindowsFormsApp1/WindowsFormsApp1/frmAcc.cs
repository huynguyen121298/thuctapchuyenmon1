using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanHang.Class;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class frmAcc : Form
    {
        public frmAcc()
        {
            InitializeComponent();
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


        private void Button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu");
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Đầy đủ họ tên");
                textBox3.Focus();
                return;
            }
            else
            {



                string query = "INSERT INTO UserSystem(UserName,Password,FullName) VALUES (N'" + textBox1.Text.Trim() + "',N'" + textBox2.Text.Trim() + "',N'" + textBox3.Text.Trim() + "')";
                Functions.Instance.ExcuteQuery(query);
                ResetValues();
                MessageBox.Show("Đăng ký thành công");
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
        private void ResetValues()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin lg = new frmLogin();
            lg.Show();
        }
        
    }
}
