using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Configuration;

namespace ProjectCaNhan_TranLamHueQuyen
{
    internal class LOPDUNGCHUNG
    {
        public SqlConnection conn;
        public LOPDUNGCHUNG()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TechCare\source\repos\ProjectCaNhan_TranLamHueQuyen\ProjectCaNhan_TranLamHueQuyen\TranLamHueQuyen_5750.mdf;Integrated Security=True";
        }
        public int ThemXoaSua(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;
        }
        public object Scalar(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteScalar();
            conn.Close();
            return kq;
        }
        public DataTable LoadDL(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string GetFieldValues(string sql)
        {
            string ma = "";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    ma = reader.GetValue(0).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Co loi xay ra !!!" + ex);
            }
            finally
            {
                conn.Close();
            }         
            return ma;
        }

    }
}



    
