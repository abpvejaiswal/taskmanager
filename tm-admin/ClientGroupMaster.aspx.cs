using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;
using System.Data.SqlClient;
namespace TaskManager.tm_admin
{
    public partial class BranchMaster : System.Web.UI.Page
    {
        Connection D = new Connection();
        GetData G = new GetData();
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindData();
                string name = Request.Cookies["ADMIN_NAME"].Value;
                //if (name != "admin")
                //{
                //    string j = gv.Items.Count.ToString();
                //    for (int i = 0; i < Convert.ToInt32(j.ToString()); i++)
                //    {
                //        LinkButton linkButton = (LinkButton)gv.Items[i].FindControl("lbDelete");
                //        linkButton.Visible = false;
                //    }
                //}

            }
        }
        protected void lbSubmit_Click(Object Sender, EventArgs e)
        {
            if (txtClientGroupName.Text != "")
            {
                try
                {
                    D.ExecuteQuery("insert into CLIENT_GROUP_MASTER (CLIENT_GROUP_NAME) values('" + txtClientGroupName.Text + "')");
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
            else
            {
                divSuccess.Visible = false;
                divError.Visible = true;
            }


        }
        protected void Clear()
        {
            txtClientGroupName.Text = "";
        }
        protected void BindData()
        {
            try
            {
                DataTable dt = G.GetDataTable("select * from CLIENT_GROUP_MASTER order by CLIENT_GROUP_NAME asc");
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

                D.ExecuteQuery("delete from CLIENT_GROUP_MASTER where Id=" + id);

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

            DataTable dt = D.GetData("select * from CLIENT_GROUP_MASTER where Id=" + lb.CommandArgument);
            if (dt.Rows.Count > 0)
            {

                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                btnupdate.CommandArgument = dt.Rows[0]["Id"].ToString();
                txtClientGroupName.Text = dt.Rows[0]["CLIENT_GROUP_NAME"].ToString();
            }
        }
        protected void lbUpdate_Click(Object Sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("update CLIENT_GROUP_MASTER set CLIENT_GROUP_NAME = '" + txtClientGroupName.Text + "' where Id = '" + btnupdate.CommandArgument + "'");
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