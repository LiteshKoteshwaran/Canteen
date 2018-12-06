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
        ConnectionManger connectionManger;
        ForSqlOp forSqlOp;
        string ManagerEmail { set; get; }
        string EmpPassword { set; get; }
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(ConnectionString);
        static string AlertSuccesMessage = "Request has been made";
        static string AlertFailureMessage = "Try again some other time!!!";
        static string link= "      http://localhost:63020/Admin/VIPRequestFrom ";
        string RequestID;
        public static int TotalCount = 1;
        static string AdminReflex;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt;
            if (!this.IsPostBack)
            {
                AutoFillForDepart();
                AutoFillLoc();
                AutoFillEmpName();
                txtEmpLoyee.Text = Context.User.Identity.GetUserName();
                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("S.No"), new DataColumn("GuestName"), new DataColumn("Name"), new DataColumn("MobileNo"), new DataColumn("Token No") });
                ViewState["Guest"] = dt;
                this.BindGrid();
            }
            if (Context.User.IsInRole("HR"))
            {
                dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("SlNo"), new DataColumn("EmpName"), new DataColumn("DeptName"), new DataColumn("Mobile"), new DataColumn("TokenNo") });
                dt.Columns.AddRange(new DataColumn[3] {  new DataColumn("Item"), new DataColumn("Qunatity"), new DataColumn("MobileNo") });
                TableForHr.Visible = true;
                TableForSnacks.Visible = true;
                AutoFillIteam();
            }
            else
            {
                TableForHr.Visible = false;
                TableForSnacks.Visible = false;
            }
            if(Session["Result"] == "Accepted")
                Response.Write("<script>alert('" + "Admin Has Accepted your request" + "');</script>");
            if (Session["Result"] == "Rejected")
            {
                forSqlOp = new ForSqlOp();
                forSqlOp.AdminIsApproved((Session["AdminReflex"]).ToString());
                Response.Write("<script>alert('" + "Admin Has Rejected your request" + "');</script>");
            }
        }

        protected void BindGrid()
        {
            GridView1.DataSource = (DataTable)ViewState["Guest"];
            GridView1.DataBind();
        }

        void Insert()
        {
            
            DataTable dt = (DataTable)ViewState["Guest"];
            dt.Rows.Add(TotalCount, txtGuestName.Text.Trim(), txtOrgName.Text.Trim(), txtMobileNo.Text.Trim());
            ViewState["Guest"] = dt;
            this.BindGrid();
            if (txtGuestName.Text != null)
            {
                lblCount.Text = (TotalCount).ToString();
                txtGuestName.Text = txtGuestName.Text;
                txtOrgName.Text = txtOrgName.Text;
                txtMobileNo.Text = txtMobileNo.Text;
            }
            if(txtEmpName.Text != null)
            {
                txtGuestName.Text = txtEmpName.Text;
                txtOrgName.Text = txtDeptName.Text;
                txtMobileNo.Text = txtMobile.Text;
            }
            if (ddlItemName.SelectedValue != null)
            {
                txtGuestName.Text = ddlItemName.SelectedValue;
                txtOrgName.Text = txtQuantity.Text;
                txtMobileNo.Text = txtTimetoServe.Text;
            }
            TotalCount++;
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
                    Response.Write("<script>alert('" + " Info sent to your Respective Department Manager " + "');</script>");
                }
            }
            catch(Exception ex)
            {
                
                Response.Write("<script>alert('" + (AlertFailureMessage) + "');</script>");
            }
            AssignValues();
            Session["RequestId"] = RequestID;
            AdminReflex = RequestID;
            Session["Description"] = Context.User.Identity.GetUserName()+ " have ordered for Vip Canteen ";
        }


        void AssignValues()
        {
            forSqlOp = new ForSqlOp();
            forSqlOp.GName = txtGuestName.Text;
            forSqlOp.OrgName = txtOrgName.Text;
            forSqlOp.MobileNo = txtMobileNo.Text;

            forSqlOp.Emp2 = txtEmpName.Text;
            forSqlOp.EmpDeptName = txtDeptName.Text;
            forSqlOp.EmpMobile = txtMobile.Text;

            forSqlOp.SelectedSnacks = ddlItemName.SelectedValue;
            forSqlOp.SnackQuantity = txtQuantity.Text;

            forSqlOp.EmpId = txtEmpId.Text;


            forSqlOp.OrderQuanty = ""+TotalCount;
            forSqlOp.FromDate = txtFromDate.Text;
            forSqlOp.ToDate = txtToDate.Text;


            forSqlOp.DepartID = ddlDeptID.SelectedItem.Text;
            forSqlOp.LocId = ddlLocation.SelectedValue;
            forSqlOp.CanteenID = ddlCanteen.SelectedValue;
            forSqlOp.AddDetails = txtAddDetails.Text;
            forSqlOp.FoodType = ddlMealType.SelectedItem.Text;
            forSqlOp.RequestID = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 25);
            RequestID = forSqlOp.RequestID;
            forSqlOp.TokenID = Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().Length - 25);
            forSqlOp.RequestForm();
            forSqlOp.InsertionForGuest();

        }





        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    Insert();
        //}
        void FetchManagerEmail()
        {
            connectionManger = new ConnectionManger();
            string QueryForManagerEmail = "select Manager.Email, Manager.Password from Manager join Department on Department.DeptId = Manager.DepartmentId where DeptId =('" + ddlDeptID.SelectedItem + "')";
            //connectionManger.ForManagerEmail(QueryForManagerEmail);
            //ManagerEmail = connectionManger.ManagerEmail;
            ManagerEmail = connectionManger.Selection(QueryForManagerEmail);
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
            connectionManger = new ConnectionManger();
            string QueryForAutoFillingLoc = "SELECT LocationId, LocationName FROM Location";
            DataSet dataSet = connectionManger.Fill(QueryForAutoFillingLoc);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = dataSet.Tables[0];
                ddlLocation.DataTextField = "LocationName";
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataBind();
                ddlLocation.Items.Insert(0, "--Select--");
            }
        }

        void AutoFillIteam()
        {
            connectionManger = new ConnectionManger();
            string QueryForAutoFillingItem = "SELECT ItemId, ItemName FROM Item where ItemName = 'Snacks'";
            DataSet dataSet = connectionManger.Fill(QueryForAutoFillingItem);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlItemName.DataSource = dataSet.Tables[0];
                ddlItemName.DataTextField = "ItemName";
                ddlItemName.DataValueField = "ItemId";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, "--Select--");
            }
        }
        void AutoFillForDepart()
        {
            connectionManger = new ConnectionManger();
            String QueryForAutoFillingDepartment = "select DeptName, DeptId from Department";
            DataSet dataSet = connectionManger.Fill(QueryForAutoFillingDepartment);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlDeptID.DataSource = dataSet.Tables[0];
                ddlDeptID.DataTextField = "DeptId";
                ddlDeptID.DataValueField = "DeptName";
                ddlDeptID.DataBind();
                ddlDeptID.Items.Insert(0, "--Select--");
            }
        }
        protected void btnReqSubmit_Click(object sender, EventArgs e)
        {
        }

        protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = ddlEmpName.SelectedValue;
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            connectionManger = new ConnectionManger();
            string QueryForCascading = "SELECT CanteenId, CanteenName FROM Canteen WHERE LocationId ="+ ddlLocation.SelectedValue;
            DataSet dataSet = connectionManger.Fill(QueryForCascading);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlCanteen.DataSource = dataSet.Tables[0];
                ddlCanteen.DataTextField = "CanteenName";
                ddlCanteen.DataValueField = "CanteenId";
                ddlCanteen.DataBind();
                ddlCanteen.Items.Insert(0, "--Select--");
            }
        }

        protected void ddlCanteen_SelectedIndexChanged(object sender, EventArgs e)
        {
            connectionManger = new ConnectionManger();
            string QueryForCascading = "SELECT Item.ItemId, Item.ItemName from Item join CanteenItems on Item.ItemId = CanteenItems.ItemId join Canteen on Canteen.CanteenId = CanteenItems.CanteenId where Canteen.CanteenId="+ ddlCanteen.SelectedValue;
            DataSet dataSet = connectionManger.Fill(QueryForCascading);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                ddlMealType.DataSource = dataSet.Tables[0];
                ddlMealType.DataTextField = "ItemName";
                ddlMealType.DataValueField = "ItemId";
                ddlMealType.DataBind();
                ddlMealType.Items.Insert(0, "--Select--");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime thisDay = DateTime.Today;
            DateTime CmpDate = Convert.ToDateTime(txtFromDate.Text);
            if (CmpDate <= thisDay)
            {
                args.IsValid = false;
            }
        }
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime thisDay = DateTime.Today;
            DateTime CmpDate = Convert.ToDateTime(txtFromDate.Text);
            if (CmpDate <= thisDay)
            {
                args.IsValid = false;
            }
        }
        



        protected void btnView_Click(object sender, EventArgs e)
        {
            Insert();
        }
    }
}


