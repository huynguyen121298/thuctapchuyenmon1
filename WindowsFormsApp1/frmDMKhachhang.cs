using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using QuanLyBanHang.Class;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    
    public partial class frmDMKhachhang : Form
    {
        public frmDMKhachhang()
        {
            InitializeComponent();
            LoadDanhSachKhachHang();
        }

        private void FrmDMKhachhang_Load(object sender, EventArgs e)
        {
            //txtMakhach.Enabled = false;
            //btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMakhach.Enabled = false;
            btnLuu.Enabled = false;
            
        }
       

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            int i;
            i = DataGridView.CurrentRow.Index;
            txtMakhach.Text = DataGridView.Rows[i].Cells[0].Value.ToString();
            txtTenkhach.Text = DataGridView.Rows[i].Cells[1].Value.ToString();
            txtDiachi.Text = DataGridView.Rows[i].Cells[2].Value.ToString();
            mskDienthoai.Text = DataGridView.Rows[i].Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }
        private void LoadDanhSachKhachHang()
        {
            string query = "select * from dbo.tblKhach";
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            ResetValues();
            txtMakhach.Enabled = true;
            txtMakhach.Focus();
        }
        private void ResetValues()
        {
            txtMakhach.Text = "";
            txtTenkhach.Text = "";
            txtDiachi.Text = "";
            mskDienthoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMakhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMakhach.Focus();
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDienthoai.Focus();
                return;
            }
            string query;
            query = "INSERT INTO tblKhach VALUES (N'" + DataGridCell.Equals(txtDiachi,txtMakhach) +
               "',N'" + txtTenkhach.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "',N'" + mskDienthoai.Text + "')";
            DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
            LoadDanhSachKhachHang();



            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMakhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenkhach.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskDienthoai.Focus();
                return;
            }
            string query = "UPDATE tblKhach SET TenKhach=N'" + txtTenkhach.Text.Trim().ToString() + "',Diachi=N'" +
                txtDiachi.Text.Trim().ToString() + "',Dienthoai='" + mskDienthoai.Text.ToString() +
                "' WHERE MaKhach=N'" + txtMakhach.Text + "'";
            DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
            LoadDanhSachKhachHang();
            ResetValues();
            btnBoqua.Enabled = false;
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMakhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string query = "delete from tblKhach where MaKhach= '" + txtMakhach.Text + "'";
            if(MessageBox.Show("Xác nhận xóa","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
                LoadDanhSachKhachHang();
            }
            

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMakhach.Enabled = false;
        }

        private void bntDong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn xác nhận lưu và đóng","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }
        }
        
    }
}
