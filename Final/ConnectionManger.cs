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

        string Output;


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
        internal string Select(string str)
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
                            //ManagerEmail
                            Output = sdr["Cost"].ToString();
                            //Password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return Output;
        }
        internal string Selection(string str)
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
                            //ManagerEmail
                            Output = sdr["Email"].ToString();
                            //Password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return Output;
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
            //return Output;
        }

        internal DataSet Fill(string QueryForAutoFilling)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = QueryForAutoFilling;
                DataSet objDs = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter();
                dAdapter.SelectCommand = cmd;
                con.Open();
                dAdapter.Fill(objDs);
                con.Close();
                return objDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string Selection(string str, string str1)
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
                            //ManagerEmail
                            Output = sdr[str1].ToString();
                            //Password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return Output;
        }
    }
}
