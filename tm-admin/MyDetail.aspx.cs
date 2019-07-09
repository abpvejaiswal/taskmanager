using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using TaskManager.Models;
using System.Data.SqlClient;
namespace TaskManager.tm_admin
{

    public partial class MyDetail : System.Web.UI.Page
    {

        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            try
            {
                string EMP_ID = Request.Cookies["ADMIN_ID"].Value;

                DataTable dt = D.GetDataTable("select * from EMPLOYEE_MASTER where ID=" + EMP_ID);
                if (dt.Rows.Count > 0)
                {
                    txtFirstName.Text = dt.Rows[0]["FIRST_NAME"].ToString();
                    txtLastName.Text = dt.Rows[0]["LAST_NAME"].ToString();

                    if (dt.Rows[0]["DOB"].ToString() != "")
                    {
                        txtDOB.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString()).ToString("yyyy-MM-dd");
                    }
                    
                    txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                    txtMobile.Text = dt.Rows[0]["MOBILE_NUMBER"].ToString();
                    ltrAddress.Text = dt.Rows[0]["ADDRESS"].ToString() + "<br>" + dt.Rows[0]["LANDMARK"].ToString() + " , " + dt.Rows[0]["AREA"].ToString() + " , " + dt.Rows[0]["PINCODE"].ToString();
                }
            }
            catch
            {

            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string EMP_ID = Request.Cookies["ADMIN_ID"].Value;
                DataTable dt = D.GetDataTable("select * from employee_master where ID!=" + EMP_ID + " and Email='" + txtEmail.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email already exists !');", true);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE_EMPLOYEE_DETAIL";
                    cmd.Parameters.AddWithValue("@EMP_ID", EMP_ID);
                    cmd.Parameters.AddWithValue("@FIRST_NAME", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LAST_NAME", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MOBILE_NUMBER", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                    D.ExecuteQueryWithSP(cmd);
                    BindData();
                    divError.Visible = false;
                    divSuccess.Visible = true;

                }
            }
            catch
            {
                divError.Visible = true;
                divSuccess.Visible = false;

            }
        }
    }
}