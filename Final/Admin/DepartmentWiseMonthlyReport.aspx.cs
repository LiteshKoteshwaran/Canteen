using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final.Admin
{
    public partial class DepartmentWiseMonthlyReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGridView();
        }
        public void BindGridView()
        {
            RolesDAL DeptMonthlyReport = new RolesDAL();
            GridDeptWiseMonthlyReport.DataSource = DeptMonthlyReport.GetDeptMonthlyReport();
            GridDeptWiseMonthlyReport.DataBind();
        }
        protected void GridDeptWiseMonthlyReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}