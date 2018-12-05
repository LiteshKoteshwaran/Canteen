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

namespace Final
{
    public partial class CanteenRequestForm : System.Web.UI.Page
    {
        string Email { set; get; }
        string Password { set; get; }
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(ConnectionString);
        static string AlertSuccesMessage = "Request has been made";
        static string AlertFailureMessage = "Try again some other time!!!";
        int CountOfGuest = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ForLoccascading();
                ForMealtypecascading();
                ForCanteenascading();
                AutoFillEmpName();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("S.No"), new DataColumn("GuestName"), new DataColumn("Name"), new DataColumn("MobileNo") });
                ViewState["Guest"] = dt;
                this.BindGrid();
            }
            if (Context.User.IsInRole("HR"))
            {
                TableForHr.Visible = true;
                TableForSnacks.Visible = true;
            }
            else
            {
                TableForHr.Visible = false;
                TableForSnacks.Visible = false;
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
            dt.Rows.Add(CountOfGuest, txtGuestName.Text.Trim(), txtOrgName.Text.Trim(), txtMobileNo.Text.Trim());
            ViewState["Guest"] = dt;
            this.BindGrid();
            lblCount.Text = CountOfGuest++.ToString();
            txtGuestName.Text = string.Empty;
            txtOrgName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
        }
        protected void btnRequest_Click(object sender, EventArgs e)
        {
            string SubjectForVipRequest = "Vip Food Request";
            string SubjectForFoodRequest = "Food Request Info";
            ForSqlOp forSqlOp = new ForSqlOp();
            Mail mail = new Mail();
            string Sender = ddlEmpName.SelectedItem.Text;
            string EmailBody = txtMailBody.Text;
            try
            {
                if (ddlCanteenType.Text == "VIP")
                {
                    string Admin = ConfigurationManager.AppSettings["FromMail"].ToString();
                    string AdminPassword = ConfigurationManager.AppSettings["Password"].ToString();
                    mail.SendVIPMail(Admin, SubjectForVipRequest, EmailBody, Sender, AdminPassword);
                    mail.SendToManager(Email, SubjectForFoodRequest, EmailBody, Sender, Password);
                    Response.Write("<script>alert('" + AlertSuccesMessage + "');</script>");
                }
                mail.SendToManager(Email, SubjectForFoodRequest, EmailBody, Sender, Password);
            }
            catch
            {
                Response.Write("<script>alert('" + AlertFailureMessage + "');</script>");
            }
            forSqlOp.GName = txtGuestName.Text;
            forSqlOp.OrgName = txtOrgName.Text;
            forSqlOp.MobileNo = txtMobileNo.Text;
            forSqlOp.InsertionForGuest();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Insert();
        }
        void ForManagerEmail()
        {
            string str = "select Email as e from Manager m join Department d on d.ID=m.DepartmentID where D.Name =('" + ddlDeptID.SelectedValue + "')";
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
                            Email = sdr["Email"].ToString();
                            Password = sdr["Password"].ToString();
                        }
                    }
                    con.Close();
                }
            }
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
        
        protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpId.Text = ddlEmpName.SelectedValue;
        }


            void ForLoccascading()
            { 
                ddlLocation.Items.Add(new ListItem("Select Name", ""));
                ddlLocation.AppendDataBoundItems = true;
                String strQuery = "select * from Location";
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlLocation.DataSource = cmd.ExecuteReader();
                    ddlLocation.DataTextField = "Name";
                    ddlLocation.DataValueField = "ID";
                    ddlLocation.DataBind();
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
        void ForMealtypecascading()
        {
            ddlMealType.Items.Add(new ListItem("Select Name", ""));
            ddlMealType.AppendDataBoundItems = true;
            String strQuery = "select * from Item";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlMealType.DataSource = cmd.ExecuteReader();
                ddlMealType.DataTextField = "Name";
                ddlMealType.DataValueField = "ID";
                ddlMealType.DataBind();
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
        void ForCanteenascading()
        {
            ddlCanteen.Items.Add(new ListItem("Select Name", ""));
            ddlCanteen.AppendDataBoundItems = true;
            String strQuery = "select * from Canteen";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlCanteen.DataSource = cmd.ExecuteReader();
                ddlCanteen.DataTextField = "Name";
                ddlCanteen.DataValueField = "ID";
                ddlCanteen.DataBind();
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


        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCanteenType.Items.Clear();
            ddlCanteenType.Items.Add("     ");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("select CanteenType from Canteen where LocationID = " + ddlLocation.SelectedItem.Value, con);
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlCanteenType.DataSource = cmd.ExecuteReader();
                ddlCanteenType.DataTextField = "CanteenType";
                ddlCanteenType.DataValueField = "ID";
                ddlCanteenType.DataBind();
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
        protected void ddlCanteenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCanteen.Items.Clear();
            ddlCanteen.Items.Add("      ");
            SqlCommand cmd = new SqlCommand("select CanteenName from Canteen where CanteenType=" + ddlCanteenType.SelectedItem.Value, con);
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlCanteen.DataSource = cmd.ExecuteReader();
                ddlCanteen.DataTextField = "CanteenName";
                ddlCanteen.DataValueField = "ID";
                ddlCanteen.DataBind();
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
        protected void ddlCanteen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMealType.Items.Clear();
            ddlMealType.Items.Add("     ");
            SqlCommand cmd = new SqlCommand("select I.Name from Item join CanteenItem CI on I.ID=CI.ItemID join Canteen C on C.ID=CI.CanteenID where C.CanteenName = " + ddlCanteen.SelectedItem.Value, con);
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlMealType.DataSource = cmd.ExecuteReader();
                ddlMealType.DataTextField = "Name";
                ddlMealType.DataValueField = "ID";
                ddlMealType.DataBind();
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

        protected void btnReqSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void FromDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime thisDay = DateTime.Today;
            DateTime CmpDate =Convert.ToDateTime(FromDate.Value);
            if(CmpDate<=thisDay)
            {
                args.IsValid = false;
            }
        }
        protected void ToDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime thisDay = DateTime.Today;
            DateTime CmpDate = Convert.ToDateTime(FromDate.Value);
            if (CmpDate <= thisDay)
            {
                args.IsValid = false;
            }
        }
    }
}


