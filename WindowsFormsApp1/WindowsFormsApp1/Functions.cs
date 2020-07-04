using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

// Sử dụng đối tượng MessageBox

namespace QuanLyBanHang.Class
{
    public class Functions
    {
        private static Functions instance;
        public static Functions Instance
        {
            get { if (instance == null)
            instance = new Functions();
             return Functions.instance; }
            private set { Functions.instance = value;
            } 
        }
        public string ConnectionSTR = @"Data Source=HUY-PC\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand command;
        
        public DataTable ExcuteQuery(string query,object[] parameter = null)
        {
            DataTable data = new DataTable();
            using(SqlConnection connection = new SqlConnection(ConnectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if(parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@')){
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
       
        public static SqlConnection connection;  //Khai báo đối tượng kết nối        
        public static bool CheckKey(string sql)
         {
          SqlDataAdapter MyData = new SqlDataAdapter(sql, connection);
         DataTable table = new DataTable();
         MyData.Fill(table);
        if (table.Rows.Count > 0)
        return true;
         else return false;
        }
        private static Functions singleton = null;
        public static Functions Singleton
        {
            get
            {
                if (singleton ==null)
                {
                    singleton = new Functions();
                }
                return singleton;
            }
        }

        public void StorePicture(string filename)
        {
            byte[] imageData = null;
            // Read the file into a byte array
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                imageData = new Byte[fs.Length];
                fs.Read(imageData, 0, (int)fs.Length);
            }
            using (SqlConnection conn = new SqlConnection(ConnectionSTR))
            {
                SqlCommand cmd = new SqlCommand("tblHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@filename", filename);
                cmd.Parameters["@filename"].Direction = ParameterDirection.Input;
                cmd.Parameters.Add("@Anh", SqlDbType.Image);
                cmd.Parameters["@Anh"].Direction = ParameterDirection.Input;
                // Store the byte array within the image field
                cmd.Parameters["@Anh"].Value = imageData;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public byte[] RetrieveImage()
        {
            byte[] imageData = null;
            connection.Open();
            SqlCommand cmd = new SqlCommand("select Anh from tblHang", connection);
            // Assume previously established command and connection
            // The command SELECTs the IMAGE column from the table

            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
            {
                reader.Read();
                // Get size of image data – pass null as the byte array parameter
                long bytesize = reader.GetBytes(0, 0, null, 0, 0);
                // Allocate byte array to hold image data
                imageData = new byte[bytesize];
                long bytesread = 0;
                int curpos = 0;
                int chunkSize = 1;
                while (bytesread < bytesize)
                {
                    // chunkSize is an arbitrary application defined value
                    bytesread += reader.GetBytes(0, curpos, imageData, curpos, chunkSize);
                    curpos += chunkSize;
                }
            }
            connection.Close();
            // byte array ‘imageData’ now contains BLOB from database
            return imageData;
        }
    }


}
