using QuanLyBanHang.Class;
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
    public partial class DanhSachBanAn : Form
    {
        public static string quyen;
        public DanhSachBanAn()
        {
            InitializeComponent();
            loadDanhSachBanAn();
            


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
        private void btnTim_Click(object sender, EventArgs e)
        {
            String sql;
            sql = "SELECT * FROM Banan WHERE 1=1";
            if (txthoaDon.Text != "")
                sql = sql + " AND [Số HĐ] Like N'%" + txthoaDon.Text + "%'";
            loadDanhSachBanAn();
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
        }
        private void loadDanhSachBanAn()
        {
            

            string sql = " select *from Banan ";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmbookFood food = new frmbookFood();
            food.Show();
            this.Hide();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (quyen == "Admin")
            {
                String sql;

                sql = "DELETE from Banan WHERE [Số HĐ] =N'" + txthoaDon.Text + "' ";
                dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
                loadDanhSachBanAn();
                ResetValues();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền xóa,chỉ có Admin mới có quyền");
            }
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtlapHoaDon.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //textBox3.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txthoaDon.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            
            
        }
        private void ResetValues()
        {
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            txthoaDon.Text = "";
            txtPrice.Text = "";
            dateTimePicker1.Text = "";
            txtlapHoaDon.Text = "";


        }

        private void btntimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            loadDanhSachBanAn();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txthoaDon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthoaDon.Focus();
                return;
            }
            if (txtlapHoaDon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlapHoaDon.Focus();
                return;
            }
            if (txtPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return;
            }
            String sql;
            sql = "INSERT INTO dbo.hoaDon VALUES (N'" + txthoaDon.Text.Trim() + "',N'" +
                txtlapHoaDon.Text.Trim() + "'," + txtPrice.Text.Trim() + ",N'" + dateTimePicker1.Text.Trim() + "')";

            int a = Functions.Instance.ExcuteNonQuery(sql);
            MessageBox.Show("Lưu thành công");





            //chonThang chonThang = new chonThang();
            //chonThang.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txthoaDon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthoaDon.Focus();
                return;
            }
            if (txtlapHoaDon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlapHoaDon.Focus();
                return;
            }
            if (txtPrice.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
                return;
            }
            string sql;
            sql = "INSERT INTO dbo.hoaDon1 VALUES (N'" + txthoaDon.Text.Trim() + "',N'" +
                txtlapHoaDon.Text.Trim() + "'," + txtPrice.Text.Trim() + ",N'" + dateTimePicker1.Text.Trim() + "')";

            int a = Functions.Instance.ExcuteNonQuery(sql);
            MessageBox.Show("Lưu thành công");


            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
