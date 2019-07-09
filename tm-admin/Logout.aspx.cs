using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager.tm_admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cookies["ADMIN_ID"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["ADMIN_NAME_ADMIN"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["ADMIN_EMAIL"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["ADMIN_NAME"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("~/tm-admin");
            }
        }
    }
}