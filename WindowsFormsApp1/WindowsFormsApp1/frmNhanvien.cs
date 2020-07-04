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
   
    
    public partial class frmNhanvien : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command;
        public string ConnectionSTR = @"Data Source=HUY-PC\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        SqlConnection connection;
        DataTable table = new DataTable();

        public frmNhanvien()
        {
            InitializeComponent();
            //DataTable tblNV; //Lưu dữ liệu bảng nhân viên
            LoadDanhSachNhanVien();
            cbgioitinh.Items.Add("Nam");
            cbgioitinh.Items.Add("Nữ");
            cbgioitinh.Items.Add("giới tính khác");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtManhanvien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            


            LoadDanhSachNhanVien();
            connection = new SqlConnection();
            connection.Open();
            loadata();
            
            
        }
        public void loadata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select *from QuanLyBanHang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;

        }



        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv.CurrentRow.Index;
            txtManhanvien.Text = dgv.Rows[i].Cells[0].Value.ToString();
            txtTennhanvien.Text = dgv.Rows[i].Cells[1].Value.ToString();
            cbgioitinh.Text=dgv.Rows[i].Cells[2].Value.ToString();
            
            txtDiachi.Text = dgv.Rows[i].Cells[3].Value.ToString();
            mskDienthoai.Text = dgv.Rows[i].Cells[4].Value.ToString();
            mskNgaysinh.Text = dgv.Rows[i].Cells[5].Value.ToString();
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManhanvien.Focus();
                return;
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtManhanvien.Enabled = true;
            txtManhanvien.Focus();
            ResetValues();
            


        }
        

        private void BtnSua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE tblNhanvien SET  Tennhanvien =N'" + txtTennhanvien.Text.Trim().ToString() +
                    "',Dienthoai='" + mskDienthoai.Text.ToString() +
                    "',Diachi = N'" + txtDiachi.Text.Trim().ToString() + "',Gioitinh=N'" +cbgioitinh.Text+ "',Ngaysinh='" + mskNgaysinh.Text +
                    "' WHERE Manhanvien =N'" + txtManhanvien.Text + "'";
            dgv.DataSource = Functions.Instance.ExcuteQuery(query);
            // loadata();
            LoadDanhSachNhanVien();
           
            if (txtManhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            ResetValues();
        }
        private void ResetValues()
        {
            txtManhanvien.Text = "";
            txtTennhanvien.Text = "";
            cbgioitinh.Text = "";
            txtDiachi.Text = "";
            mskNgaysinh.Text = "";
            mskDienthoai.Text = "";
        }


        private void BtnBoqua_Click(object sender, EventArgs e)
        {
            
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtManhanvien.Enabled = false;
            
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string query =  "DELETE tblNhanvien WHERE Manhanvien =N'" + txtManhanvien.Text + "'";

            // loadata();

            if (MessageBox.Show("Bạn có muốn xóa không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                
                dgv.DataSource = Functions.Instance.ExcuteQuery(query);
                LoadDanhSachNhanVien();
            }

            ResetValues();


        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
        void LoadDanhSachNhanVien()
        {
            string query = "select * from dbo.tblNhanvien";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DataSource = Functions.Instance.ExcuteQuery(query);
        }
       

        private void TxtTennhanvien_TextChanged(object sender, EventArgs e)
        {

       }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO tblNhanvien(Manhanvien,Tennhanvien,Gioitinh, Diachi,Dienthoai, Ngaysinh) VALUES (N'" + txtManhanvien.Text.Trim() + "',N'" + txtTennhanvien.Text.Trim() + "',N'" + cbgioitinh.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "','" + mskDienthoai.Text + "','" + mskNgaysinh.Text + "')";
            dgv.DataSource = Functions.Instance.ExcuteQuery(query);
            // loadata();
            LoadDanhSachNhanVien();
            if (txtManhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManhanvien.Focus();
                return;
            }
            if (txtTennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTennhanvien.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtManhanvien.Enabled = false;
            ResetValues();
        }

        private void Cbgioitinh_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void Cbgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
