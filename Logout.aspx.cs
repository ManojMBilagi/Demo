using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAuthentication();
                SetAuthentication(false);
                Response.Redirect("Login.aspx");
            }
        }
        private void CheckAuthentication()
        {
            if (Session["IsAuthenticated"] != null && (bool)Session["IsAuthenticated"])
            {
                // If user is already authenticated, redirect to dashboard
                Response.Redirect("Default.aspx");
            }
        }
        private void SetAuthentication(bool isAuthenticated)
        {
            Session["IsAuthenticated"] = isAuthenticated;
        }
    }
}