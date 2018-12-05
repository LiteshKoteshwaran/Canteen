using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final.Admin
{
    public partial class Roles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                BindGridView();
        }
        public void BindGridView()
        {
            RolesDAL product = new RolesDAL();
            gvRoles.DataSource = product.GetRoles();
            gvRoles.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string roleId = txtRoleId.Text;
            string roleName = txtRoleName.Text;
            RolesDAL rd = new RolesDAL();
            rd.InsertRole(roleId, roleName);
            BindGridView();
            txtRoleId.Text = "";
            txtRoleName.Text = "";
        }


        protected void btnGenerateId_Click(object sender, EventArgs e)
        {
            Guid g;
            // Create and display the value of two GUIDs.
            g = Guid.NewGuid();
            txtRoleId.Text = g.ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtRoleId.Text = "";
            txtRoleName.Text = "";
        }

        protected void gvRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRoles.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void gvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Role role = new Role();
            GridViewRow row = gvRoles.Rows[e.RowIndex];
            role.Id = gvRoles.DataKeys[e.RowIndex].Values[0].ToString();
            //product.Name = (row.FindControl("txtName") as TextBox).Text;
            RolesDAL roleDAL = new RolesDAL();
            roleDAL.deleteRole(role);
            gvRoles.EditIndex = -1;
            BindGridView();
        }

        protected void gvRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Role role = new Role();
            GridViewRow row = gvRoles.Rows[e.RowIndex];
            role.Id = gvRoles.DataKeys[e.RowIndex].Values[0].ToString();
            role.Name = (row.FindControl("txtRolesName") as TextBox).Text;
            RolesDAL roleDAL = new RolesDAL();
            roleDAL.UpdateRole(role);
            gvRoles.EditIndex = -1;
            BindGridView();
        }
    }
}