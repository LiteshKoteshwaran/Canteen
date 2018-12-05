using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;

namespace Final
{
    public partial class CanteenRequestForm : System.Web.UI.Page
    {
        static string RequestID, TokenID;
        ConnectionManger connectionManger;
        string ManagerEmail { set; get; }
        //string Password { set; get; }
        string EmpPassword { set; get; }
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(ConnectionString);
        static string AlertSuccesMessage = "Request has been made";
        static string AlertFailureMessage = "Try again some other time!!!";
        int CountOfGuest = 1;
        static string link= "http://localhost:63020/Admin/VIPRequestFrom"; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                AutoFillForDepart();
                AutoFillLoc();
                AutoFillEmpName();
                txtEmpLoyee.Text = Context.User.Identity.GetUserName();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("S.No"), new DataColumn("GuestName"), new DataColumn("Name"), new DataColumn("MobileNo") });
                ViewState["Guest"] = dt;
                this.BindGrid();
            }
            if (Context.User.IsInRole("HR"))
            {
                TableForHr.Visible = true;
                TableForSnacks.Visible = true;
                AutoFillIteam();
            }
            else
            {
                TableForHr.Visible = false;
                TableForSnacks.Visible = false;
            }
            if(Session["Result"]== "Accepted")
                Response.Write("<script>alert('" + "Admin Has Accepted your request" + "');</script>");
            if(Session["Result"] == "Rejected")
                Response.Write("<script>alert('" + "Admin Has Rejected your request" + "');</script>");
        }

        protected void BindGrid()
        {
            GridView1.DataSource = (DataTable)ViewState["Guest"];
            GridView1.DataBind();
        }

        void Insert()
        {
            DataTable dt = (DataTable)ViewState["Guest"];
            dt.Rows.Add(CountOfGuest, txtGuestName.Text.Trim(), txtOrgName.Text.Trim(), txtMobileNo.Text.Trim());
            ViewState["Guest"] = dt;
            this.BindGrid();int i = 1;
            lblCount.Text = (CountOfGuest+i++).ToString();
            txtGuestName.Text = string.Empty;
            txtOrgName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
        }
        protected void btnRequest_Click(object sender, EventArgs e)
        {
            string SubjectForVipRequest = "Vip Food Request";
            string SubjectForFoodRequest = "Food Request Info";
            
            Mail mail = new Mail();
            string Sender = ddlEmpName.SelectedItem.Text;
            FetchEmpEmail();

            string EmailBody = txtMailBody.Text;
            try
            {
                FetchManagerEmail();
                if (ddlCanteenType.Text == "VIP")
                {
                    string Admin = ConfigurationManager.AppSettings["FromMail"].ToString();
                    //string AdminPassword = ConfigurationManager.AppSettings["Password"].ToString();
                    mail.SendVIPMail(Admin, SubjectForVipRequest, EmailBody+link, Sender, EmpPassword);
                    mail.SendToManager(ManagerEmail, SubjectForFoodRequest, EmailBody, Sender, EmpPassword);
                    Response.Write("<script>alert('" + AlertSuccesMessage + "');</script>");
                }
                else
                {
                    mail.SendToManager(ManagerEmail, SubjectForFoodRequest, EmailBody, Sender, EmpPassword);
                }
            }
            catch(Exception ex)
            {

                Response.Write("<script>alert('" + AlertFailureMessage + "');</script>");
            }
            AssignValues();
            Session["RequestId"] = RequestID;
            Session["Description"] = Context.User.Identity.GetUserName()+ " have ordered for Vip Canteen ";
        }


        void AssignValues()
        {
            ForSqlOp forSqlOp = new ForSqlOp();
            forSqlOp.GName = txtGuestName.Text;
            forSqlOp.OrgName = txtOrgName.Text;
            forSqlOp.MobileNo = txtMobileNo.Text;
            forSqlOp.Emp2 = txtEmpName.Text;
            forSqlOp.EmpId = txtEmpId.Text;
            forSqlOp.DepartID = ddlDeptID.SelectedItem.Text;
            forSqlOp.LocId = ddlLocation.SelectedValue;
            forSqlOp.CanteenID = ddlCanteen.SelectedValue;


            forSqlOp.FromDate = txtFromDate.Text;
            forSqlOp.ToDate = txtToDate.Text;



            forSqlOp.AddDetails = txtAddDetails.Text;
            forSqlOp.FoodType = ddlMealType.SelectedValue;
            RequestID = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 25);
            TokenID = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 25);
            forSqlOp.RequestForm(RequestID, TokenID);
            forSqlOp.InsertionForGuest(RequestID, TokenID);
        }





        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Insert();
        }


        //void ForManagerEmail()
        //{
        //    string str = "select Manager.Email, Manager.Password from Manager join Department on Department.ID = Manager.DepartmentID where DepartmentID =('" + ddlDeptID.SelectedItem + "')";
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(str))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                if (sdr.Read())
        //                {
        //                    Email = sdr["Email"].ToString();
        //                    //Password = sdr["Password"].ToString();
        //                }
        //            }
        //            con.Close();
        //        }
        //    }
        //}
        void FetchManagerEmail()
        {
            connectionManger = new ConnectionManger();
            string QueryForManagerEmail = "select Manager.Email, Manager.Password from Manager join Department on Department.ID = Manager.DepartmentID where DepartmentID =('" + ddlDeptID.SelectedItem + "')";
            connectionManger.ForManagerEmail(QueryForManagerEmail);
            ManagerEmail = connectionManger.ManagerEmail;
        }
        void FetchEmpEmail()
        {
            connectionManger = new ConnectionManger();
            string QueryForEmpEmail = "select EmpPassword from AspNetUsers where UserName =('" + ddlEmpName.SelectedItem.Text + "')";
            connectionManger.ForEmpEmail(QueryForEmpEmail);
            EmpPassword = connectionManger.EmpPassword;
        }

        void AutoFillEmpName()
        {
            ddlEmpName.Items.Add(new ListItem("Select Name", ""));
            ddlEmpName.AppendDataBoundItems = true;
            String strQuery = "select UserName, Id from AspNetUsers";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlEmpName.DataSource = cmd.ExecuteReader();
                ddlEmpName.DataTextField = "UserName";
                ddlEmpName.DataValueField = "Id";
                ddlEmpName.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        private void AutoFillLoc()
        {
            string QueryForAutoFillingLoc = "SELECT LocationID, LocationName FROM Location";
            ForSqlOp forSqlOp = new ForSqlOp();
            DataSet dataSet = forSqlOp.Fill(QueryForAutoFillingLoc);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = dataSet.Tables[0];
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationID";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, "--Select--");
            }
        }

        void AutoFillIteam()
        {
            string QueryForAutoFillingItem = "SELECT ItemID, ItemName FROM Item where ItemName = 'Snacks'";
            ForSqlOp forSqlOp = new ForSqlOp();
            DataSet dataSet = forSqlOp.Fill(QueryForAutoFillingItem);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlItemName.DataSource = dataSet.Tables[0];
                ddlItemName.DataTextField = "ItemName";
                ddlItemName.DataValueField = "ItemID";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, "--Select--");
            }
        }
        void AutoFillForDepart()
        {
            String QueryForAutoFillingDepartment = "select Name, Id from Department";
            ForSqlOp forSqlOp = new ForSqlOp();
            DataSet dataSet = forSqlOp.Fill(QueryForAutoFillingDepartment);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlDeptID.DataSource = dataSet.Tables[0];
                ddlDeptID.DataTextField = "Id";
                ddlDeptID.DataValueField = "Name";
                ddlDeptID.DataBind();
                ddlDeptID.Items.Insert(0, "--Select--");
            }
        }
        
        protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = ddlEmpName.SelectedValue;
        }

        protected void btnReqSubmit_Click(object sender, EventArgs e)
        {
            //string StrQuery;
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(ConnectionString))
            //    {
            //        using (SqlCommand comm = new SqlCommand())
            //        {
            //            comm.Connection = conn;
            //            conn.Open();
            //            for (int i = 0; i < GridView1.Rows.Count; i++)
            //            {
            //                StrQuery = @"INSERT INTO tableName VALUES ("
            //                    + GridView1.Rows[i].Cells["ColumnName"].Text + ", "
            //                    + GridView1.Rows[i].Cells["ColumnName"].Text + ");";
            //                comm.CommandText = StrQuery;
            //                comm.ExecuteNonQuery();
            //            }
            //        }
            //    }
            //}
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CanteenID, CanteenName FROM Canteen WHERE LocationId ="+ ddlLocation.SelectedValue;
           // cmd.Parameters.AddWithValue("@LocationID", ddlLocation.SelectedValue);
            DataSet Ds = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(Ds);
            con.Close();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                ddlCanteen.DataSource = Ds.Tables[0];
                ddlCanteen.DataTextField = "CanteenName";
                ddlCanteen.DataValueField = "CanteenID";
                ddlCanteen.DataBind();
                ddlCanteen.Items.Insert(0, "--Select--");
            }
        }

        protected void ddlCanteen_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Item.ItemID, Item.ItemName from Item join CanteenItem on Item.ItemID = CanteenItem.ItemID join Canteen on Canteen.CanteenID = CanteenItem.CanteenID where Canteen.CanteenID="+114;
            cmd.Parameters.AddWithValue("@ID", ddlCanteen.SelectedValue);
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            if (objDs.Tables[0].Rows.Count > 0)
            {
                ddlMealType.DataSource = objDs.Tables[0];
                ddlMealType.DataTextField = "ItemName";
                ddlMealType.DataValueField = "ItemID";
                ddlMealType.DataBind();
                ddlMealType.Items.Insert(0, "--Select--");
            }
        }

    }
}


