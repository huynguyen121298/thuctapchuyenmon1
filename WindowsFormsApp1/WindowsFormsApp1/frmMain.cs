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
namespace WindowsFormsApp1
{
    public partial class frmbookFood : Form
    {
        public frmbookFood()
        {
            InitializeComponent();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void MnuNhanvien_Click(object sender, EventArgs e)
        {
            frmNhanvien frmnv = new frmNhanvien();
            frmnv.Show();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MnuKhachhang_Click(object sender, EventArgs e)
        {
            frmDMKhachhang frmkhachhang = new frmDMKhachhang();
            frmkhachhang.Show();

        }

        private void HàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMHang frmhang = new frmDMHang();
            frmhang.Show();
        }

        private void KháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMKhachhang frmkhachhang = new frmDMKhachhang();
            frmkhachhang.Show();
        }

        private void MnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn xác nhận đóng ứng dụng không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void KháchHàngToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void TìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmthd = new frmTimHDBan();
            frmthd.Show();
        }

        private void MnuHoadonban_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmthd = new frmTimHDBan();
            frmthd.Show();
        }

        private void HóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmthd = new frmTimHDBan();
            frmthd.Show();
        }

        private void HóaĐơnToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmTimHDBan frmthd = new frmTimHDBan();
            frmthd.Show();
        }

        private void hàngTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMHang hang = new frmDMHang();
            hang.Show();
        }
    }
}
