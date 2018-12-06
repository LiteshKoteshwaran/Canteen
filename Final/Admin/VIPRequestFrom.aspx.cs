using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final.Admin
{
    public partial class VIPRequestFrom : System.Web.UI.Page
    {
        ConnectionManger connectionManger;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RequestId"] != null)
            {
                //string RequestID = Session["RequestId"].ToString();
                //Response.Write(RequestID);
                //string Description = Session["Description"].ToString();
                //Response.Write(Description);

                txtRequestID.Text = Session["RequestId"].ToString();
                txtDescription.Text= Session["Description"].ToString();
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            Session["Result"] = "Accepted";
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            connectionManger = new ConnectionManger();
            Session["Result"] = "Rejected";
            Session["AdminReflex"] = txtRequestID.Text;
            string str = "update Request set AdminVIPApproval = 0 where RequestId = '" + txtRequestID.Text + "'";
            connectionManger.ConnMan(str);
        }
    }
}