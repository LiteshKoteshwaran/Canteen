using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final.Admin
{
    public class RolesDAL
    {
        public string Name { get; set; }
        public static string ConnectionString { get; set; }
        public RolesDAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public DataSet GetRoles()
        {
            string Query = "select Id,Name from AspNetRoles";
            SQLManager manager = new SQLManager();
            return manager.GetDataSet(Query);
        }
        public bool UpdateRole(Role role)
        {
            bool isSuccess;
            List<ProcParameters> procParams = new List<ProcParameters>();
            procParams.Add(new ProcParameters("@Id", role.Id, DbType.String, ParameterDirection.Input));
            procParams.Add(new ProcParameters("@Name", role.Name, DbType.String, ParameterDirection.Input));
            SQLManager manager = new SQLManager();
            isSuccess = manager.UpdateRecord("UpdateRoles", procParams);
            return isSuccess;
        }
        public bool deleteRole(Role role)
        {
            bool isSuccess;
            List<ProcParameters> procParams = new List<ProcParameters>();
            procParams.Add(new ProcParameters("@Id", role.Id, DbType.Int32, ParameterDirection.Input));
            SQLManager manager = new SQLManager();
            isSuccess = manager.deleteRecord("DeleteRoles", procParams);
            return isSuccess;
        }
        public DataSet GetMonthlyReport(int Month)
        {
            List<ProcParameters> procParams = new List<ProcParameters>();
            procParams.Add(new ProcParameters("@month", Month.ToString(), DbType.Int32, ParameterDirection.Input));
            SQLManager manager = new SQLManager();
            return manager.GetDataSet("GetMonthlyReport", procParams);

        }
        public DataSet GetDeptMonthlyReport()
        {
            SQLManager manager = new SQLManager();
            return manager.GetDataSet("GetDepartmentWiseMonthlyReport", true);
        }
        public void InsertRole(string roleId, string roleName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter dataAdapter;
                var sqlQuery = "select * from AspNetRoles";
                dataAdapter = new SqlDataAdapter(sqlQuery, conn);
                dataAdapter.Fill(dataSet);
                var newRow = dataSet.Tables[0].NewRow();
                newRow["Id"] = roleId;
                newRow["Name"] = roleName;
                dataSet.Tables[0].Rows.Add(newRow);
                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet);
            }
        }
    }
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
