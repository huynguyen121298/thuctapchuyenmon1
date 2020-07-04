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
using System.IO;


namespace WindowsFormsApp1
{
   
    public partial class frmDMHang : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
       // SqlCommand command;
        public string ConnectionSTR = @"Data Source=HUY-PC\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        SqlConnection connection;
        DataTable table = new DataTable();
        //public DataTable tblH { get; private set; }
        private Functions func;

        public frmDMHang()
        {
            InitializeComponent();
            //DataTable tblH; //Bảng hàng
            LoadDanhSachHang();
            //loadata();
            func = new Functions();
 
           
        }
        
        
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
           


            sql = "INSERT INTO tblHang(Mahang,Tenhang,Soluong,Ngaynhaphang,Dongianhap,Ghichu,Soluongdaban,Ngayban,Soluongdu) VALUES (N'"
                 + txtMahang.Text.Trim() + "',N'" + txtTenhang.Text.Trim() +
                 "'," + txtSoluong.Text.Trim() + ",N'"+txtngayNhap.Text.Trim()+"',"+txtgianhap.Text.Trim()+",N'" + txtGhichu.Text.Trim() + "',N'" + txtsoLuongBan.Text +
                 "',N'"+txtngayBan.Text.Trim()+"',"+txtsoLuongDu.Text.Trim()+")";

            DataGridView.DataSource = Functions.Instance.ExcuteQuery(sql);
            LoadDanhSachHang();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMahang.Enabled = false;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void frmDMHang_Load(object sender, EventArgs e)
        {
            //txtMahang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = true;
            //button1.Enabled = false;
            LoadDanhSachHang();
            connection = new SqlConnection();
            connection.Open();
            loadata();


        }
        public void loadata()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select *from tblHang", connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.Fill(dt);
            DataGridView.DataSource = dt;
            connection.Close();

        }
        private void ResetValues()
        {
            txtMahang.Text = "";
            txtTenhang.Text = "";
           // dateTimePicker2.Text = "";
           // dateTimePicker1.Text = "";
            txtsoLuongDu.Text = "";
            
            txtSoluong.Text = "0";
            txtsoLuongBan.Text = "0";
           
            txtSoluong.Enabled = true;
           // txtgianhap.Enabled = false;
            //txtDongiaban.Enabled = false;
            
            txtGhichu.Text = "";
        }
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            int i;
            i = DataGridView.CurrentRow.Index;
            txtMahang.Text = DataGridView.Rows[i].Cells[0].Value.ToString();
            txtTenhang.Text = DataGridView.Rows[i].Cells[1].Value.ToString();
            txtSoluong.Text = DataGridView.Rows[i].Cells[2].Value.ToString();
            //dateTimePicker2.Text = DataGridView.Rows[i].Cells[3].Value.ToString();
            txtngayNhap.Text = DataGridView.Rows[i].Cells[3].Value.ToString();
            txtgianhap.Text = DataGridView.Rows[i].Cells[4].Value.ToString();
            txtGhichu.Text = DataGridView.Rows[i].Cells[5].Value.ToString();
            txtsoLuongBan.Text = DataGridView.Rows[i].Cells[6].Value.ToString();
            //dateTimePicker1.Text = DataGridView.Rows[i].Cells[7].Value.ToString();
            txtngayBan.Text = DataGridView.Rows[i].Cells[7].Value.ToString();
            txtsoLuongDu.Text = DataGridView.Rows[i].Cells[8].Value.ToString();
         
            // sql = "SELECT Anh FROM tblHang WHERE Mahang=N'" + txtMahang.Text + "'";

            //byte[] b =(byte[])DataGridView.Rows[i].Cells[6].Value;
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
          
            //txtMahang.Enabled = true;
            //txtMahang.Focus();
            //txtSoluong.Enabled = true;
            //txtsoLuongBan.Enabled = true;
           
            ResetValues();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query;
            query = "UPDATE tblHang SET Tenhang=N'" + txtTenhang.Text +
                "',Soluong=" + txtSoluong.Text +
                ",Ngaynhaphang=N'"+txtngayNhap.Text+"',Dongianhap = "+txtgianhap.Text+",Ghichu=N'" + txtGhichu.Text + "',Soluongdaban ="+txtsoLuongBan.Text+",Ngayban=N'"+txtngayBan.Text+"',Soluongdu="+txtsoLuongDu.Text+" WHERE Mahang=N'" + txtMahang.Text + "'";
            DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
            LoadDanhSachHang();
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMahang.Focus();
                return;
            }
            if (txtTenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
           
            //ResetValues();

        }
        void LoadDanhSachHang()
        {
            string query = "select * from dbo.tblHang";
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE tblHang WHERE Mahang=N'" + txtMahang.Text + "'";
                DataGridView.DataSource = Functions.Instance.ExcuteQuery(query);
                LoadDanhSachHang();
            }
            ResetValues();

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlgOpen = new OpenFileDialog();
            //dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            //dlgOpen.FilterIndex = 2;
            //dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            //if (dlgOpen.ShowDialog() == DialogResult.OK)
            //{
            //    picAnh.Image = Image.FromFile(dlgOpen.FileName);
            //   // txtAnh.Text = dlgOpen.FileName;
            //}
        }

        private void BtnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            
        }

        private void BtnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMahang.Text == "") && (txtTenhang.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblHang WHERE 1=1";
            if (txtMahang.Text != "")
                sql += " AND Mahang LIKE N'%" + txtMahang.Text + "%'";
            if (txtTenhang.Text != "")
                sql += " AND Tenhang LIKE N'%" + txtTenhang.Text + "%'";
            
            DataGridView.DataSource=Functions.Instance.ExcuteQuery(sql);
            if (DataGridView.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
           // else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //  DataGridView.DataSource = tblH;
            ResetValues();
            txtMahang.Enabled = true;
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn xác nhận lưu và đóng","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void BtnHienthi_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // private void Button1_Click(object sender, EventArgs e)
        //{
        //    //byte[] b = ImageToByteArray(picAnh.Image);
        //    //connection.Open();
        //    //SqlCommand cmd = new SqlCommand("insert into Hang values Anh ", connection);

        //    //cmd.Parameters.Add("@Anh", b);
        //    //cmd.ExecuteNonQuery();
        //    //connection.Close();
        //    byte[] img = func.RetrieveImage();
        //    MemoryStream str = new MemoryStream(img);
        //    picAnh.Image = Image.FromStream(str);
    }
        //byte[] ImageToByteArray (Image img)
        //{
        //    MemoryStream m = new MemoryStream();
        //    img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
        //    return m.ToArray();
        //}

        //private void (object sender, EventArgs e)
        //{
        //    //OpenFileDialog open = new OpenFileDialog();
        //    //if(open.ShowDialog ()==DialogResult.OK)
        //    //{
        //    //    picAnh.Image = Image.FromFile(open.FileName);
        //    //    this.Text = open.FileName;
        //    //}
        //}

        //private void label7_Click(object sender, EventArgs e)
        //{

        //}
    }



