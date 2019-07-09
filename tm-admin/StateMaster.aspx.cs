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
    public partial class StateMaster : System.Web.UI.Page
    {
        GetData G = new GetData();
        Connection D = new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillState();
                //Fillemployee();
                BindData();
                string name = Request.Cookies["ADMIN_NAME"].Value;
                if (name != "admin")
                {
                    string j = gv.Items.Count.ToString();
                    for (int i = 0; i < Convert.ToInt32(j.ToString()); i++)
                    {
                        LinkButton linkButton = (LinkButton)gv.Items[i].FindControl("lbDelete");
                        linkButton.Visible = false;
                    }
                }
            }
        }
        protected void lbSubmit_Click(Object Sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("insert into STATE_MASTER (statename) values('" + txtstate.Text + "')");
                BindData();
                Clear();
                divSuccess.Visible = true;
                divError.Visible = false;
            }
            catch
            {
                divSuccess.Visible = false;
                divError.Visible = true;
            }

        }
        protected void Clear()
        {
            txtstate.Text = "";
        }
        protected void BindData()
        {
            try
            {
                DataTable dt = G.GetDataTable("select * from STATE_MASTER");
                if (dt.Rows.Count > 0)
                {
                    gv.DataSource = dt;
                    gv.DataBind();
                }
                else
                {
                    dt = null;
                    gv.DataSource = dt;
                    gv.DataBind();
                }
            }
            catch { }
        }
        protected void lbDelete_Click(Object Sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)Sender;
                int id = Convert.ToInt32(lb.CommandArgument.ToString());
                D.ExecuteQuery("delete from STATE_MASTER where Id=" + id);

                divSuccess.Visible = true;
                divError.Visible = false;

                BindData();
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                divSuccess.Visible = false;
            }
        }
        protected void lbEdit_Click(Object Sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)Sender;
            int id = Convert.ToInt32(lb.CommandArgument);
            DataTable dt = D.GetData("select * from STATE_MASTER where Id=" + lb.CommandArgument);
            if (dt.Rows.Count > 0)
            {

                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                btnsubmit.CommandArgument = dt.Rows[0]["Id"].ToString();
                txtstate.Text = dt.Rows[0]["statename"].ToString();
            }
        }
        protected void lbUpdate_Click(Object Sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("update STATE_MASTER set STATENAME = '" + txtstate.Text + "' where Id = '" + btnsubmit.CommandArgument + "'");
                Clear();
                BindData();
                btnupdate.Visible = false;
                btnsubmit.Visible = true;
                divSuccess.Visible = true;
                divError.Visible = false;
            }
            catch
            {
                divSuccess.Visible = false;
                divError.Visible = true;
            }

        }
    }
}