using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangTinThueTro.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public const string connectionStrHTDN = "Data Source=LETUAN;Initial Catalog=BanDongHo;User ID=HTDN;Pwd=123456;";
        public const string connectionStrHTRS = "Data Source=LETUAN;Initial Catalog=master;User ID=HTRS;Pwd=123456;";
        public const string connectionStrNhanVien = "Data Source=LETUAN;Initial Catalog=BanDongHo;User ID=BanDongHoNhanVien;Pwd=123456;";
        public const string connectionStrKhachHang = "Data Source=LETUAN;Initial Catalog=BanDongHo;User ID=BanDongHoKhachHang;Pwd=123456;";
        public static string connectionStr = "";

        private SqlConnection connection;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }
        // Thay đổi chuổi kết nối
        public void SetConnectionStr(string dataSource, string userId, string pwd)
        {
            connectionStr = "Data Source=THANHTAN;Initial Catalog=BanDongHo;User ID=" + userId + ";Pwd=" + pwd + ";";
            connection = new SqlConnection(connectionStr);
        }
        // Thay đổi chuổi kết nối thành mặc định (hỗ trợ đăng nhập)
        public void SetConnectionStrDefault()
        {
            connectionStr = connectionStrHTDN;
            connection = new SqlConnection(connectionStr);
        }
        public void SetConnectionStrRestore()
        {
            connection.Close();
            connectionStr = connectionStrHTRS;
            connection = new SqlConnection(connectionStr);
        }
        public void SetConnectionStrNhanVien()
        {
            connection.Close();
            connectionStr = connectionStrNhanVien;
            connection = new SqlConnection(connectionStr);
        }
        public void SetConnectionStrKhachHang()
        {
            connection.Close();
            connectionStr = connectionStrKhachHang;
            connection = new SqlConnection(connectionStr);
        }
        // Thực thi query trả về datatable
        public DataTable ExecuteQuerry(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            // Format lại query: thay các từ có chứa @ bằng tham số
            SqlCommand command = new SqlCommand(query, connection);
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string str in listPara)
                {
                    if (str.Contains('@'))
                    {
                        command.Parameters.AddWithValue(str, parameter[i]);
                        i++;
                    }
                }
            }
            // Thực hiện lấy dữ liệu từ db
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return data;
        }
        // Thực thi query
        public int ExecuteNonQuerry(string query, object[] parameter = null)
        {
            int data = 0;
            // Format lại query: thay các từ có chứa @ bằng tham số
            SqlCommand command = new SqlCommand(query, connection);
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string str in listPara)
                {
                    if (str.Contains('@'))
                    {
                        command.Parameters.AddWithValue(str, parameter[i]);
                        i++;
                    }
                }
            }
            // Thực hiện lấy dữ liệu từ db
            try
            {
                connection.Open();
                data = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return data;
        }
        // Thực thi query trả về datareader
        public SqlDataReader ExecuteSqlDataReader(String query, object[] parameter = null)
        {
            SqlDataReader myReader = null;
            // Format lại query: thay các từ có chứa @ bằng tham số
            SqlCommand command = new SqlCommand(query, connection);
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string str in listPara)
                {
                    if (str.Contains('@'))
                    {
                        command.Parameters.AddWithValue(str, parameter[i]);
                        i++;
                    }
                }
            }
            // Thực hiện lấy dữ liệu từ db
            try
            {
                myReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
            return myReader;
        }
    }
}
