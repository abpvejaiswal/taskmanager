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
    public partial class NatureWorkMaster : System.Web.UI.Page
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
            if (txtNatureWork.Text != "")
            {
                try
                {
                    D.ExecuteQuery("insert into NATURE_OF_WORK (NATURE_OF_WORK) values('" + txtNatureWork.Text + "')");
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
            txtNatureWork.Text = "";
        }
        protected void BindData()
        {
            try
            {
                DataTable dt = G.GetDataTable("select * from NATURE_OF_WORK order by NATURE_OF_WORK asc");
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

                D.ExecuteQuery("delete from NATURE_OF_WORK where Id=" + id);

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

            DataTable dt = D.GetData("select * from NATURE_OF_WORK where Id=" + lb.CommandArgument);
            if (dt.Rows.Count > 0)
            {

                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                btnupdate.CommandArgument = dt.Rows[0]["Id"].ToString();
                txtNatureWork.Text = dt.Rows[0]["NATURE_OF_WORK"].ToString();
            }
        }
        protected void lbUpdate_Click(Object Sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("update NATURE_OF_WORK set NATURE_OF_WORK = '" + txtNatureWork.Text + "' where Id = '" + btnupdate.CommandArgument + "'");
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