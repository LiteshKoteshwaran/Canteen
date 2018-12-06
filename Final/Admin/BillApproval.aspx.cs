using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final.Admin
{
    public partial class BillApproval : System.Web.UI.Page
    {
        ConnectionManger connectionManger;
        protected void Page_Load(object sender, EventArgs e)
        {
            AutoFillLoc();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

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
                //ddlLocation.Items.Insert(0, "--Select--");
            }
        }
        protected void ddlLocation_SelectedIndexChanged1(object sender, EventArgs e)
        {
            connectionManger = new ConnectionManger();
            string QueryForCascading = "SELECT CanteenId, CanteenName FROM Canteen WHERE LocationId = " + ddlLocation.SelectedValue;
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

        protected void DropDownListCanteen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string QueryForNoOfRequest= "select count(*) as NoOfRequests from Request group by DATEPART(mm, FromDate),LocId,CanteenId having DATEPART(mm, FromDate) =" + ddlMonth.SelectedValue + " and LocId =" + ddlLocation.SelectedValue + " and CanteenId ="+ddlCanteen.SelectedValue;
            connectionManger = new ConnectionManger();
            txtNoOfRequest.Text= connectionManger.Selection(QueryForNoOfRequest);

            string QueryForNoOfConsumed = "select count(*) as NoOfConsumed from Request R full outer join Served S on R.RequestId = S.ReqId where S.IfServed = 1 group by DATEPART(mm, R.FromDate) ,LocId,CanteenId having DATEPART(mm, R.FromDate) = " + ddlMonth.SelectedValue  + " and LocId ="+ ddlLocation.SelectedValue + " and CanteenId =" + ddlCanteen.SelectedValue;
            connectionManger = new ConnectionManger();
            txtNoOfRequest.Text = connectionManger.Selection(QueryForNoOfConsumed);

            string QueryForNoOfTotalCost = "select SUM(S.Cost) as TotalCost from Request R  full outer join Served S on R.RequestId = S.ReqId where S.IfServed = 1 group by DATEPART(mm, FromDate) ,LocId,CanteenId having DATEPART(mm, FromDate) =" + ddlMonth.SelectedValue + " and LocId ="+ ddlMonth.SelectedValue + " and CanteenId =" + ddlCanteen.SelectedValue;
            connectionManger = new ConnectionManger();
            txtTotalCost.Text = connectionManger.Selection(QueryForNoOfConsumed);
        }



        
    }
}