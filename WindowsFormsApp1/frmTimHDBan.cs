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
    public partial class frmTimHDBan : Form
    {
        public frmTimHDBan()
        {
            InitializeComponent();
           // loadtimkiemhoadon();
           // loaddanhsachban();
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan.Focus();
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
        void loadtimkiemhoadon()
        {
            string query = "SELECT* FROM dbo.hoaDon";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(query);
        }

        private void BtnTimkiem_Click(object sender, EventArgs e)
        {
            
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "")  &&
              
               (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM hoaDon WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND [Số HĐ] Like N'%" + txtMaHDBan.Text + "%'";
           // if (txtThang.Text != "")
                //sql = sql + " AND NgayLap =" + txtThang.Text;
            
            if (txtManhanvien.Text != "")
                sql = sql + " AND [Mã Nhân Viên] Like N'%" + txtManhanvien.Text + "%'";

            if (txtThang.Text != "")
                sql = sql + " AND [Ngày Lập] Like N'%" + txtThang.Text + "%'";

            if (txtTongtien.Text != "")
                sql = sql + " AND [Tổng Tiền] <=" + txtTongtien.Text;
           loadtimkiemhoadon();
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
            ResetValues();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaHDBan.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtThang.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        
            txtManhanvien.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            
            txtTongtien.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

        }

        private void BtnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dataGridView1.DataSource = null;
        }

        private void TxtTongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn xác nhận lưu và đóng","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           loadtimkiemhoadon();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql;
            String query;
            query = "DELETE from hoaDon WHERE [Số HĐ] =N'" + txtMaHDBan.Text + "' ";
            sql = "DELETE from hoaDon1 WHERE [Số HĐ] =N'" + txtMaHDBan.Text + "' ";
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(query);

            loadtimkiemhoadon();
            loaddanhsachban();
            ResetValues();
        }
        void loaddanhsachban()
        {
            string sql = "select *from dbo.hoaDon1";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loaddanhsachban();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadtimkiemhoadon();
        }
    }
}
