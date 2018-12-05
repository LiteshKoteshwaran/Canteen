using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final.Admin
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
    public class SQLManager
    {
        public static string ConnectionString { get; set; }
        public SQLManager()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        static SQLManager()
        {

        }
        public bool UpdateRecord(string ProcName, List<ProcParameters> ProcParams)
        {
            bool isSucess = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ProcName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (ProcParameters param in ProcParams)
                    {
                        SqlParameter TParam = new SqlParameter(param.Name, param.Value);
                        TParam.Direction = param.Direction;
                        cmd.Parameters.Add(TParam);
                    }
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected < 1) isSucess = false;
                }
            }
            catch (Exception e)
            {
                isSucess = false;
            }
            return isSucess;
        }
        public bool deleteRecord(string ProcName, List<ProcParameters> ProcParams)
        {
            bool isSucess = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ProcName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (ProcParameters param in ProcParams)
                    {
                        SqlParameter TParam = new SqlParameter(param.Name, param.Value);
                        TParam.Direction = param.Direction;
                        cmd.Parameters.Add(TParam);
                    }
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected < 1) isSucess = false;
                }
            }
            catch (Exception e)
            {
                isSucess = false;
            }
            return isSucess;
        }
        public DataSet GetDataSet(string Query)
        {

            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataAdapter sadp = new SqlDataAdapter(cmd);
                sadp.Fill(ds);
            }
            return ds;
        }
        public DataSet GetDataSet(string ProcName, List<ProcParameters> ProcParams)
        {

            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ProcName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (ProcParameters param in ProcParams)

                {

                    SqlParameter TParam = new SqlParameter(param.Name, param.Value);

                    TParam.Direction = param.Direction;

                    cmd.Parameters.Add(TParam);

                }
                SqlDataAdapter sadp = new SqlDataAdapter(cmd);
                sadp.Fill(ds);
            }
            return ds;
        }
        public DataSet GetDataSet(string ProcName, bool isProc)

        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(ProcName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sadp = new SqlDataAdapter(cmd);
                sadp.Fill(ds);
            }

            return ds;

        }
    }
}