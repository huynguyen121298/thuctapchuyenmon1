using DevExpress.Utils;
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
    public partial class loadAcc : Form
    {
        Functions fun = new Functions();
        
        public loadAcc()
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

        private void loadAcc_Load(object sender, EventArgs e)
        {
            loaddanhsachacc();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            loaddanhsachacc();
        }
        void loaddanhsachacc()
        {
            string sql;
            sql = "Select *from dbo.UserSystem";
            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.DataSource = fun.ExcuteQuery(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAcc acc = new frmAcc();
            acc.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = dgv1.CurrentRow.Index;
               // string query1 = "delete from tblKhach where MaKhach= '" + txtMakhach.Text + "'";

                string query = "delete from UserSystem where UserName= N'" + dgv1.Rows[i].Cells["UserName"].Value + "'";
                dgv1.DataSource = Functions.Instance.ExcuteQuery(query);
                loaddanhsachacc();

            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int i = dgv1.CurrentRow.Index;
            // string query1 = "delete from tblKhach where MaKhach= '" + txtMakhach.Text + "'";

            string query = "update dbo.UserSystem Set Password= N'" + dgv1.Rows[i].Cells["Password"].Value.ToString() + "',FullName=N'"+dgv1.Rows[i].Cells["FullName"].Value.ToString()+"',Quyen=N'"+dgv1.Rows[i].Cells["Quyen"].Value.ToString()+"' where UserName=N'"+dgv1.Rows[i].Cells["UserName"].Value.ToString()+"'";

            dgv1.DataSource = Functions.Instance.ExcuteQuery(query);
            loaddanhsachacc();
        }

        private void bntDong_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
