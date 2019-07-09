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
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                //BindState();
                //BindDesighnation();
                //BindBranch();

                string name = Request.Cookies["ADMIN_NAME"].Value;
                //if (name != "admin")
                //{
                //    foreach (GridViewRow row in gv.Rows)
                //    {
                //        //access control here
                //        LinkButton control = (LinkButton)row.FindControl("lbDelete");
                //        control.Visible = false;
                //        LinkButton controledit = (LinkButton)row.FindControl("lbEdit");
                //        controledit.Visible = false;
                //    }
                //}
                try
                {
                    if (Request.QueryString["ID"] != null)
                    {

                        string empId = Request.QueryString["ID"].ToString();
                        if (name != "")
                        {
                            DataTable dt = D.GetDataTable("select * from [dbo].[EMPLOYEE_MASTER] where id = " + empId);
                            txtEmployeeId.Text = dt.Rows[0]["EMPLOYEE_ID"].ToString();
                            EMAIL.Text = dt.Rows[0]["EMAIL"].ToString();
                            FIRST_NAME.Text = dt.Rows[0]["FIRST_NAME"].ToString();
                            LAST_NAME.Text = dt.Rows[0]["LAST_NAME"].ToString();
                            DOB.Text = dt.Rows[0]["DOB"].ToString();
                            //ddldesighnation.SelectedValue = dt.Rows[0]["POST_ID"].ToString();
                            MOBILE_NUMBER.Text = dt.Rows[0]["MOBILE_NUMBER"].ToString();
                            //ALT_MOBILE_NUMBER.Text = dt.Rows[0]["ALTERNATE_MOBILE"].ToString();
                            RES_ADDRESS.Text = dt.Rows[0]["ADDRESS"].ToString();
                            R_LANDMARK.Text = dt.Rows[0]["LANDMARK"].ToString();
                            R_AREA.Text = dt.Rows[0]["AREA"].ToString();
                            txtPinCode.Text = dt.Rows[0]["PINCODE"].ToString();
                            chkStatus.Checked = Convert.ToBoolean(dt.Rows[0]["STATUS"].ToString());
                            //BLOOD_GROUP.SelectedValue = dt.Rows[0]["BLOOD_GROUP"].ToString();
                            //ddlZone.SelectedValue = dt.Rows[0]["ZONE"].ToString();
                            //ddlState.SelectedValue = dt.Rows[0]["STATE"].ToString();
                            //FillCity();
                            //ddlCity.SelectedValue = dt.Rows[0]["CITY"].ToString();
                            //ddlbranch.SelectedValue = dt.Rows[0]["BRANCH_ID"].ToString();
                            //ddlStatus.SelectedValue = dt.Rows[0]["STATUS"].ToString();
                            lbupdate.Visible = true;
                            Submit.Visible = false;
                        }
                    }
                }
                catch
                {

                }

            }
        }
        private void GetData()
        {
            DataTable dt = D.GetDataTable("select * from [dbo].[EMPLOYEE_MASTER] order by FIRST_NAME asc");
            gv.DataSource = dt;
            gv.DataBind();
        }

        protected void BindState()
        {
            try
            {
                DataTable dt = D.GetDataTable("select * from StateMaster where CountryID=101");
                ddlState.DataSource = dt;
                ddlState.DataValueField = "ID";
                ddlState.DataTextField = "Name";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select State", "0"));
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
            }
            catch
            {
            }
        }
        protected void BindBranch()
        {
            try
            {
                DataTable dt = D.GetDataTable("select * from BRANCH_MASTER");
                ddlbranch.DataSource = dt;
                ddlbranch.DataValueField = "ID";
                ddlbranch.DataTextField = "branchname";
                ddlbranch.DataBind();
                ddlbranch.Items.Insert(0, new ListItem("Select Branch", "0"));

            }
            catch
            {
            }
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCity();
        }

        private void FillCity()
        {
            DataTable dt = D.GetDataTable("SELECT * FROM CITYMASTER where StateId=" + ddlState.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                ddlCity.DataSource = dt;
                ddlCity.DataValueField = "ID";
                ddlCity.DataTextField = "NAme";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
            }
        }
        private void BindDesighnation()
        {
            DataTable dt = D.GetDataTable("SELECT * FROM POST_MASTER");
            if (dt.Rows.Count > 0)
            {
                ddldesighnation.DataSource = dt;
                ddldesighnation.DataValueField = "ID";
                ddldesighnation.DataTextField = "NAME";
                ddldesighnation.DataBind();
            }
        }
        protected void lbupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string empId = Request.QueryString["ID"].ToString();
                D.ExecuteQuery("UPDATE employee_master SET PINCODE='" + txtPinCode.Text + "', STATUS='" + Convert.ToBoolean(chkStatus.Checked) + "',  EMAIL='" + EMAIL.Text + "',FIRST_NAME='" + FIRST_NAME.Text + "',LAST_NAME='" + LAST_NAME.Text + "',DOB='" + DOB.Text + "',MOBILE_NUMBER='" + MOBILE_NUMBER.Text + "',ADDRESS='" + RES_ADDRESS.Text + "',LANDMARK='" + R_LANDMARK.Text + "',AREA='" + R_AREA.Text + "' where id='" + empId + "'");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Update Successfully, .');window.location ='EmployeeMaster.aspx';", true);

            }
            catch { }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = D.GetDataTable("select * from employee_master where Email='" + EMAIL.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email already exists !');", true);
                }
                else
                {
                    D.ExecuteQuery("insert into employee_master (EMAIL,FIRST_NAME,LAST_NAME,DOB,MOBILE_NUMBER,ADDRESS,LANDMARK,AREA,PASSWORD,STATUS,PINCODE) values('" + EMAIL.Text + "','" + FIRST_NAME.Text + "','" + LAST_NAME.Text + "','" + DOB.Text + "','" + MOBILE_NUMBER.Text + "','" + RES_ADDRESS.Text + "','" + R_LANDMARK.Text + "','" + R_AREA.Text + "','patkar12345','" + Convert.ToBoolean(chkStatus.Checked) + "','" + txtPinCode.Text + "')");

                    divSuccess.Visible = true;
                    divError.Visible = false;
                    ClearAll();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "alert", "alert('Employee Added Successfully'); parent.location.href='EmployeeMaster.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                divSuccess.Visible = false;
                divError.Visible = true;
            }
        }

        private void ClearAll()
        {
            EMAIL.Text = "";
            //PASSWORD.Text = "";
            FIRST_NAME.Text = "";
            LAST_NAME.Text = "";
            DOB.Text = "";
            //ANNIVERSARY_DATE.Text = "";
            //VEHICLE_DATE.Text = "";
            //VEHICLE_NUMBER.Text = "";
            //DL_NUMBER.Text = "";
            //PASSPORT_NO.Text = "";
            MOBILE_NUMBER.Text = "";
            //REF_ONE_NAME.Text = "";
            //REF_ONE_MOBILE.Text = "";
            //REF_ONE_COMP.Text = "";
            //REF_TOW_COMP.Text = "";
            //REF_TOW_MOBILE.Text = "";
            //REF_TWO_NAME.Text = "";
            //EMRG_NUMBER.Text = "";
            EMAIL.Text = "";
            FIRST_NAME.Text = "";
            LAST_NAME.Text = "";
            DOB.Text = "";
            //ANNIVERSARY_DATE.Text = "";
            //VEHICLE_DATE.Text = "";
            //VEHICLE_NUMBER.Text = "";
            //DL_NUMBER.Text = "";
            //PASSPORT_NO.Text = "";
            MOBILE_NUMBER.Text = "";
            ALT_MOBILE_NUMBER.Text = "";
            txtPinCode.Text = "";
            //REF_ONE_NAME.Text = "";
            //REF_ONE_MOBILE.Text = "";
            //REF_ONE_COMP.Text = "";
            //REF_TOW_COMP.Text = "";
            //REF_TOW_MOBILE.Text = "";
            //REF_TWO_NAME.Text = "";
            //EMRG_NUMBER.Text = "";
        }
        protected void lbDelete_Click(Object Sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)Sender;
                int id = Convert.ToInt32(lb.CommandArgument.ToString());
                D.ExecuteQuery("delete from EMPLOYEE_MASTER where Id=" + id);

                divSuccess.Visible = true;
                divError.Visible = false;

                GetData();
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
            int id = Convert.ToInt32(lb.CommandArgument.ToString());
            Response.Redirect("EmployeeMaster.aspx?ID=" + id);
        }

    }
}