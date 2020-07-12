using QuanLyBanHang.Class;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class thongKeDoanhThu : Form
    {
        public thongKeDoanhThu()
        {
            InitializeComponent();
            //loadthongke();
        }

        private void thongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyBanHangDataSet.doanhThu' table. You can move, or remove it, as needed.




        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            System.Drawing.Rectangle rc = ClientRectangle;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTimHDBan timHDBan = new frmTimHDBan();
            timHDBan.Show();
        }
        void loadthongke()
        {
            String sql = "select *from dbo.hoaDon";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);

        }
        void loadthongke1()
        {
            String sql = "select *from dbo.hoaDon1";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = Functions.Instance.ExcuteQuery(sql);
        }

        private void btnreport_Click(object sender, EventArgs e)
        {

            
            if (dataGridView1.RowCount > 0)
            {
                //khoi tao excel
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
               // app.Application.Workbooks.Add(Type.Missing);
                //khoi tao workbook
                Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
                // khoi tao worksheet
                Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                app.Visible = true;

                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                    worksheet.Cells[dataGridView1.RowCount + 3, 3] = "Total is :";
                    worksheet.Cells[dataGridView1.RowCount + 3, 4] = "=SUM(C1:C100)";
                    //worksheet.Cells[ 1, 4] = "Bao cao doanh thu quy I";

                }
                worksheet.Columns.ColumnWidth=25; 
            }
            MessageBox.Show("Xuất báo cáo thành công");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadthongke();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadthongke1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }

}

