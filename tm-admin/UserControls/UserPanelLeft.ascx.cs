using TaskManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager.tm_admin.UserControls
{
    public partial class UserPanelLeft : System.Web.UI.UserControl
    {
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Order_Id"] != null && Request.QueryString["Cust_Id"] != null)
                {
                    string order_id = Request.QueryString["Order_Id"].ToString();
                    string Cust_Id = Request.QueryString["Cust_Id"].ToString();
                    BindData(order_id, Cust_Id);
                }
            }
        }
        private void BindData(string order_id, string Cust_Id)
        {
            string str = "";
            DataTable dt = D.GetDataTable("select * from CUSTOMER where ID=" + Cust_Id);
            if (dt.Rows.Count > 0)
            {
                str += "<li><i class='zmdi zmdi-name'></i>" +
                    dt.Rows[0]["NAMe"].ToString() + "</li>" +
                "<li><i class='zmdi zmdi-phone'></i>" +
                 dt.Rows[0]["MOBILE"].ToString() + "</li>" +
    "            <li><i class='zmdi zmdi-email'></i>" +
                dt.Rows[0]["EMAIL"].ToString() + "</li>" +
                "<li>" +
                 "   <i class='zmdi zmdi-pin'></i>" +
                  "  <address class='m-b-0'>" +
                   dt.Rows[0]["BILLING_ADDRESS"].ToString()
                   + "</address>" +
                "</li>";

                ltrImage.Text = "<img class='img-responsive' src='" + dt.Rows[0]["PHOTO"] + "' alt=''>";
            }
            ltrContact.Text = str;
        }
    }
}