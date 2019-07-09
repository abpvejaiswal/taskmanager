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
    public partial class ItemMaster : System.Web.UI.Page
    {
        GetData G = new GetData();
        Connection D = new Connection();
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
            try
            {
                D.ExecuteQuery("insert into YEAR_MASTER (FINANCIAL_YEAR,ASSESSMENT_YEAR) values('" + txtFinancialYear.Text + "','" + txtAssesmentYear.Text + "')");
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
            txtFinancialYear.Text = "";
            txtAssesmentYear.Text = "";
        }
        protected void BindData()
        {
            try
            {
                DataTable dt = G.GetDataTable("select * from YEAR_MASTER order by FINANCIAL_YEAR asc");
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
                D.ExecuteQuery("delete from YEAR_MASTER where Id=" + id);

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
            DataTable dt = D.GetData("select * from YEAR_MASTER where Id=" + lb.CommandArgument);
            if (dt.Rows.Count > 0)
            {

                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                btnsubmit.CommandArgument = dt.Rows[0]["Id"].ToString();
                txtFinancialYear.Text = dt.Rows[0]["FINANCIAL_YEAR"].ToString();
                txtAssesmentYear.Text = dt.Rows[0]["ASSESSMENT_YEAR"].ToString();
            }
        }
        protected void lbUpdate_Click(Object Sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("update YEAR_MASTER set FINANCIAL_YEAR = '" + txtFinancialYear.Text + "',ASSESSMENT_YEAR = '" + txtAssesmentYear.Text + "' where Id = '" + btnsubmit.CommandArgument + "'");
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