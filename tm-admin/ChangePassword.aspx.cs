using TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager.tm_admin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        GetData G = new GetData();
        Connection D = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    loginname.Value = Request.Cookies["ADMIN_NAME"].Value;
                    loginid.Value = Request.Cookies["ADMIN_ID"].Value;
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clentscript", "alert('Please, Login First'); parent.location.href='Default.aspx'", true);
                }
                
                
            }
        }
        protected void lbSubmit_Click(Object Sender, EventArgs e)
        {
            try
            {
                if (txtnew.Text == txtconfirm.Text)
                {
                    string Loginname = loginname.Value;
                    string Loginid = loginid.Value;
                    
                    if (Loginname == "admin")
                    {
                        DataTable dt = G.GetDataTable("Select * from admin_master where password = '" + txtold.Text + "'");
                        if (dt.Rows.Count > 0)
                        {
                            G.ExecuteQuery("update admin_master set password = '" + txtnew.Text + "'");
                            divold.Visible = false;
                            divSuccess.Visible = true;
                            divError.Visible = false;
                            divconfirm.Visible = false;
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('Password Change Successfully');window.location ='Logout.aspx;", true);
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('Password Change Successfully! Please Login Again.'); parent.location.href='Logout.aspx'", true);
                        }
                        else
                        {
                            divold.Visible = true;
                            divSuccess.Visible = false;
                            divError.Visible = false;
                            divconfirm.Visible = false;
                        }
                    }
                    else
                    {
                        DataTable dt = G.GetDataTable("Select * from EMPLOYEE_MASTER where password = '" + txtold.Text + "' and id = " + Loginid);
                        if (dt.Rows.Count > 0)
                        {
                            G.ExecuteQuery("update EMPLOYEE_MASTER set password = '" + txtnew.Text + "' where id = " + Loginid);
                            divold.Visible = false;
                            divSuccess.Visible = true;
                            divError.Visible = false;
                            divconfirm.Visible = false;
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "alert", "alert('Password Change Successfully');window.location ='Logout.aspx;", true);
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('Password Change Successfully! Please Login Again.'); parent.location.href='Logout.aspx'", true);
                        }
                        else
                        {
                            divold.Visible = true;
                            divSuccess.Visible = false;
                            divError.Visible = false;
                            divconfirm.Visible = false;
                        }

                    }
                }
                else
                {
                    divold.Visible = false;
                    divSuccess.Visible = false;
                    divError.Visible = false;
                    divconfirm.Visible = true;
                }
            }
            catch(Exception ex)
            {
                divold.Visible = false;
                divSuccess.Visible = false;
                divError.Visible = true;
                divconfirm.Visible = false;
            }
            
            
             
        }
    }
}