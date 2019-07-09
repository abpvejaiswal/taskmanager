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
    public partial class MenuMaster : System.Web.UI.Page
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int sortOrder = 0;
                DataTable dtsort = D.GetDataTable("SELECT ISNULL(MAX(Seq),0)+1 as maxid FROM SiteMenuMaster");
                if (dtsort.Rows.Count > 0)
                {
                    sortOrder = Convert.ToInt32(dtsort.Rows[0]["maxid"]);
                }
                else
                {
                    sortOrder = 1;
                }
                D.ExecuteQuery("insert into SiteMenuMaster(Name,Url,Type,Seq,Status) values('" + txtmenuname.Text + "','" + txtpagename.Text + "','" + ddlmenutype.SelectedValue + "','" + txtsequance.Text + "','" + Convert.ToBoolean(chkStatus.Checked) + "')");

                //_Menu.Insert(txtMenuName.Text, sortOrder, chkStatus.Checked, txtIcon.Text, txtPageName.Text, ddlMenuType.SelectedValue);
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = "Save Successfully";
                ClearAll();
                BindData();

                int maxid = D.GetMaxId("SELECT ISNULL(MAX(ID),0) as maxid FROM SiteMenuMaster");
                if (chkStatus.Checked == true)
                {
                    DataTable dtClient = D.GetDataTable("select * from ClientMaster");
                    if (dtClient.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtClient.Rows)
                        {
                            //_menucl.Insert(Convert.ToInt32(row["ClientID"]), maxid);
                        }
                    }
                }
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = "Save Successfully";
                //success.Visible = true;
                //alert.Visible = false;
                ClearAll();
                BindData();
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = "<br />" + ex.Message;
                //  success.Visible = false;
                //  alert.Visible = true;
            }
        }
        private void BindData()
        {
            DataTable dt = D.GetDataTable("select * from SiteMenuMaster");
            gv.DataSource = dt;
            gv.DataBind();
        }
        private void ClearAll()
        {
            txtmenuname.Text = "";
            txtsequance.Text = "";
            chkStatus.Checked = false;
            txtpagename.Text = "";
            //txtPageName.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                D.ExecuteQuery("update SiteMenuMaster SET Name='" + txtmenuname.Text + "', Seq='" + txtsequance.Text + "', Url='" + txtpagename.Text + "', Type='" + ddlmenutype.SelectedValue + "', Status='" + Convert.ToBoolean(chkStatus.Checked) + "' where id=" + btnupdate.CommandArgument);
                //_Menu.Update(txtMenuName.Text, Convert.ToInt32(txtseq.Text), chkStatus.Checked, txtIcon.Text, txtPageName.Text, ddlMenuType.SelectedValue, Convert.ToInt32(btnUpdate.CommandArgument));
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = "Save Successfully";

                //btnSave.Visible = true;
                //btnUpdate.Visible = false;
                //success.Visible = true;
                //alert.Visible = false;
                //ClearAll();
                BindData();
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = "<br />" + ex.Message;
                //    success.Visible = false;
                //   alert.Visible = true;
            }
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            try
            {


                btnupdate.Visible = true;
                btnsave.Visible = false;
                LinkButton lb = (LinkButton)sender;
                string id = lb.CommandArgument;
                btnupdate.CommandArgument = lb.CommandArgument;
                DataTable dt = D.GetDataTable("select * from SiteMenuMaster where id=" + id);
                if (dt.Rows.Count > 0)
                {
                    //imgImage.ImageUrl = "img/" + dt.Rows[0]["image"].ToString();
                    txtmenuname.Text = dt.Rows[0]["Name"].ToString();
                    txtpagename.Text = dt.Rows[0]["Url"].ToString();
                    txtsequance.Text = dt.Rows[0]["Seq"].ToString();
                    ddlmenutype.SelectedValue = dt.Rows[0]["Type"].ToString();
                    chkStatus.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
                }
            }
            catch
            {
            }
        }

        //protected void lbEdit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LinkButton lb = (LinkButton)sender;
        //        btnUpdate.CommandArgument = lb.CommandArgument;
        //        DataTable dt = _Menu.GetSiteMenuDataByID(Convert.ToInt32(lb.CommandArgument));
        //        if (dt.Rows.Count > 0)
        //        {
        //            txtMenuName.Text = dt.Rows[0]["Name"].ToString();
        //            txtseq.Text = dt.Rows[0]["Seq"].ToString();
        //            txtPageName.Text = dt.Rows[0]["Url"].ToString();
        //            txtIcon.Text = dt.Rows[0]["Icon"].ToString();
        //            ddlMenuType.SelectedValue = dt.Rows[0]["Type"].ToString();
        //            chkStatus.Checked = Convert.ToBoolean(dt.Rows[0]["Status"].ToString());
        //        }
        //        btnSave.Visible = false;
        //        btnUpdate.Visible = true;
        //    }
        //    catch { }
        //}

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                string id = lb.CommandArgument;
                D.ExecuteQuery("delete from sitemenumaster where id=" + id);
                //_Menu.Delete(Convert.ToInt32(lb.CommandArgument));
                divSuccess.Visible = true;
                divError.Visible = false;
                lblSuccess.Text = "Delete Successfully";
                BindData();

            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divError.Visible = true;
                lblError.Text = "<br />" + ex.Message;
            }
        }
    }
}