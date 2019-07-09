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
    public partial class AddEmployeeMenu : System.Web.UI.Page
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divSuccess.Visible = false;
                divError.Visible = false;
                //  FillState();
                //FillCity();
                Fillemployee();
                BindMenus();
            }

        }

        private void BindMenus()
        {
            if (ddlemployee.SelectedValue != "")
            {
                int CId = Convert.ToInt32(ddlemployee.SelectedValue);
                DataTable dt = D.GetDataTable("SELECT * FROM SiteMenuMaster as MM LEFT JOIN EMPLOYEE_ASSIGHN_MENU as C ON MM.ID=C.Menu_ID and C.Emp_ID=" + CId + " order by Seq");
                if (dt.Rows.Count > 0)
                {
                    dlMenu.DataSource = dt;
                }
                dlMenu.DataBind();
            }
        }
        private void Fillemployee()
        {
            DataTable dt = D.GetDataTable("SELECT * FROM employee_master");
            if (dt.Rows.Count > 0)
            {
                ddlemployee.DataSource = dt;
                ddlemployee.DataValueField = "ID";
                ddlemployee.DataTextField = "FIRST_NAME";
                ddlemployee.DataBind();
            }
            // ddlemployee.Items.Insert(0, new ListItem("Select Employee", "0"));
        }
        protected void ddlemployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMenus();
        }
        private void ShowDataList()
        {
            DataTable dt = D.GetDataTable("select * from sitemenumaster");
            if (dt.Rows.Count > 0)
            {
                dlMenu.DataSource = dt;
                dlMenu.DataBind();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int CId = Convert.ToInt32(ddlemployee.SelectedValue);
                D.ExecuteQuery("delete from EMPLOYEE_ASSIGHN_MENU where EMP_ID=" + CId);
                foreach (RepeaterItem item in dlMenu.Items)
                {
                    HiddenField hdMenu = item.FindControl("hdMenu") as HiddenField;
                    if ((item.FindControl("chkMenu") as CheckBox).Checked)
                    {
                        D.ExecuteQuery("insert into EMPLOYEE_ASSIGHN_MENU(emp_id,menu_id) values('" + ddlemployee.SelectedValue + "', '" + hdMenu.Value + "')");
                        //_menucl.Insert(CId, Convert.ToInt32(hdMenu.Value));
                    }
                }
                Response.Redirect("AddEmployeeMenu.aspx");
            }
            catch { }
        }

        protected void dlMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRow dr = ((DataRowView)e.Item.DataItem).Row;
                if (dr["Menu_ID"].ToString() != null && dr["Menu_ID"].ToString() != "")
                {
                    ((CheckBox)e.Item.FindControl("chkMenu")).Checked = true;
                }
                else
                {
                    ((CheckBox)e.Item.FindControl("chkMenu")).Checked = false;
                }
            }
        }
    }
}