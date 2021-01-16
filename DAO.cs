using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCuoiKy
{
    class DAO
    {
        SqlConnection con = new SqlConnection(@"Data Source=G3-TRUNGMI;Initial Catalog=QLNV_OnCuoiKy;Integrated Security=True");
        public  DataTable loadData()
        {
            string s = "SELECT MaNV, TenNV,PhongBan,ChucVu,Luong FROM dbo.PhongBan,dbo.NhanVien,dbo.ChucVu WHERE ChucVu.MaCV = NhanVien.MaCV AND PhongBan.MaPB = NhanVien.MaPB";
            DataTable dataTable = new DataTable();
            con.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand(s, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                return dataTable = null;
            }
            con.Close();
            return dataTable;
        }

        public Boolean createData(string cmd)
        {
            con.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmd, con);
                sqlCommand.ExecuteNonQuery();                
            }
            catch (Exception)
            {
                return false;
            }
            con.Close();
            return true;
        }

        public DataTable searhData(string cmd)
        {
            DataTable dataTable = new DataTable();
            con.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand(cmd, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                return dataTable = null;
            }
            con.Close();
            return dataTable;
        }
    }
}
