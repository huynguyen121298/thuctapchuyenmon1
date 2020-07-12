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
using System.Windows.Documents;
using QuanLyBanHang.Class;
using System.CodeDom;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class frmbookFood : Form
    {
        public DataTable tbOrder;

        public frmbookFood()
        {
            InitializeComponent();
            loadcombo();
            //showBill();

            tbOrder = new DataTable();
            
            showBill();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }
        private void showBill()
        {
            int tongtien = 0;
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                tongtien += int.Parse(dataGridView2.Rows[i].Cells["thanhtien"].Value.ToString());
            }
            textBox2.Text = tongtien.ToString();


        }



        
        private void Btn_Click(object sender, EventArgs e)
        {
            //int tableID=(sender as Table)
            //ShowBill(tableID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            string mon = bt.Text;
            object[] findTheseVals = new object[1];
            findTheseVals[0] = mon;

            DataRow foundRow = tbOrder.Rows.Find(findTheseVals);
            if (foundRow != null)
            {
                //foundRow["Số lượng"] = int.Parse(foundRow["Số lượng"].ToString()) + 1;
                //foundRow["Thành tiền"] = int.Parse(foundRow["Thành tiền"].ToString())+20000;
                foundRow["SoLuong"] = int.Parse(foundRow["SoLuong"].ToString()) + 1;
                foundRow["ThanhTien"] = int.Parse(foundRow["ThanhTien"].ToString()) + 25000;
               
            }
            else
            {
                DataRow t = tbOrder.NewRow();

                //t["Món ăn"] = mon;
                //t["Số lượng"] = 1;
                //t["Thành tiền"] = 20000;
                //tbOrder.Rows.Add(t);
                t["MonAn"] = mon;
                t["SoLuong"] = 1;
                t["ThanhTien"] = 25000;
                tbOrder.Rows.Add(t);
                
                dataGridView2.DataSource = tbOrder;
               
            }
            showBill();

        }
        


        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView2.CurrentCell.RowIndex;
            tbOrder.Rows[rowindex].Delete();
            showBill();

        }

        private void btnXoaHetMon_Click(object sender, EventArgs e)
        {
            tbOrder.Clear();
            showBill();
        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            int d = dataGridView2.Rows.Count;
            if (d == 1 || comboBox1.Text.ToString() == "")
            {
                MessageBox.Show("Bạn chưa chọn món or chưa chọn bàn");
            }
            else

            {
                themdl();

                MessageBox.Show("Bạn order thành công");
            }
            comboBox1.Items.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
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

        public void frmbookFood_Load(object sender, EventArgs e)

        {
            

            DataColumn column = tbOrder.Columns.Add("MonAn");
            tbOrder.Columns.Add("SoLuong", System.Type.GetType("System.Int32"));
            tbOrder.Columns.Add("ThanhTien", System.Type.GetType("System.Int32"));
            DataColumn[] keys = new DataColumn[1];
            keys[0] = column;
            tbOrder.PrimaryKey = keys;

            dataGridView2.DataSource = tbOrder;
        }

      
        private void button9_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            string mon = bt.Text;

            object[] tien = new object[2];
            object[] findTheseVals = new object[1];
            tien[1] = mon;

            findTheseVals[0] = mon;

            DataRow foundRow = tbOrder.Rows.Find(findTheseVals);
            if (foundRow != null)
            {
                //foundRow["Số lượng"] = int.Parse(foundRow["Số lượng"].ToString()) + 1;
                // foundRow["Thành tiền"] = int.Parse(foundRow["Thành tiền"].ToString()) + 10000;
                foundRow["SoLuong"] = int.Parse(foundRow["SoLuong"].ToString()) + 1;
                foundRow["ThanhTien"] = int.Parse(foundRow["ThanhTien"].ToString()) + 12000;
            }
            else
            {
                DataRow t = tbOrder.NewRow();

                //t["Món ăn"] = mon;
                //t["Số lượng"] = 1;
                //t["Thành tiền"] = 10000;
                //tbOrder.Rows.Add(t);
                t["MonAn"] = mon;
                t["SoLuong"] = 1;
                t["ThanhTien"] = 12000;
                tbOrder.Rows.Add(t);


                dataGridView2.DataSource = tbOrder;
            }
            showBill();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            string mon = bt.Text;

           // object[] tien = new object[2];
            object[] findTheseVals = new object[1];
           // tien[1] = mon;

            findTheseVals[0] = mon;

            DataRow foundRow = tbOrder.Rows.Find(findTheseVals);
            if (foundRow != null)
            {
                foundRow["SoLuong"] = int.Parse(foundRow["SoLuong"].ToString()) + 1;
                foundRow["ThanhTien"] = int.Parse(foundRow["ThanhTien"].ToString()) + 2000;
            }
            else
            {
                DataRow t = tbOrder.NewRow();

               t["MonAn"] = mon;
               t["SoLuong"] = 1;
               t["ThanhTien"] = 2000;
               tbOrder.Rows.Add(t);


                dataGridView2.DataSource = tbOrder;
            }
            showBill();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            tbOrder.Clear();
        }
        private void loadDanhSachBanAn()
        {

            //string sql = " select *from dbo.Banan ";
            //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView2.DataSource = Functions.Instance.ExcuteQuery(sql);
        }
        
        public void themdl()
        {
            string query;
            try
            {
                //Functions fun = new Functions();
                //SqlCommand command = new SqlCommand();
                // command.Connection = fun.command;
                for (int i = 0; i < dataGridView2.RowCount-1; i++)
                {

                    Console.WriteLine(dataGridView2.Rows[i].Cells["monan"].Value.ToString());
                    query = "INSERT INTO dbo.Banan VALUES (N'" + dataGridView2.Rows[i].Cells["MonAn"].Value + "'," + dataGridView2.Rows[i].Cells["SoLuong"].Value + "," + dataGridView2.Rows[i].Cells["ThanhTien"].Value + ",N'" + comboBox1.SelectedItem.ToString() + "'," + textBox2.Text.Trim() + ",N'" + textBox3.Text.Trim() + "',N'" + comboBox2.Text.Trim().ToString()+ "')";
                    int a = Functions.Instance.ExcuteNonQuery(query);
                }
                
            }
            catch
            {
               // Functions.connection.Close();
            }
            dataGridView2.DataSource = null;
        }
        

      
        private void button11_Click(object sender, EventArgs e)
        {
            DanhSachBanAn danhSachBan = new DanhSachBanAn();
            danhSachBan.Show();
            this.Hide();
        }

     
        private void button4_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            string mon = bt.Text;

            // object[] tien = new object[2];
            object[] findTheseVals = new object[1];
            // tien[1] = mon;

            findTheseVals[0] = mon;

            DataRow foundRow = tbOrder.Rows.Find(findTheseVals);
            if (foundRow != null)
            {
                foundRow["SoLuong"] = int.Parse(foundRow["SoLuong"].ToString()) + 1;
                foundRow["ThanhTien"] = int.Parse(foundRow["ThanhTien"].ToString()) + 15000;
            }
            else
            {
                DataRow t = tbOrder.NewRow();

                t["MonAn"] = mon;
                t["SoLuong"] = 1;
                t["ThanhTien"] = 15000;
                tbOrder.Rows.Add(t);


                dataGridView2.DataSource = tbOrder;
            }
            showBill();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void loadcombo()
        {
            comboBox1.Items.Add("Bàn 1");
            comboBox1.Items.Add("Bàn 2");
            comboBox1.Items.Add("Bàn 3");
            comboBox1.Items.Add("Bàn 4");
            comboBox1.Items.Add("Bàn 5");
            comboBox1.Items.Add("Bàn 6");
            comboBox1.Items.Add("Bàn 7");
            comboBox1.Items.Add("Bàn 8");
            comboBox1.Items.Add("Bàn 9");
            comboBox1.Items.Add("Bàn 10");
            SqlConnection connection = new SqlConnection(@"Data Source=HUY-PC\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True");

            DataTable dt = new DataTable();
            connection.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select Manhanvien From dbo.tblNhanvien", connection);
                da.Fill(dt);
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.ToString());
            }

            try
            {
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Manhanvien";
                comboBox2.ValueMember = "Manhanvien";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi load dữ liệu!\n", ex.ToString());
            }

        }
    }
}
