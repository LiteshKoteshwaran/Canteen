﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public string EmpId { get; set; }
        public string DepartID { get; set; }
        public string LocId { get; set; }
        public string CanteenID { get; set; }
        public string FoodType { get; set; }
        public string OrderQuanty { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string AddDetails { get; set; }
        public string Emp2 { get; set; }
        public string AdminVIPApproval { get; set; }
        public string RequestID { set; get; }
        public string TokenID { set; get; }


        public string EmpDeptName { get; set; }
        public string EmpMobile { get; set; }

        public string SelectedSnacks { get; set; }
        public string SnackQuantity { get; set; }




        ConnectionManger connectionManger = new ConnectionManger();
        bool Result ;

        internal bool InsertionForGuest()
        {
            string str = "insert into GuestDetails values('" + GName + "','" + OrgName + "','" + MobileNo + "','" + TokenID + "','" + RequestID + "')" ; 
            Result = connectionManger.ConnMan(str);
            return Result;
        }
        internal bool RequestForm()
        {
            string str = "insert into Request values('" + RequestID + "','" + EmpId  + "','" + DepartID + "','" + LocId + "','" + CanteenID + "','" + FoodType + "','" + OrderQuanty + "','" + FromDate + "','" + ToDate + "','" + AddDetails + "')";
            return Result = connectionManger.ConnMan(str);
        }
        internal bool AdminIsApproved()
        {
            string str = "update Request set AdminIsApproved = false where RequestId = '"+RequestID +"'";
            return Result = connectionManger.ConnMan(str);
        }
    }
}