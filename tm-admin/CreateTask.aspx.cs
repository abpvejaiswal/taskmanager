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
    public partial class CreateTask : System.Web.UI.Page
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployee();
                BindClientGroup();
                BindNatureOfWork();
                BindContactPerson();
                BindYear();

            }
        }
        private void BindEmployee()
        {
            DataTable dt = D.GetDataTable("SELECT ID ,first_name +' '+ last_name as NAME FROM employee_master order by FIRST_NAME asc");
            if (dt.Rows.Count > 0)
            {
                ddlEmployee.DataSource = dt;
                ddlEmployee.DataValueField = "ID";
                ddlEmployee.DataTextField = "NAME";
                ddlEmployee.DataBind();
            }
            ddlEmployee.Items.Insert(0, new ListItem("Select Employee", "0"));
        }

        private void BindClientGroup()
        {
            DataTable dt = D.GetDataTable("SELECT * FROM CLIENT_GROUP_MASTER order by CLIENT_GROUP_NAME asc");
            if (dt.Rows.Count > 0)
            {
                ddlClientGroup.DataSource = dt;
                ddlClientGroup.DataValueField = "ID";
                ddlClientGroup.DataTextField = "CLIENT_GROUP_NAME";
                ddlClientGroup.DataBind();
            }
            ddlClientGroup.Items.Insert(0, new ListItem("Select Client Group", "0"));
        }

        private void BindNatureOfWork()
        {
            DataTable dt = D.GetDataTable("SELECT * FROM NATURE_OF_WORK order by NATURE_OF_WORK asc");
            if (dt.Rows.Count > 0)
            {
                ddlNatureOfWork.DataSource = dt;
                ddlNatureOfWork.DataValueField = "ID";
                ddlNatureOfWork.DataTextField = "NATURE_OF_WORK";
                ddlNatureOfWork.DataBind();
            }
            ddlNatureOfWork.Items.Insert(0, new ListItem("Select Nature Of Work", "0"));
        }

        private void BindContactPerson()
        {
            DataTable dt = D.GetDataTable("SELECT *, CONTACT_NUMBER + ',' + EMAIL_ID as NUMBER_EMAIL FROM CONTACT_MASTER order by CONTACT_PERSON asc");
            if (dt.Rows.Count > 0)
            {
                ddlContactPerson.DataSource = dt;
                ddlContactPerson.DataValueField = "NUMBER_EMAIL";
                ddlContactPerson.DataTextField = "CONTACT_PERSON";
                ddlContactPerson.DataBind();
            }
            ddlContactPerson.Items.Insert(0, new ListItem("Select Contact Person", "0"));
        }

        private void BindYear()
        {
            DataTable dt = D.GetDataTable("SELECT FINANCIAL_YEAR +' => '+ ASSESSMENT_YEAR as DISPLAY_YEAR,* FROM YEAR_MASTER order by FINANCIAL_YEAR asc");
            if (dt.Rows.Count > 0)
            {
                ddlYear.DataSource = dt;
                ddlYear.DataValueField = "ASSESSMENT_YEAR";
                ddlYear.DataTextField = "FINANCIAL_YEAR";
                ddlYear.DataBind();
            }
            ddlYear.Items.Insert(0, new ListItem("Select Financial Year/Month", "0"));
        }

        protected void ddlContactPerson_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}