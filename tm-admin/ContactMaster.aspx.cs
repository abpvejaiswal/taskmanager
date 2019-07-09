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
    public partial class BankMaster : System.Web.UI.Page
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
                D.ExecuteQuery("insert into CONTACT_MASTER (CONTACT_PERSON,CONTACT_NUMBER,EMAIL_ID) values('" + txtContactPerson.Text + "','" + txtContactNumber.Text + "','" + txtEmailId.Text + "')");
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
            txtContactPerson.Text = "";
            txtContactNumber.Text = "";
            txtEmailId.Text = "";
        }
        protected void BindData()
        {
            try
            {
                DataTable dt = G.GetDataTable("select * from CONTACT_MASTER order by CONTACT_PERSON asc");
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
                int ID = Convert.ToInt32(lb.CommandArgument.ToString());
                D.ExecuteQuery("delete from CONTACT_MASTER where ID=" + ID);

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
            int ID = Convert.ToInt32(lb.CommandArgument);
            DataTable dt = D.GetData("select * from CONTACT_MASTER where ID=" + lb.CommandArgument);
            if (dt.Rows.Count > 0)
            {

                btnsubmit.Visible = false;
                btnupdate.Visible = true;
                btnsubmit.CommandArgument = dt.Rows[0]["ID"].ToString();
                txtContactPerson.Text = dt.Rows[0]["CONTACT_PERSON"].ToString();
                txtContactNumber.Text = dt.Rows[0]["CONTACT_NUMBER"].ToString();
                txtEmailId.Text = dt.Rows[0]["EMAIL_ID"].ToString();
            }
        }
        protected void lbUpdate_Click(Object Sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("update CONTACT_MASTER set CONTACT_PERSON = '" + txtContactPerson.Text + "',CONTACT_NUMBER = '" + txtContactNumber.Text + "',EMAIL_ID = '" + txtEmailId.Text + "' where ID = '" + btnsubmit.CommandArgument + "'");
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