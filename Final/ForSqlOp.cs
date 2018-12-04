using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final
{
    public class ForSqlOp
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public string GName { get; set; }
        public string OrgName { get; set; }
        public string MobileNo { get; set; }
        public string Query { get; set; }
        string Output;
        ConnectionManger connectionManger = new ConnectionManger();
        bool Result;

        public bool InsertionForGuest()
        {
            string RequestID = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 15);
            string Token = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 15);
            string str = "insert into Guest values('" + GName + "','" + OrgName + "','" + MobileNo + "','" + Token + "','" + RequestID + "')";
            Result = connectionManger.ConnMan(str);
            return Result;
        }


}
}