﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanHang.Class;


namespace WindowsFormsApp1
{

    public partial class frmLogin : Form
    {
        public bool IsLogin { get; set; }
        public string FullName;
        public frmLogin()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            IsLogin = false;
           // this.Text = "\nxin chào" + FullName;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Rectangle rc = ClientRectangle;
            if (rc.IsEmpty)
                return;
            if (rc.Width == 0 || rc.Height == 0)
                return;
            using (LinearGradientBrush brush = new LinearGradientBrush( rc, Color.White,Color.FromArgb(196,232,250),90F ))
            {
                e.Graphics.FillRectangle(brush, rc);
            }
           // base.OnPaintBackground(e);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn xác nhận hủy bỏ và đóng không?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection( @"Data Source=HUY-PC\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True");
            try
            {
                conn.Open();
                string UserName = textBox1.Text.Trim();
                string Password = textBox2.Text.Trim();
                string sql = "select *from UserSystem where UserName ='" + UserName + "' and Password='" + Password + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    FullName = dta["FullName"].ToString();
                     MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Xin Chào bạn :" +FullName,"Chào mừng đến với DEMO app bán hàng ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmbookFood frm = new frmbookFood();
                    frm.Show();
                    IsLogin = true;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công vui lòng kiểm tra lại tài khoản hoặc mật khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
    }

        private void Button3_Click(object sender, EventArgs e)
        {
            frmAcc a = new frmAcc();
            a.Show();
            this.Hide();
        }
    }
}
