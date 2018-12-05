using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final
{
    public class ConnectionManger
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string Query { get; set; }
        public string ManagerEmail { get; set; }
        public string EmpPassword { get; set; }

        internal bool ConnMan(string str)
        {

            bool isSuccess = true;
            using (var conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = str;
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected < 1)
                    {
                        throw new Exception("Could not process the data");
                    }

                }
                catch (Exception ex)
                {
                    isSuccess = false;
                }
                finally
                {
                    conn.Close();
                }
                return isSuccess;
            }
        }
        


        internal void ForManagerEmail(string str)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(str))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            ManagerEmail = sdr["Email"].ToString();
                            //Password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
        }
        internal void ForEmpEmail(string str)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(str))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            EmpPassword = sdr["EmpPassword"].ToString();
                        }
                    }
                    con.Close();
                }
            }
        }
    }
    
}