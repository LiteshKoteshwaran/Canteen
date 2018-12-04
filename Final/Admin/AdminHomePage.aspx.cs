using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final.Admin
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("Location.aspx");
        }

        protected void btnCanteen_Click(object sender, EventArgs e)
        {
            Response.Redirect("Canteen.aspx");
        }

        protected void btnItemsRates_Click(object sender, EventArgs e)
        {
            Response.Redirect("ItemsRates.aspx");
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("Email.aspx");
        }
    }
}