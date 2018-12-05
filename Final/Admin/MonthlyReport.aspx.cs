using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final.Admin
{
    public partial class MonthlyReport : System.Web.UI.Page
    {
        int Month;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGridView();
        }
        public void BindGridView()
        {
            RolesDAL MonthlyReport = new RolesDAL();


            if (Month != 0)
            {

                GridMonthlyReport.DataSource = MonthlyReport.GetMonthlyReport(Month);

                GridMonthlyReport.DataBind();
            }
        }

        protected void MonthlyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Month = Convert.ToInt32(MonthlyDropDownList.SelectedValue);

        }

        protected void GridMonthlyReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGetMonthlyReport_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}