using TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;

namespace TaskManager.tm_admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindMenus();
            if (!IsPostBack)
            {
                try
                {
                    if (Request.Cookies["ADMIN_ID"] != null && Request.Cookies["ADMIN_NAME"] != null)
                    {
                        ltrLoginName.Text = Request.Cookies["ADMIN_NAME"].Value;
                    }
                    else
                    {
                        Response.Redirect("~/tm-admin");
                    }
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('Please, Login First'); parent.location.href='Default.aspx'", true);
                }

                BindMenus();
                //masterdatamenu.Visible = false;
                //clientdatamenu.Visible = false;
                //viewdatamenu.Visible = false;
            }
        }

        private void BindMenus()
        {
            masterdatamenu.Visible = false;
            aCreatTask.Visible = false;
            aAllTask.Visible = false;
            string POST_ID = Request.Cookies["POST_ID"].Value;
            if (POST_ID == "1")
            {
                masterdatamenu.Visible = true;
                aCreatTask.Visible = true;
                aAllTask.Visible = true;
            }
        }

    }
}