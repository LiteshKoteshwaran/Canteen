using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final
{
    public class ProcParameters
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DbType DataType { get; set; }
        public ParameterDirection Direction { get; set; }

        public ProcParameters(string Name, string Value, DbType DataType, ParameterDirection Direction)
        {
            this.Name = Name;
            this.Value = Value;
            this.DataType = DataType;
            this.Direction = Direction;
        }
    }
    public class ConnectionManger
    {
        static string OutputForProc;
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string Query { get; set; }

        public bool ConnMan(string str)
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
                    //Write exception to log
                    isSuccess = false;
                    //LogFilePath();
                }
                finally
                {
                    conn.Close();
                }
                return isSuccess;
            }
        }
        
    }
    
}