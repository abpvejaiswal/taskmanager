using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;
using System.Data;
namespace TaskManager.tm_admin
{
    public partial class Default : System.Web.UI.Page
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void lbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = D.GetDataTable("Select * from admin_master where EMAIL='" + txtUsername.Text + "' and PASSWORD='" + txtPassword.Text + "'");
                if (dt1.Rows.Count > 0)
                {
                    Response.Cookies["ADMIN_ID"].Value = dt1.Rows[0]["ID"].ToString();
                    Response.Cookies["ADMIN_NAME"].Value = dt1.Rows[0]["name"].ToString();
                    Response.Cookies["POST_ID"].Value = "1";

                    //Response.Cookies["Email"].Value = dt1.Rows[0]["Email"].ToString();
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    
                    DataTable dt = D.GetDataTable("Select * from EMPLOYEE_MASTER where EMAIL='" + txtUsername.Text + "' and PASSWORD='" + txtPassword.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        Response.Cookies["ADMIN_ID"].Value = dt.Rows[0]["ID"].ToString();
                        Response.Cookies["POST_ID"].Value = dt.Rows[0]["POST_ID"].ToString();
                        Response.Cookies["ADMIN_NAME"].Value = dt.Rows[0]["FIRST_NAME"].ToString() + " " + dt.Rows[0]["LAST_NAME"].ToString();
                        //Response.Cookies["ADMIN_NAME"].Value = dt.Rows[0]["NAME"].ToString();
                        //Response.Cookies["ADMIN_EMAIL"].Value = dt.Rows[0]["EMAIL"].ToString();
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {

                        divError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
            }
        }
    }
}