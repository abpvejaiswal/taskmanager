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
    public partial class Home : System.Web.UI.Page
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
            }
        }
        protected void BindData()
        {
            try
            {
                DataTable dt = G.GetDataTable("select * from LEAD_MASTER");
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
                D.ExecuteQuery("delete from LEAD_MASTER where Id=" + id);

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
    }
}