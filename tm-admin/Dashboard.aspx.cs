using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManager.Models;
using System.Data;
using System.Data.SqlClient;
namespace TaskManager.tm_admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                if (Request.Cookies["ADMIN_NAME"].Value == "admin")
                {
                    divActiveLead.Visible = false;
                }
                else
                {
                    //BindActiveLeads();
                    //BindActiveLeadFollowup();
                }
            }
        }

        private void BindActiveLeadFollowup()
        {
            try
            {
                string EMP_ID = Request.Cookies["ADMIN_ID"].Value;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GET_TODAY_LEAD_FOLLOWUP";
                cmd.Parameters.Add("@EMP_ID", EMP_ID);

                DataTable dt = D.GetDataWithSP(cmd);

                //            DataTable dt = D.GetDataTable("select lf.*,lm.EMAIL,lm.EMPID,lm.clientname,lm.MOBILE as LEAD_MOBILE,lm.LEAD_DATE  " +
                //"from LEAD_FOLLOWUP as lf,LEAD_MASTER as lm where lf.LEAD_ID = lm.id and CONVERT(date,lf.FOLLOWUP_DATE)=CONVERT(date,getdate())");

                rpLeadFollowup.DataSource = dt;
                rpLeadFollowup.DataBind();
                divNoDataLF.Visible = false;
                if (dt.Rows.Count <= 0)
                {
                    divNoDataLF.Visible = true;
                }

            }
            catch
            {

            }

        }
        protected void lbEdit_Click(object sender, EventArgs e)
        {

            addfollowup.Visible = true;
            btnupdate.Visible = true;
            LinkButton lb = (LinkButton)sender;
            string id = lb.CommandArgument;
            btnupdate.CommandArgument = lb.CommandArgument;
            DataTable dt = D.GetDataTable("select * from LEAD_FOLLOWUP where id=" + id);
            if (dt.Rows.Count > 0)
            {
                txtfollowdate.Text = Convert.ToDateTime(dt.Rows[0]["FOLLOWUP_DATE"].ToString()).ToString("yyyy-MM-dd");
                txtnote.Text = dt.Rows[0]["NOTE"].ToString();
            }
            txtfollowdate.Enabled = false;
        }
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {

                string id = btnupdate.CommandArgument;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE_LEAD_FOLLOWUP";
                cmd.Parameters.Add("@FOLLOWUP_ID", id);
                cmd.Parameters.Add("@NOTE", txtnote.Text);
                D.ExecuteQueryWithSP(cmd);


                addfollowup.Visible = false;
                divSuccess.Visible = true;
                lblSuccess.Text = "Followup Updated Successfully";
                BindActiveLeadFollowup();
            }
            catch (Exception ex)
            {
                addfollowup.Visible = true;
                divSuccess.Visible = false;
                divModalError.Visible = true;
                lblError.Text = "<br />" + ex.Message;
            }
        }
        protected void lbClose_Click(object sender, EventArgs e)
        {
            addfollowup.Visible = false;
        }
        protected void BindActiveLeads()
        {
            try
            {
                string EMP_ID = Request.Cookies["ADMIN_ID"].Value;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GET_ACTIVE_LEAD";
                cmd.Parameters.Add("@EMP_ID", EMP_ID);
                DataTable dt = D.GetDataWithSP(cmd);
                //DataTable dt = D.GetDataTable("select cm.NAME as CITY_NAME,sm.NAME as STATE_NAME, em.FIRST_NAME+ ' '+em.LAST_NAME as ASSIGNED_BY,lm.* from LEAD_MASTER as lm,EMPLOYEE_MASTER as em,CityMaster as cm,StateMaster as sm where sm.ID=cm.StateID and lm.CITY=cm.ID and sm.ID=lm.STATE and em.ID=lm.ADDED_BY and lm.EMPID=" + EMP_ID);
                rpActiveLeads.DataSource = dt;
                rpActiveLeads.DataBind();
                divNoDataAL.Visible = false;
                if (dt.Rows.Count <= 0)
                {
                    divNoDataAL.Visible = true;
                }
            }
            catch
            {

            }
        }
        private void BindData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("@EMP_ID", Request.Cookies["ADMIN_ID"].Value);
                
                if (Request.Cookies["POST_ID"].Values.ToString() != "1"){
                    cmd.Parameters.Add("@ROLE", "EMP");
                }
                else
                {
                    cmd.Parameters.Add("@ROLE", "ADMIN");              
                }
                
                cmd.CommandText = "GET_DASHBOARD_COUNT";
                DataTable dt = D.GetDataWithSP(cmd);
                ltrTodayTask.Text = dt.Rows[0]["TODAY_OVERDUE_TASK"].ToString();
                ltrTotalTask.Text = dt.Rows[0]["TOTAL_TASK"].ToString();
                ltrTotalTask.Text = dt.Rows[0]["TOTAL_OPEN_TASK"].ToString();
                ltrNotStarted.Text = dt.Rows[0]["NOT_STARTED"].ToString();
                ltrInprogress.Text = dt.Rows[0]["IN_PROGRESS"].ToString();
                ltrWaitingforinput.Text = dt.Rows[0]["WAITING_FOR_INPUT"].ToString();
                ltrCompleted.Text = dt.Rows[0]["COMPLETED"].ToString();
            }
            catch
            {

            }

        }

    }
}