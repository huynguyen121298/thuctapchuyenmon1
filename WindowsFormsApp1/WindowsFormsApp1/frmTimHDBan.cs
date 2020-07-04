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


namespace WindowsFormsApp1
{
    public partial class frmTimHDBan : Form
    {
        public frmTimHDBan()
        {
            InitializeComponent();
            loadtimkiemhoadon();
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHDBan.Focus();
        }
        void loadtimkiemhoadon()
        {
            string query = "SELECT* FROM dbo.tblHDBan";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(query);
        }

        private void BtnTimkiem_Click(object sender, EventArgs e)
        {
            
            string sql;
            if ((txtMaHDBan.Text == "") && (txtThang.Text == "")  &&
               (txtManhanvien.Text == "") && (txtMakhach.Text == "") &&
               (txtTongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHDBan WHERE 1=1";
            if (txtMaHDBan.Text != "")
                sql = sql + " AND MaHD Like N'%" + txtMaHDBan.Text + "%'";
           // if (txtThang.Text != "")
                //sql = sql + " AND NgayLap =" + txtThang.Text;
            
            if (txtManhanvien.Text != "")
                sql = sql + " AND Manhanvien Like N'%" + txtManhanvien.Text + "%'";
            if (txtMakhach.Text != "")
                sql = sql + " AND Makhach Like N'%" + txtMakhach.Text + "%'";
            if (txtTongtien.Text != "")
                sql = sql + " AND Tongtien <=" + txtTongtien.Text;
            loadtimkiemhoadon();
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
            ResetValues();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaHDBan.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtThang.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        
            txtManhanvien.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtMakhach.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtTongtien.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();

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
    }
}
