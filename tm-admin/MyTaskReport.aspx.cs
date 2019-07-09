using TaskManager.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager.tm_admin
{
    public partial class MyTaskReport : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ConnectionString.ToString());
        GetData D = new GetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //    BindData();
            }
        }

        private void BindData()
        {
            string emp_id = Request.Cookies["admin_id"].Value;
            string dropdown_filter = ddlFilter.SelectedValue;
            string where = "";
            if (dropdown_filter == "filterbydate")
            {
                where = " and convert(date," + ddlColumn.SelectedValue + ") between '" + txtFromDate.Text + "' and '" + txtToDate.Text + "'";
            }
            else
            {
                where = " and MONTH(" + ddlColumn.SelectedValue + ")=MONTH(DATEADD(MONTH," + dropdown_filter + ",getdate())) and YEAR(" + ddlColumn.SelectedValue + ")=YEAR(getdate())";
            }

            //string qry = "select convert(VARCHAR,tm.due_date,106) as DUEDATE,em.first_name+' '+em.last_name as TASK_OWNER_NAME,tm.* from TASK_MASTER as tm,employee_master1 as em  where em.ID=tm.TASK_OWNER and tm.ASSIGN_TO=" + emp_id + where + " order by tm.DUE_DATE asc";
            DataTable dt = D.GetDataTable("select CASE WHEN  CLOSED_DATE IS NOT NULL THEN 1 ELSE 0 END as TOTAL_CLOSED_TAK,CASE WHEN  CONVERT(date,CLOSED_DATE)<=CONVERT(date,DUE_DATE) THEN 1 ELSE 0 END as TOTAL_TASK_COMPLETED_ONTIME,CASE WHEN  CONVERT(date,getdatE())>CONVERT(date,DUE_DATE) THEN 1 ELSE 0 END as OVERDUE_DIFFERNCE,convert(VARCHAR,tm.due_date,106) as DUEDATE,em.first_name+' '+em.last_name as TASK_OWNER_NAME,tm.* from TASK_MASTER as tm,employee_master1 as em " +
                            " where em.ID=tm.TASK_OWNER and tm.ASSIGN_TO=" + emp_id + where);

            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "GET_MY_TASK_REPORT";
            //cnn.Open();
            //cmd.Connection = cnn;
            //cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            //cmd.Parameters.AddWithValue("@WHERE", where);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //cnn.Close();

            gvTask.DataSource = dt;
            gvTask.DataBind();

            // Bind Total Closed Task
            int TOTAL_CLOSED_TAK = dt.AsEnumerable().Sum(row => row.Field<int>("TOTAL_CLOSED_TAK"));
            gvTask.FooterRow.Cells[0].Text = "<p class='m-b-5' style='font-weight:bold;text-align:right;'>Total Task</p>";
            gvTask.FooterRow.Cells[1].Text = "<b>" + dt.Rows.Count + "</b>";

            // Bind Total Overdue Task
            int total_overdue = dt.AsEnumerable().Sum(row => row.Field<int>("OVERDUE_DIFFERNCE"));
            int total_task = dt.Rows.Count;
            int total = total_task - total_overdue;
            gvTask.FooterRow.Cells[2].Text = "<p class='m-b-5' style='font-weight:bold;text-align:right;'>Total Overdue Task</p>";
            gvTask.FooterRow.Cells[3].Text = "<b>" + total_overdue + "</b>";

            // Bind Effieciency 
            int completed_within_duedate = dt.AsEnumerable().Sum(row => row.Field<int>("TOTAL_TASK_COMPLETED_ONTIME"));
            decimal effieciency = 0;
            effieciency = (completed_within_duedate * 100) / total_task;
            gvTask.FooterRow.Cells[4].Text = "<p class='m-b-5' style='font-weight:bold;text-align:right;'>Efficiency</p>";
            gvTask.FooterRow.Cells[5].Text = "<b>" + effieciency.ToString("f2") + "</b>";


        }

        protected void lbFilter_Click(object sender, EventArgs e)
        {
            try
            {

                BindData();
            }
            catch
            {

            }
        }

        protected void lbExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=TASK_REPORT_" + DateTime.Now.ToString("ddd-MMM-yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                //To Export all pages
                gvTask.AllowPaging = false;
                BindData();

                gvTask.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in gvTask.HeaderRow.Cells)
                {
                    cell.BackColor = gvTask.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvTask.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvTask.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvTask.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvTask.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void ExportToPDF(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gvTask.AllowPaging = false;
                    this.BindData();

                    gvTask.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=TASK_REPORT_" + DateTime.Now.ToString("ddd-MMM-yyyy") + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        protected void lbExportExcel1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=RepeaterExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                rpMyTask.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            catch
            {

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}