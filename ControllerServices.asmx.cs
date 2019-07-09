using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using TaskManager.Models;

namespace TaskManager
{
    /// <summary>
    /// Summary description for ControllerServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ControllerService : System.Web.Services.WebService
    {

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ConnectionString);
        GetData D = new GetData();
        //public ControllerServices()
        //{

        //    //Uncomment the following line if using designed components 
        //    //InitializeComponent(); 
        //}


        [WebMethod]

        public void GetAllItemData(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<AllProduct> cm = new List<AllProduct>();
            List<GeneralDataAllProduct> g = new List<GeneralDataAllProduct>();
            try
            {
                if (ACTION == "getallitemdata")
                {

                    string qry = "select * from ITEM_MASTER";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataAllProduct data = new GeneralDataAllProduct();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            AllProduct d = new AllProduct();
                            d.id = row["id"].ToString();
                            d.Name = row["itemname"].ToString();
                            d.Watt = row["watt"].ToString();
                            cm.Add(d);
                        }
                        data.getallproduct = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataAllProduct data = new GeneralDataAllProduct();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataAllProduct data = new GeneralDataAllProduct();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]
        public void GetClientDataData(string ACTION, string ClientID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<ClientData> cm = new List<ClientData>();
            List<GeneralDataClientData> g = new List<GeneralDataClientData>();
            try
            {
                if (ACTION == "getclient")
                {

                    string qry = "select * from LEAD_MASTER where ID = " + ClientID;

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataClientData data = new GeneralDataClientData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            ClientData d = new ClientData();
                            d.id = row["id"].ToString();
                            d.mobile = row["MOBILE"].ToString();
                            d.email = row["EMAIL"].ToString();
                            d.address = row["ADDRESS"].ToString();
                            d.valueoflead = row["VALUE_OF_LEAD"].ToString();
                            d.refe = row["REFERENCE"].ToString();
                            d.source = row["SOURCE_OF_LEAD"].ToString();
                            cm.Add(d);
                        }
                        data.getclient = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataClientData data = new GeneralDataClientData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataClientData data = new GeneralDataClientData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
      
        [WebMethod]

        public void GetEnquiryData(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<EnquiryData> cm = new List<EnquiryData>();
            List<GeneralDataGetEnquiryDataData> g = new List<GeneralDataGetEnquiryDataData>();
            try
            {

                string qry = "";
                string cookiename = HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value;
                if (ACTION == "getenquirydata")
                {
                    if (cookiename == "admin")
                    {
                        qry = "select em.*,cm.NAME as CITY_NAME,sm.NAME as STATE_NAME,bm.BENEFICIARY_NAME from CLIENT_MASTER as em LEFT OUTER JOIN LEAD_MASTER as lm on lm.ID=em.clientid left outer join CityMaster as cm on em.CITY=cm.ID left outer join StateMaster as sm on sm.ID=cm.StateID and sm.ID=em.STATE LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bankid order by id desc";
                    }
                    else
                    {
                        string cookieid = HttpContext.Current.Request.Cookies["ADMIN_ID"].Value;
                        qry = "select em.*,cm.NAME as CITY_NAME,sm.NAME as STATE_NAME,bm.BENEFICIARY_NAME from CLIENT_MASTER as em LEFT OUTER JOIN LEAD_MASTER as lm on lm.ID=em.clientid left outer join CityMaster as cm on em.CITY=cm.ID left outer join StateMaster as sm on sm.ID=cm.StateID and sm.ID=em.STATE LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bankid where em.empid = " + cookieid + " order by id desc";
                    }
                }
                else if (ACTION == "getallenquirydata")
                {
                    qry = "select em.*,cm.NAME as CITY_NAME,sm.NAME as STATE_NAME,bm.BENEFICIARY_NAME from CLIENT_MASTER as em LEFT OUTER JOIN LEAD_MASTER as lm on lm.ID=em.clientid left outer join CityMaster as cm on em.CITY=cm.ID left outer join StateMaster as sm on sm.ID=cm.StateID and sm.ID=em.STATE LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bankid order by id desc";
                }
                else
                {
                    return;
                }


                DataTable dt = D.GetDataTable(qry);
                if (dt.Rows.Count > 0)
                {
                    GeneralDataGetEnquiryDataData data = new GeneralDataGetEnquiryDataData();
                    data.MESSAGE = "";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    foreach (DataRow row in dt.Rows)
                    {
                        EnquiryData d = new EnquiryData();
                        d.eid = row["id"].ToString();
                        d.cid = row["clientid"].ToString();
                        d.clientname = row["clientname"].ToString();
                        d.mobile = row["mobile"].ToString();
                        d.zone = row["Zone"].ToString();
                        d.email = row["email"].ToString();
                        d.address = row["address"].ToString();
                        d.contact_person = row["contact_person"].ToString();
                        //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                        //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                        d.valueoflead = row["value_of_lead"].ToString();
                        d.reference = row["reference"].ToString();
                        d.sourceoflead = row["source_of_lead"].ToString();
                        d.bank = row["BENEFICIARY_NAME"].ToString();
                        d.state = row["STATE_NAME"].ToString();
                        d.city = row["CITY_NAME"].ToString();
                        d.tax = row["tax"].ToString();
                        d.subtotal = row["sub_total"].ToString();
                        d.total = row["total"].ToString();
                        string cookie = HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value;
                        if (cookie == "admin")
                        {
                            d.is_show = "1";
                        }
                        else
                        {
                            d.is_show = "0";
                        }
                        List<EnquiryProductData> pd = new List<EnquiryProductData>();
                        DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[ENQUIRY_PRODUCT_MASTER] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.item_id where enquiry_id = " + row["id"].ToString());
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            EnquiryProductData ep = new EnquiryProductData();
                            ep.eid = row2["ENQUIRY_ID"].ToString();
                            ep.itemname = row2["itemname"].ToString();
                            ep.unit = row2["UNIT"].ToString();
                            ep.qty = row2["QTY"].ToString();
                            ep.unit_price = row2["UNIT_PRICE"].ToString();
                            ep.subtotal = row2["SUB_TOTAL_PRICE"].ToString();
                            pd.Add(ep);
                        }
                        d.GetEnquiryProductData = pd;
                        cm.Add(d);
                    }
                    data.GetEnquiryData = cm;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
                else
                {
                    GeneralDataGetEnquiryDataData data = new GeneralDataGetEnquiryDataData();
                    data.MESSAGE = "Data Not Found ! ";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                }
                Context.Response.Write(js.Serialize(g[0]));
                return;

            }
            catch (Exception ex)
            {
                GeneralDataGetEnquiryDataData data = new GeneralDataGetEnquiryDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]

        public void GetSingleEnquiryData(string ACTION, string EID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<EnquiryData> cm = new List<EnquiryData>();
            List<GeneralDataGetEnquiryDataData> g = new List<GeneralDataGetEnquiryDataData>();
            try
            {
                if (ACTION == "getenquirydata")
                {
                    string qry = "";

                    qry = "select em.*,bm.BENEFICIARY_NAME from CLIENT_MASTER as em LEFT OUTER JOIN LEAD_MASTER as lm on lm.ID=em.clientid LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bankid where em.ID = " + EID + " order by id desc";
                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGetEnquiryDataData data = new GeneralDataGetEnquiryDataData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            EnquiryData d = new EnquiryData();
                            d.eid = row["id"].ToString();
                            d.cid = row["clientid"].ToString();
                            d.clientname = row["clientname"].ToString();
                            d.mobile = row["mobile"].ToString();
                            d.email = row["email"].ToString();
                            d.address = row["address"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            d.valueoflead = row["value_of_lead"].ToString();
                            d.reference = row["reference"].ToString();
                            d.sourceoflead = row["source_of_lead"].ToString();
                            d.bank = row["BENEFICIARY_NAME"].ToString();
                            d.tax = row["tax"].ToString();
                            d.subtotal = row["sub_total"].ToString();
                            d.total = row["total"].ToString();
                            string cookie = HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value;
                            if (cookie == "admin")
                            {
                                d.is_show = "1";
                            }
                            else
                            {
                                d.is_show = "0";
                            }
                            List<EnquiryProductData> pd = new List<EnquiryProductData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[ENQUIRY_PRODUCT_MASTER] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.item_id where enquiry_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                EnquiryProductData ep = new EnquiryProductData();
                                ep.eid = row2["ENQUIRY_ID"].ToString();
                                ep.itemname = row2["itemname"].ToString();
                                ep.unit = row2["UNIT"].ToString();
                                ep.qty = row2["QTY"].ToString();
                                ep.unit_price = row2["UNIT_PRICE"].ToString();
                                ep.subtotal = row2["SUB_TOTAL_PRICE"].ToString();
                                pd.Add(ep);
                            }
                            d.GetEnquiryProductData = pd;
                            cm.Add(d);
                        }
                        data.GetEnquiryData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGetEnquiryDataData data = new GeneralDataGetEnquiryDataData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGetEnquiryDataData data = new GeneralDataGetEnquiryDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
      

        [WebMethod]

        public void GetQuotationData(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<QuotationData> cm = new List<QuotationData>();
            List<GeneralDataGetQuotationDataData> g = new List<GeneralDataGetQuotationDataData>();
            try
            {
                if (ACTION == "getquotationdata")
                {
                    string qry = "";
                    //string cookiename = HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value;
                    //if (cookiename == "admin")
                    //{
                    qry = "select em.*,lm.clientname,lm.ADDRESS,bm.BENEFICIARY_NAME,case when em.REVISE_ID = 0 then 'NO' else 'YES' end as revise_status,case when em.approval = 0 then 'Not Updated' when em.approval = 1 then 'Approval' else 'Not Approval' end as StatusName from QUOTATION_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id order by id desc";
                    //}
                    //else
                    //{
                    //string cookieid = HttpContext.Current.Request.Cookies["ADMIN_ID"].Value;
                    //qry = "select em.*,lm.clientname,bm.BENEFICIARY_NAME from QUOTATION_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id where em.approval = 1 order by id desc";
                    //}
                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGetQuotationDataData data = new GeneralDataGetQuotationDataData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            QuotationData d = new QuotationData();
                            d.qid = row["ID"].ToString();
                            d.cid = row["CLIENT_ID"].ToString();
                            d.clientname = row["clientname"].ToString();
                            d.clientaddress = row["ADDRESS"].ToString();
                            d.e_refe = row["ENQUIRY_REFERENCE"].ToString();
                            d.e_date = Convert.ToDateTime(row["ENQUIERY_DATE"].ToString()).ToString("dd-MM-yyyy");
                            d.q_refe = row["QUOTATION_REFERENCE"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            d.q_date = Convert.ToDateTime(row["QUOTATION_DATE"].ToString()).ToString("dd-MM-yyyy");
                            d.delivery_term = row["DELIVERY_TERM"].ToString();
                            d.d_schedule = row["DELIVERY_SCHEDULE"].ToString();
                            d.taxes = row["TAXES"].ToString();
                            d.freight = row["FREIGHT_INSURANCE"].ToString();
                            d.mode_dispatch = row["MODE_OF_DISPATCH"].ToString();
                            d.s_term = row["SPECIAL_TERM"].ToString();
                            d.bank = row["BENEFICIARY_NAME"].ToString();
                            d.freight_changes = row["FREIGHT_CHARGES"].ToString();
                            d.tax = row["TAX"].ToString();
                            d.taxamt = row["TAX_AMT"].ToString();
                            d.subtotal = row["SUB_TOTAL"].ToString();
                            d.total = row["TOTAL_AMT"].ToString();
                            if (HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value == "admin")
                            {
                                d.is_show = "1";
                            }
                            else
                            {
                                d.is_show = "0";
                            }
                            d.approval_status = row["APPROVAL"].ToString();
                            d.revise_status = row["revise_status"].ToString();
                            d.statusname = row["StatusName"].ToString();
                            d.Comment = row["Comment"].ToString();
                            List<QuotationProductData> pd = new List<QuotationProductData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[QUOTATION_ITEM_MASTER] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.itemid where quotation_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                QuotationProductData ep = new QuotationProductData();
                                ep.eid = row2["QUOTATION_ID"].ToString();
                                ep.itemname = row2["itemname"].ToString();
                                ep.unit = row2["UNIT"].ToString();
                                ep.qty = row2["QUANTITY"].ToString();
                                ep.unit_price = row2["UNIT_PRICE"].ToString();
                                ep.subtotal = row2["TOTAL_PRICE"].ToString();
                                pd.Add(ep);
                            }
                            d.GetQuotationProductData = pd;
                            cm.Add(d);
                        }
                        data.GetQuotationData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGetQuotationDataData data = new GeneralDataGetQuotationDataData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGetQuotationDataData data = new GeneralDataGetQuotationDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]

        public void GetSingleQuotationData(string ACTION, string QID)
        {
            string qry = "";
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<QuotationData> cm = new List<QuotationData>();
            List<GeneralDataGetQuotationDataData> g = new List<GeneralDataGetQuotationDataData>();
            try
            {
                if (ACTION == "getsinglequotationdata")
                {

                    //string cookieid = HttpContext.Current.Request.Cookies["ADMIN_ID"].Value;
                    qry = "select em.*,lm.clientname,bm.BENEFICIARY_NAME from QUOTATION_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id where em.ID = " + QID + " order by id desc";
                }
                else if (ACTION == "gethistoryquotationdata")
                {
                    qry = "select em.*,lm.clientname,bm.BENEFICIARY_NAME from QUOTATION_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id where em.client_id = " + QID + " order by id desc";
                }
                else
                {
                    return;
                }
                DataTable dt = D.GetDataTable(qry);
                if (dt.Rows.Count > 0)
                {
                    GeneralDataGetQuotationDataData data = new GeneralDataGetQuotationDataData();
                    data.MESSAGE = "";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = false;
                    data.RECORDS = true;
                    foreach (DataRow row in dt.Rows)
                    {
                        QuotationData d = new QuotationData();
                        d.qid = row["ID"].ToString();
                        d.cid = row["CLIENT_ID"].ToString();
                        d.clientname = row["clientname"].ToString();
                        d.e_refe = row["ENQUIRY_REFERENCE"].ToString();
                        d.e_date = Convert.ToDateTime(row["ENQUIERY_DATE"].ToString()).ToString("yyyy-MM-dd");
                        d.q_refe = row["QUOTATION_REFERENCE"].ToString();
                        //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                        //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                        d.q_date = Convert.ToDateTime(row["QUOTATION_DATE"].ToString()).ToString("yyyy-MM-dd");
                        d.delivery_term = row["DELIVERY_TERM"].ToString();
                        d.d_schedule = row["DELIVERY_SCHEDULE"].ToString();
                        d.taxes = row["TAXES"].ToString();
                        d.freight = row["FREIGHT_INSURANCE"].ToString();
                        d.mode_dispatch = row["MODE_OF_DISPATCH"].ToString();
                        d.s_term = row["SPECIAL_TERM"].ToString();
                        d.p_term = row["PAYMENT_TERMS"].ToString();
                        d.bank = row["BANK_ID"].ToString();
                        d.freight_changes = row["FREIGHT_CHARGES"].ToString();
                        d.tax = row["TAX"].ToString();
                        d.taxamt = row["TAX_AMT"].ToString();
                        d.subtotal = row["SUB_TOTAL"].ToString();
                        d.total = row["TOTAL_AMT"].ToString();
                        if (HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value == "admin")
                        {
                            d.is_show = "1";
                        }
                        else
                        {
                            d.is_show = "0";
                        }
                        d.approval_status = row["APPROVAL"].ToString();
                        List<QuotationProductData> pd = new List<QuotationProductData>();
                        DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[QUOTATION_ITEM_MASTER] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.itemid where quotation_id = " + row["id"].ToString());
                        foreach (DataRow row2 in dt2.Rows)
                        {
                            QuotationProductData ep = new QuotationProductData();
                            ep.eid = row2["ITEMID"].ToString();
                            ep.itemname = row2["itemname"].ToString();
                            ep.unit = row2["UNIT"].ToString();
                            ep.qty = row2["QUANTITY"].ToString();
                            ep.unit_price = row2["UNIT_PRICE"].ToString();
                            ep.subtotal = row2["TOTAL_PRICE"].ToString();
                            pd.Add(ep);
                        }
                        d.GetQuotationProductData = pd;
                        cm.Add(d);
                    }
                    data.GetQuotationData = cm;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
                else
                {
                    GeneralDataGetQuotationDataData data = new GeneralDataGetQuotationDataData();
                    data.MESSAGE = "Data Not Found ! ";
                    data.ORIGINAL_ERROR = "";
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                }
                Context.Response.Write(js.Serialize(g[0]));
                return;

            }
            catch (Exception ex)
            {
                GeneralDataGetQuotationDataData data = new GeneralDataGetQuotationDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]
        public void DeleteEnquiryData(string type, string cid)
        {

            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (type == "deleteenquiry")
            {
                try
                {
                    D.ExecuteQuery("delete from CLIENT_MASTER where ID=" + cid);
                    D.ExecuteQuery("delete from ENQUIRY_PRODUCT_MASTER where ENQUIRY_ID=" + cid);

                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully Deleted";
                    data.ORIGINAL_ERROR = "Successfully Deleted";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Load";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
        }

        [WebMethod]
        public void DeleteQuotationData(string type, string qid)
        {

            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (type == "deletequotation")
            {
                try
                {
                    D.ExecuteQuery("delete from QUOTATION_MASTER where ID=" + qid);
                    D.ExecuteQuery("delete from QUOTATION_ITEM_MASTER where QUOTATION_ID=" + qid);

                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully Deleted";
                    data.ORIGINAL_ERROR = "Successfully Deleted";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Load";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
        }
        [WebMethod]
        public void UpdateQuotationData(string type, string qid, string status, string comment)
        {

            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (type == "updatequotation")
            {
                try
                {
                    //D.ExecuteQuery("delete from QUOTATION_MASTER where ID=" + qid);
                    D.ExecuteQuery("update QUOTATION_MASTER set APPROVAL = " + status + ",COMMENT = '" + comment + "' where ID = " + qid);

                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully Updated";
                    data.ORIGINAL_ERROR = "Successfully Updated";
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Load";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
        }
        [WebMethod]
        public void InsertProformaData(string type, string tax, string subtotal, string total, string Data, string PROFORMA_DATA, string QID, string BANK, string EDate, string PDate)
        {
            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string today = DateTime.Now.ToString("yyyy/MM/dd hh:mm tt");
            //QDATA =[{ CLIENT_ID: '0', EREF: '', EDATE: '', QREF: '', QDATE: '', DTERM: '', DSCHEDULE: '', TAXES: '', FREIGHT: '', DISPATCH: '', STERM: '', BANK: '0' };]
            //data=[{"text":"GOLDI005PM_18S(5WP)","pid":"4","Unit":"nos","Qty":"1","Rate":"1000","Tax":"0","Amount":1000,"$$hashKey":"object:30"}]

            string PERSON = "";
            string PERSON_NO = "";
            string EREF = "";
            string EDATE = "";
            string PREF = "";
            string PDATE = "";
            string DTERM = "";
            string DSCHEDULE = "";
            string TAXES = "";
            string FREIGHT = "";
            string DISPATCH = "";
            string SPECIAL_TERM = "";
            string PURCHASE_TERM = "";
            string GSTNO = "";

            string result = "";
            string result2 = "";
            //string mobile = "";

            string pid = "";
            string Unit = "";
            string Qty = "";
            string Rate = "";
            string Amount = "";
            if (type == "insertproforma")
            {
                try
                {
                    string url2 = "";
                    JavaScriptSerializer _convert2 = new JavaScriptSerializer();
                    url2 = "[" + PROFORMA_DATA + "]";
                    var _Items2 = _convert2.Deserialize<InsertProforma[]>(url2);
                    int cnt2 = _Items2.Length;
                    GeneralData data = new GeneralData();

                    DataTable dt = D.GetDataTable("select client_ID from QUOTATION_MASTER where id = " + QID);

                    for (int i = 0; i < cnt2; i++)
                    {
                        PERSON = (new System.Web.UI.WebControls.ListItem(_Items2[i].PERSON).ToString());
                        PERSON_NO = (new System.Web.UI.WebControls.ListItem(_Items2[i].PERSON_NO).ToString());
                        EREF = (new System.Web.UI.WebControls.ListItem(_Items2[i].EREF).ToString());
                        EDATE = (new System.Web.UI.WebControls.ListItem(_Items2[i].EDATE).ToString());
                        PREF = (new System.Web.UI.WebControls.ListItem(_Items2[i].PREF).ToString());
                        PDATE = (new System.Web.UI.WebControls.ListItem(_Items2[i].PDATE).ToString());
                        DTERM = (new System.Web.UI.WebControls.ListItem(_Items2[i].DTERM).ToString());
                        DSCHEDULE = (new System.Web.UI.WebControls.ListItem(_Items2[i].DSCHEDULE).ToString());
                        TAXES = (new System.Web.UI.WebControls.ListItem(_Items2[i].TAXES).ToString());
                        FREIGHT = (new System.Web.UI.WebControls.ListItem(_Items2[i].FREIGHT).ToString());
                        DISPATCH = (new System.Web.UI.WebControls.ListItem(_Items2[i].DISPATCH).ToString());
                        SPECIAL_TERM = (new System.Web.UI.WebControls.ListItem(_Items2[i].SPECIAL_TERM).ToString());
                        PURCHASE_TERM = (new System.Web.UI.WebControls.ListItem(_Items2[i].PURCHASE_TERM).ToString());
                        GSTNO = (new System.Web.UI.WebControls.ListItem(_Items2[i].GSTNO).ToString());

                        //CLIENT_ID = (new System.Web.UI.WebControls.ListItem(_Items2[i].CLIENT_ID).ToString());


                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_PROFORMA_INVOICE";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@QID", QID);
                        cm.Parameters.AddWithValue("@CLIENTID", dt.Rows[0]["client_ID"].ToString());
                        cm.Parameters.AddWithValue("@PERSON", PERSON);
                        cm.Parameters.AddWithValue("@PERSON_NO", PERSON_NO);
                        cm.Parameters.AddWithValue("@EREF", EREF);
                        cm.Parameters.AddWithValue("@EDATE", EDate);
                        cm.Parameters.AddWithValue("@PREF", PREF);
                        cm.Parameters.AddWithValue("@PDATE", PDate);
                        cm.Parameters.AddWithValue("@DTERM", DTERM);
                        cm.Parameters.AddWithValue("@DSCHEDULE", DSCHEDULE);
                        cm.Parameters.AddWithValue("@TAXES", TAXES);
                        cm.Parameters.AddWithValue("@FREIGHT", FREIGHT);
                        cm.Parameters.AddWithValue("@DISPATCH", DISPATCH);
                        cm.Parameters.AddWithValue("@BANKID", BANK);
                        cm.Parameters.AddWithValue("@TAX", tax);
                        cm.Parameters.AddWithValue("@SUB_TOTAL", subtotal);
                        cm.Parameters.AddWithValue("@TOTAL", total);
                        cm.Parameters.AddWithValue("@CREATED_DATE", today);
                        cm.Parameters.AddWithValue("@SPECIAL_TERM", SPECIAL_TERM);
                        cm.Parameters.AddWithValue("@PURCHASE_TERM", PURCHASE_TERM);
                        cm.Parameters.AddWithValue("@GSTNO", GSTNO);
                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        result = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();

                        if (result == null)
                        {

                            data.MESSAGE = "Failed To Show";
                            data.ORIGINAL_ERROR = "Try Again Later";
                            data.ERROR_STATUS = true;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;
                        }
                        //SOURCE = (new System.Web.UI.WebControls.ListItem(_Items2[i].SOURCE).ToString());
                        //BANK = (new System.Web.UI.WebControls.ListItem(_Items2[i].BANK).ToString());

                        //string query = "insert into CLIENT_MASTER(CLIENTID,MOBILE,EMAIL,ADDRESS,VALUE_OF_LEAD,REFERENCE,SOURCE_OF_LEAD,BANKID,TAX,SUB_TOTAL,TOTAL) values('" + CLIENT_ID + "','" + MOBILE + "','" + EMAIL + "','" + ADDRESS + "','" + LEAD + "','" + REF + "','" + SOURCE + "','" + BANK + "','" + tax + "','" + subtotal + "','" + total + "')";
                        //D.ExecuteQuery(query);
                        //mobile = MOBILE;

                    }
                    //DataTable dt = D.GetDataTable("select ID from CLIENT_MASTER where mobile = '" + mobile + "' order by id desc" );

                    string url = "";
                    JavaScriptSerializer _convert = new JavaScriptSerializer();
                    url = Data;
                    var _Items = _convert.Deserialize<InsertQuotationSolution[]>(url);
                    int cnt = _Items.Length;


                    for (int i = 0; i < cnt; i++)
                    {
                        pid = (new System.Web.UI.WebControls.ListItem(_Items[i].pid).ToString());
                        Unit = (new System.Web.UI.WebControls.ListItem(_Items[i].Unit).ToString());
                        Rate = (new System.Web.UI.WebControls.ListItem(_Items[i].Rate).ToString());
                        Qty = (new System.Web.UI.WebControls.ListItem(_Items[i].Qty).ToString());
                        Amount = (new System.Web.UI.WebControls.ListItem(_Items[i].Amount).ToString());

                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_PROFORMA_INVOICE_ITEMS";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@PROFORMA_ID", result);
                        cm.Parameters.AddWithValue("@ITEM_ID", pid);
                        cm.Parameters.AddWithValue("@UNIT", Unit);
                        cm.Parameters.AddWithValue("@QTY", Qty);
                        cm.Parameters.AddWithValue("@UNIT_PRICE", Rate);
                        cm.Parameters.AddWithValue("@SUB_TOTAL_PRICE", Amount);


                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        result2 = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();
                        //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                        //D.ExecuteQuery(query);


                    }
                    if (result2.Contains("Successfully"))
                    {

                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = result2;
                        data.ERROR_STATUS = false;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        data.MESSAGE = "Failed To Show";
                        data.ORIGINAL_ERROR = "Try Again Later";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                    }

                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Show";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }



            }
        }

        [WebMethod]
        public void GetProformaInvoice(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<ProformaData> cm = new List<ProformaData>();
            List<GeneralDataGetProformaDataData> g = new List<GeneralDataGetProformaDataData>();
            try
            {
                if (ACTION == "getproformadata")
                {

                    string qry = "select em.*,lm.clientname,bm.BENEFICIARY_NAME from PROFORMA_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGetProformaDataData data = new GeneralDataGetProformaDataData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            ProformaData d = new ProformaData();
                            d.qid = row["ID"].ToString();
                            d.cid = row["CLIENT_ID"].ToString();
                            d.clientname = row["clientname"].ToString();
                            d.e_refe = row["ENQUIRY_REFERENCE"].ToString();
                            d.e_date = Convert.ToDateTime(row["ENQUIERY_DATE"].ToString()).ToString("dd-MM-yyyy");
                            d.p_refe = row["PROFORMA_REFERENCE"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            d.p_date = Convert.ToDateTime(row["PROFORMA_DATE"].ToString()).ToString("dd-MM-yyyy");
                            d.delivery_term = row["DELIVERY_TERM"].ToString();
                            d.d_schedule = row["DELIVERY_SCHEDULE"].ToString();
                            d.taxes = row["TAXES"].ToString();
                            d.freight = row["FREIGHT_INSURANCE"].ToString();
                            d.mode_dispatch = row["MODE_OF_DISPATCH"].ToString();
                            d.bank = row["BENEFICIARY_NAME"].ToString();
                            d.tax = row["TAX"].ToString();
                            d.subtotal = row["SUB_TOTAL"].ToString();
                            d.total = row["TOTAL_AMT"].ToString();
                            List<QuotationProductData> pd = new List<QuotationProductData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[PROFORMA_ITEM_MASTER] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.itemid where proforma_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                QuotationProductData ep = new QuotationProductData();
                                ep.eid = row2["PROFORMA_ID"].ToString();
                                ep.itemname = row2["itemname"].ToString();
                                ep.unit = row2["UNIT"].ToString();
                                ep.qty = row2["QUANTITY"].ToString();
                                ep.unit_price = row2["UNIT_PRICE"].ToString();
                                ep.subtotal = row2["TOTAL_PRICE"].ToString();
                                pd.Add(ep);
                            }
                            d.GetProformaProductData = pd;
                            cm.Add(d);
                        }
                        data.GetProformaData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGetProformaDataData data = new GeneralDataGetProformaDataData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGetProformaDataData data = new GeneralDataGetProformaDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]
        public void GetSingleProformaInvoice(string ACTION, string PID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<ProformaData> cm = new List<ProformaData>();
            List<GeneralDataGetProformaDataData> g = new List<GeneralDataGetProformaDataData>();
            try
            {
                if (ACTION == "getsingleproformadata")
                {

                    string qry = "select em.*,lm.clientname,bm.BENEFICIARY_NAME from PROFORMA_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id where em.client_id = " + PID + " order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGetProformaDataData data = new GeneralDataGetProformaDataData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            ProformaData d = new ProformaData();
                            d.qid = row["ID"].ToString();
                            d.cid = row["CLIENT_ID"].ToString();
                            d.clientname = row["clientname"].ToString();
                            d.e_refe = row["ENQUIRY_REFERENCE"].ToString();
                            d.e_date = Convert.ToDateTime(row["ENQUIERY_DATE"].ToString()).ToString("dd-MM-yyyy");
                            d.p_refe = row["PROFORMA_REFERENCE"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            d.p_date = Convert.ToDateTime(row["PROFORMA_DATE"].ToString()).ToString("dd-MM-yyyy");
                            d.delivery_term = row["DELIVERY_TERM"].ToString();
                            d.d_schedule = row["DELIVERY_SCHEDULE"].ToString();
                            d.taxes = row["TAXES"].ToString();
                            d.freight = row["FREIGHT_INSURANCE"].ToString();
                            d.mode_dispatch = row["MODE_OF_DISPATCH"].ToString();
                            d.bank = row["BENEFICIARY_NAME"].ToString();
                            d.tax = row["TAX"].ToString();
                            d.subtotal = row["SUB_TOTAL"].ToString();
                            d.total = row["TOTAL_AMT"].ToString();
                            List<QuotationProductData> pd = new List<QuotationProductData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[PROFORMA_ITEM_MASTER] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.itemid where proforma_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                QuotationProductData ep = new QuotationProductData();
                                ep.eid = row2["PROFORMA_ID"].ToString();
                                ep.itemname = row2["itemname"].ToString();
                                ep.unit = row2["UNIT"].ToString();
                                ep.qty = row2["QUANTITY"].ToString();
                                ep.unit_price = row2["UNIT_PRICE"].ToString();
                                ep.subtotal = row2["TOTAL_PRICE"].ToString();
                                pd.Add(ep);
                            }
                            d.GetProformaProductData = pd;
                            cm.Add(d);
                        }
                        data.GetProformaData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGetProformaDataData data = new GeneralDataGetProformaDataData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGetProformaDataData data = new GeneralDataGetProformaDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]
        public void InsertOrderData(string type, string Data, string ORDER_DATA, string SpecialInstructionData, string QID, string CADDRESS, string DADDRESS, string PDATE, string PODATE, string OADATE)
        {
            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();




            string PNO = "";
            string PONO = "";
            string OANO = "";
            string INSPECT = "";
            string INSURANCE = "";
            string DISPATCH = "";
            string TRASPORTER = "";
            string PREPARE_BY = "";
            string APPROVE_BY = "";

            string result = "";
            string result2 = "";
            //string mobile = "";

            string pid = "";
            string Qty = "";
            string Date = "";


            string INSTRUCTION_TEXT = "";
            if (type == "insertorder")
            {
                string CLIENT_ID = "";
                try
                {
                    string url2 = "";
                    JavaScriptSerializer _convert2 = new JavaScriptSerializer();
                    url2 = "[" + ORDER_DATA + "]";
                    var _Items2 = _convert2.Deserialize<InsertOrder[]>(url2);
                    int cnt2 = _Items2.Length;
                    GeneralData data = new GeneralData();
                    DataTable dt = D.GetDataTable("select Client_Id from QUOTATION_MASTER where id = " + QID);
                    CLIENT_ID = dt.Rows[0]["CLIENT_ID"].ToString();
                    for (int i = 0; i < cnt2; i++)
                    {

                        PNO = (new System.Web.UI.WebControls.ListItem(_Items2[i].PNO).ToString());
                        PONO = (new System.Web.UI.WebControls.ListItem(_Items2[i].PONO).ToString());
                        OANO = (new System.Web.UI.WebControls.ListItem(_Items2[i].OANO).ToString());
                        INSPECT = (new System.Web.UI.WebControls.ListItem(_Items2[i].INSPECT).ToString());
                        INSURANCE = (new System.Web.UI.WebControls.ListItem(_Items2[i].INSURANCE).ToString());
                        DISPATCH = (new System.Web.UI.WebControls.ListItem(_Items2[i].DISPATCH).ToString());
                        TRASPORTER = (new System.Web.UI.WebControls.ListItem(_Items2[i].TRASPORTER).ToString());
                        PREPARE_BY = (new System.Web.UI.WebControls.ListItem(_Items2[i].PREPARE_BY).ToString());
                        APPROVE_BY = (new System.Web.UI.WebControls.ListItem(_Items2[i].APPROVE_BY).ToString());

                        //CLIENT_ID = (new System.Web.UI.WebControls.ListItem(_Items2[i].CLIENT_ID).ToString());


                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_ORDER_ACCEPTANCE";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@QID", QID);
                        cm.Parameters.AddWithValue("@QUOTATION_ID", CLIENT_ID);
                        cm.Parameters.AddWithValue("@CUSTOMER_ADDRESS", CADDRESS);
                        cm.Parameters.AddWithValue("@DELIVERY_ADDRESS", DADDRESS);
                        cm.Parameters.AddWithValue("@PROFORMA_NO", PNO);
                        cm.Parameters.AddWithValue("@PROFORMA_DATE", PDATE);
                        cm.Parameters.AddWithValue("@PERCHASE_NO", PONO);
                        cm.Parameters.AddWithValue("@PERCHASE_DATE", PODATE);
                        cm.Parameters.AddWithValue("@ORDER_ACCEPTANCE_NO", OANO);
                        cm.Parameters.AddWithValue("@ORDER_ACCEPTANCE_DATE", OADATE);
                        cm.Parameters.AddWithValue("@INSPECTION_BY", INSPECT);
                        cm.Parameters.AddWithValue("@INSURANCE_BY", INSURANCE);
                        cm.Parameters.AddWithValue("@MODE_OF_DISPATCH", DISPATCH);
                        cm.Parameters.AddWithValue("@TRANSPORTER", TRASPORTER);
                        cm.Parameters.AddWithValue("@PREPARE_BY", PREPARE_BY);
                        cm.Parameters.AddWithValue("@APPROVE_BY", APPROVE_BY);
                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        result = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();

                        if (result == null)
                        {

                            data.MESSAGE = "Failed To Show";
                            data.ORIGINAL_ERROR = "Try Again Later";
                            data.ERROR_STATUS = true;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;
                        }
                        //SOURCE = (new System.Web.UI.WebControls.ListItem(_Items2[i].SOURCE).ToString());
                        //BANK = (new System.Web.UI.WebControls.ListItem(_Items2[i].BANK).ToString());

                        //string query = "insert into CLIENT_MASTER(CLIENTID,MOBILE,EMAIL,ADDRESS,VALUE_OF_LEAD,REFERENCE,SOURCE_OF_LEAD,BANKID,TAX,SUB_TOTAL,TOTAL) values('" + CLIENT_ID + "','" + MOBILE + "','" + EMAIL + "','" + ADDRESS + "','" + LEAD + "','" + REF + "','" + SOURCE + "','" + BANK + "','" + tax + "','" + subtotal + "','" + total + "')";
                        //D.ExecuteQuery(query);
                        //mobile = MOBILE;

                    }
                    //DataTable dt = D.GetDataTable("select ID from CLIENT_MASTER where mobile = '" + mobile + "' order by id desc" );

                    string url = "";
                    JavaScriptSerializer _convert = new JavaScriptSerializer();
                    url = Data;
                    var _Items = _convert.Deserialize<Insertorderitem[]>(url);
                    int cnt = _Items.Length;


                    for (int i = 0; i < cnt; i++)
                    {
                        pid = (new System.Web.UI.WebControls.ListItem(_Items[i].pid).ToString());
                        Qty = (new System.Web.UI.WebControls.ListItem(_Items[i].Qty).ToString());
                        Date = (new System.Web.UI.WebControls.ListItem(_Items[i].Date).ToString());

                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_ORDER_ACCEPTANCE_ITEM";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@ORDER_ID", result);
                        cm.Parameters.AddWithValue("@ITEM_ID", pid);
                        cm.Parameters.AddWithValue("@QUANTITY", Qty);
                        cm.Parameters.AddWithValue("@DELIVERY_DATE", Date);


                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        result2 = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();
                        //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                        //D.ExecuteQuery(query);


                    }
                    if (result2.Contains("Successfully"))
                    {

                        string siurl = "";
                        JavaScriptSerializer _convertsi = new JavaScriptSerializer();
                        siurl = SpecialInstructionData;
                        var _Itemsi = _convertsi.Deserialize<InsertSpecialInstruction[]>(siurl);
                        int cnt3 = _Itemsi.Length;


                        for (int i = 0; i < cnt3; i++)
                        {

                            INSTRUCTION_TEXT = (new System.Web.UI.WebControls.ListItem(_Itemsi[i].INSTRUCTION_TEXT).ToString());

                            SqlCommand cm = new SqlCommand();
                            cm.Connection = conn;
                            cm.CommandText = "INSERT_ORDER_ACCEPTANCE_SINSTRUCTION";
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@ORDER_ID", result);
                            cm.Parameters.AddWithValue("@SPECIAL_INSTRUCTIONS", INSTRUCTION_TEXT);
                            cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                            conn.Open();
                            cm.ExecuteNonQuery();
                            result2 = cm.Parameters["@RESULT"].Value.ToString();
                            SqlDataAdapter da = new SqlDataAdapter(cm);
                            da.SelectCommand = cm;
                            conn.Close();
                            //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                            //D.ExecuteQuery(query);


                        }
                        if (result2.Contains("Successfully"))
                        {

                            data.MESSAGE = "Successfully!";
                            data.ORIGINAL_ERROR = result2;
                            data.ERROR_STATUS = false;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;

                        }
                        else
                        {
                            data.MESSAGE = "Failed To Show";
                            data.ORIGINAL_ERROR = "Try Again Later";
                            data.ERROR_STATUS = true;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;
                        }

                    }
                    else
                    {
                        data.MESSAGE = "Failed To Show";
                        data.ORIGINAL_ERROR = "Try Again Later";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }


                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Show";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }



            }
        }
        [WebMethod]
        public void GetOrderAcceptanceData(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<OrderData> cm = new List<OrderData>();
            List<GeneralDataOrderDataData> g = new List<GeneralDataOrderDataData>();
            try
            {
                if (ACTION == "getorderdata")
                {

                    string qry = "select em.*,cm.clientname from ORDER_ACCEPTANCE_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as cm on cm.ID=em.quotation_id order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataOrderDataData data = new GeneralDataOrderDataData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            OrderData d = new OrderData();
                            d.orderid = row["ID"].ToString();
                            d.clientname = row["clientname"].ToString();
                            d.customer_address = row["CUSTOMER_ADDRESS"].ToString();
                            d.delivery_address = row["DELIVERY_ADDRESS"].ToString();
                            d.proforma_no = row["PROFORMA_NO"].ToString();
                            if (row["PROFORMA_DATE"].ToString() != "")
                            {
                                d.proforma_date = Convert.ToDateTime(row["PROFORMA_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.proforma_date = "";
                            }
                            d.perchase_no = row["PERCHASE_NO"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            if (row["PERCHASE_DATE"].ToString() != "")
                            {
                                d.perchase_date = Convert.ToDateTime(row["PERCHASE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.perchase_date = "";
                            }

                            d.order_no = row["ORDER_ACCEPTANCE_NO"].ToString();
                            if (row["ORDER_ACCEPTANCE_DATE"].ToString() != "")
                            {
                                d.order_date = Convert.ToDateTime(row["ORDER_ACCEPTANCE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.order_date = "";
                            }
                            d.inspection_by = row["INSPECTION_BY"].ToString();
                            d.insurance_by = row["INSURANCE_BY"].ToString();
                            d.mode_of_dispatch = row["MODE_OF_DISPATCH"].ToString();
                            d.transporter = row["TRANSPORTER"].ToString();

                            List<OrderItemData> pd = new List<OrderItemData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[ORDER_ACCEPTANCE_ITEM] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.item_id where order_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                OrderItemData ep = new OrderItemData();
                                ep.itemname = row2["itemname"].ToString();
                                ep.quantity = row2["QUANTITY"].ToString();
                                if (row2["DELIVERY_DATE"].ToString() != "")
                                {
                                    ep.delivery_date = row2["DELIVERY_DATE"].ToString();
                                }
                                else
                                {
                                    ep.delivery_date = "";
                                }
                                pd.Add(ep);
                            }
                            d.GetOrderItemData = pd;

                            List<SpecialInstructionData> si = new List<SpecialInstructionData>();
                            DataTable dt3 = D.GetDataTable("select * from [dbo].[ORDER_ACCEPTANCE_SINSTRUCTION] where order_id = " + row["id"].ToString());
                            foreach (DataRow row3 in dt3.Rows)
                            {
                                SpecialInstructionData s = new SpecialInstructionData();
                                s.text = row3["SPECIAL_INSTRUCTIONS"].ToString();
                                si.Add(s);
                            }
                            d.GetSpecialInstructionData = si;
                            cm.Add(d);
                        }
                        data.GetOrderData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataOrderDataData data = new GeneralDataOrderDataData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataOrderDataData data = new GeneralDataOrderDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]
        public void GetSingleOrderAcceptanceData(string ACTION, string OID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<OrderData> cm = new List<OrderData>();
            List<GeneralDataOrderDataData> g = new List<GeneralDataOrderDataData>();
            try
            {
                if (ACTION == "getsingleorderdata")
                {

                    string qry = "select em.*,cm.clientname from ORDER_ACCEPTANCE_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as cm on cm.ID=em.quotation_id where em.quotation_id = " + OID + " order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataOrderDataData data = new GeneralDataOrderDataData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            OrderData d = new OrderData();
                            d.orderid = row["ID"].ToString();
                            d.clientname = row["clientname"].ToString();
                            d.customer_address = row["CUSTOMER_ADDRESS"].ToString();
                            d.delivery_address = row["DELIVERY_ADDRESS"].ToString();
                            d.proforma_no = row["PROFORMA_NO"].ToString();
                            if (row["PROFORMA_DATE"].ToString() != "")
                            {
                                d.proforma_date = Convert.ToDateTime(row["PROFORMA_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.proforma_date = "";
                            }
                            d.perchase_no = row["PERCHASE_NO"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            if (row["PERCHASE_DATE"].ToString() != "")
                            {
                                d.perchase_date = Convert.ToDateTime(row["PERCHASE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.perchase_date = "";
                            }

                            d.order_no = row["ORDER_ACCEPTANCE_NO"].ToString();
                            if (row["ORDER_ACCEPTANCE_DATE"].ToString() != "")
                            {
                                d.order_date = Convert.ToDateTime(row["ORDER_ACCEPTANCE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.order_date = "";
                            }
                            d.inspection_by = row["INSPECTION_BY"].ToString();
                            d.insurance_by = row["INSURANCE_BY"].ToString();
                            d.mode_of_dispatch = row["MODE_OF_DISPATCH"].ToString();
                            d.transporter = row["TRANSPORTER"].ToString();

                            List<OrderItemData> pd = new List<OrderItemData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[ORDER_ACCEPTANCE_ITEM] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.item_id where order_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                OrderItemData ep = new OrderItemData();
                                ep.itemname = row2["itemname"].ToString();
                                ep.quantity = row2["QUANTITY"].ToString();
                                if (row2["DELIVERY_DATE"].ToString() != "")
                                {
                                    ep.delivery_date = row2["DELIVERY_DATE"].ToString();
                                }
                                else
                                {
                                    ep.delivery_date = "";
                                }
                                pd.Add(ep);
                            }
                            d.GetOrderItemData = pd;

                            List<SpecialInstructionData> si = new List<SpecialInstructionData>();
                            DataTable dt3 = D.GetDataTable("select * from [dbo].[ORDER_ACCEPTANCE_SINSTRUCTION] where order_id = " + row["id"].ToString());
                            foreach (DataRow row3 in dt3.Rows)
                            {
                                SpecialInstructionData s = new SpecialInstructionData();
                                s.text = row3["SPECIAL_INSTRUCTIONS"].ToString();
                                si.Add(s);
                            }
                            d.GetSpecialInstructionData = si;
                            cm.Add(d);
                        }
                        data.GetOrderData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataOrderDataData data = new GeneralDataOrderDataData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataOrderDataData data = new GeneralDataOrderDataData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]
        public void GetEnquiryItemData(string type, string QID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<GetEnquiryItem> cm = new List<GetEnquiryItem>();
            List<DeliveryAddress> da = new List<DeliveryAddress>();
            List<ClientAddress> ca = new List<ClientAddress>();
            List<GetSingleQuotationData> qd = new List<GetSingleQuotationData>();
            List<GeneralDataGetEnquiryItemData> g = new List<GeneralDataGetEnquiryItemData>();
            try
            {
                string clientid = "";
                if (type == "getitemsforquotation")
                {
                    string qry2 = "select cm.tax,cm.SUB_TOTAL,cm.TOTAL,im.itemname,em.item_id,em.unit,em.qty,em.unit_price,em.sub_total_price from CLIENT_MASTER as cm,ENQUIRY_PRODUCT_MASTER as em,ITEM_MASTER as im  where em.enquiry_id = cm.id and im.id = em.item_id and cm.id = " + QID + " order by cm.id desc";

                    DataTable dt2 = D.GetDataTable(qry2);

                    if (dt2.Rows.Count > 0)
                    {
                        GeneralDataGetEnquiryItemData data = new GeneralDataGetEnquiryItemData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt2.Rows)
                        {
                            GetEnquiryItem d = new GetEnquiryItem();

                            d.tax = row["TAX"].ToString();
                            d.subtotal = row["SUB_TOTAL"].ToString();
                            d.total = row["TOTAL"].ToString();
                            d.itemid = row["item_id"].ToString();
                            d.itemname = row["itemname"].ToString();
                            d.unit = row["unit"].ToString();
                            d.qty = row["qty"].ToString();
                            d.unit_price = row["unit_price"].ToString();
                            d.subtotal_price = row["sub_total_price"].ToString();
                            cm.Add(d);
                        }
                        data.GetEnquiryData = cm;
                        //data.GetAddressData = da;
                        //data.GetClientAddressData = ca;
                        //data.GetQuotationData = qd;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }

                }
                if (type == "getenquiryitems")
                {

                    string qry = "select cm.client_id,cm.tax,cm.SUB_TOTAL,cm.TOTAL_AMT,im.itemname,em.itemid,em.unit,em.quantity,em.unit_price,em.total_price from QUOTATION_MASTER as cm,QUOTATION_ITEM_MASTER as em,ITEM_MASTER as im  where em.quotation_id = cm.id and im.id = em.itemid and cm.id = " + QID + " order by cm.id desc";

                    DataTable dt = D.GetDataTable(qry);
                    clientid = dt.Rows[0]["client_id"].ToString();
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGetEnquiryItemData data = new GeneralDataGetEnquiryItemData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            GetEnquiryItem d = new GetEnquiryItem();

                            d.tax = row["TAX"].ToString();
                            d.subtotal = row["SUB_TOTAL"].ToString();
                            d.total = row["TOTAL_AMT"].ToString();
                            d.itemid = row["itemid"].ToString();
                            d.itemname = row["itemname"].ToString();
                            d.unit = row["unit"].ToString();
                            d.qty = row["quantity"].ToString();
                            d.unit_price = row["unit_price"].ToString();
                            d.subtotal_price = row["total_price"].ToString();
                            cm.Add(d);
                        }
                        DataTable dt2 = D.GetDataTable("SELECT ID,address + ' - ' + mobile + ' - ' + email as fulladdress FROM [dbo].[DELIVERY_ADDRESS_MASTER] where client_id = " + clientid + " order by id desc");
                        if (dt2.Rows.Count > 0)
                        {

                            foreach (DataRow row2 in dt2.Rows)
                            {
                                DeliveryAddress d = new DeliveryAddress();
                                d.ID = row2["ID"].ToString();
                                d.Address = row2["fulladdress"].ToString();
                                da.Add(d);
                            }

                        }
                        DataTable dt3 = D.GetDataTable("SELECT ID,address + ' - ' + mobile + ' - ' + email as fulladdress FROM [dbo].[CLIENT_MASTER] where id = " + clientid + " order by id desc");
                        if (dt3.Rows.Count > 0)
                        {

                            foreach (DataRow row3 in dt3.Rows)
                            {
                                ClientAddress c = new ClientAddress();
                                c.ID = row3["ID"].ToString();
                                c.Address = row3["fulladdress"].ToString();
                                ca.Add(c);
                            }

                        }
                        DataTable dt4 = D.GetDataTable("select * from QUOTATION_MASTER where id = " + QID);
                        if (dt4.Rows.Count > 0)
                        {

                            foreach (DataRow row4 in dt4.Rows)
                            {
                                GetSingleQuotationData q = new GetSingleQuotationData();
                                q.D_Term = row4["DELIVERY_TERM"].ToString();
                                q.D_Schedule = row4["DELIVERY_SCHEDULE"].ToString();
                                q.Taxes = row4["TAXES"].ToString();
                                q.Insurance = row4["FREIGHT_INSURANCE"].ToString();
                                q.Mode_Dispatch = row4["MODE_OF_DISPATCH"].ToString();
                                q.S_Term = row4["SPECIAL_TERM"].ToString();
                                q.P_Term = row4["PURCHASE_TERM"].ToString();
                                qd.Add(q);
                            }

                        }

                        data.GetEnquiryData = cm;
                        data.GetAddressData = da;
                        data.GetClientAddressData = ca;
                        data.GetQuotationData = qd;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGetEnquiryItemData data = new GeneralDataGetEnquiryItemData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGetEnquiryItemData data = new GeneralDataGetEnquiryItemData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]
        public void InsertDispatchNote(string type, string Data, string DISPATCH_DATA, string SpecialInstructionData, string PackingInstructionData, string Remark, string QID, string DELIVERY_ADDRESS, string SALE_ORDER_DATE, string DELIVERY_DATE, string ORDER_ACCEPTANCE_DATE, string DISPATCH_DATE)
        {
            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();


            string today = DateTime.Now.ToString("yyyy/MM/dd hh:mm tt");


            string SALE_ORDER_NO = "";
            string DELIVERY_NO = "";
            string ORDER_ACCEPTANCE_NO = "";
            string DISPATCH_NO = "";
            string TRASPORTER = "";
            string CNNO = "";
            string DISPATCH_TERM = "";
            string DISPATCH_THROUGH = "";
            string VAHICLE_NO = "";
            string INTERNAL_INSPECTION_BY = "";
            string TP_INSPECTION_BY = "";
            string PREPARE_BY = "";
            string APPROVE_BY = "";

            string result = "";
            string result2 = "";
            //string mobile = "";

            string pid = "";
            string Qty = "";
            string Date = "";
            string ProductRemark = "";


            string SPECIAL_INSTRUCTION = "";
            string PACKING_INSTRUCTION = "";
            string REMARK = "";

            if (type == "dispatchnote")
            {
                string CLIENT_ID = "";
                try
                {
                    string url2 = "";
                    JavaScriptSerializer _convert2 = new JavaScriptSerializer();
                    url2 = "[" + DISPATCH_DATA + "]";
                    var _Items2 = _convert2.Deserialize<INSERTDISPATCHNOTEDATA[]>(url2);
                    int cnt2 = _Items2.Length;
                    GeneralData data = new GeneralData();
                    DataTable dt = D.GetDataTable("select CLIENT_ID from QUOTATION_MASTER where id = " + QID);
                    CLIENT_ID = dt.Rows[0]["CLIENT_ID"].ToString();
                    for (int i = 0; i < cnt2; i++)
                    {


                        SALE_ORDER_NO = (new System.Web.UI.WebControls.ListItem(_Items2[i].SALE_ORDER_NO).ToString());
                        DELIVERY_NO = (new System.Web.UI.WebControls.ListItem(_Items2[i].DELIVERY_NO).ToString());
                        ORDER_ACCEPTANCE_NO = (new System.Web.UI.WebControls.ListItem(_Items2[i].ORDER_ACCEPTANCE_NO).ToString());
                        DISPATCH_NO = (new System.Web.UI.WebControls.ListItem(_Items2[i].DISPATCH_NO).ToString());
                        TRASPORTER = (new System.Web.UI.WebControls.ListItem(_Items2[i].TRASPORTER).ToString());
                        CNNO = (new System.Web.UI.WebControls.ListItem(_Items2[i].CNNO).ToString());
                        DISPATCH_TERM = (new System.Web.UI.WebControls.ListItem(_Items2[i].DISPATCH_TERM).ToString());
                        DISPATCH_THROUGH = (new System.Web.UI.WebControls.ListItem(_Items2[i].DISPATCH_THROUGH).ToString());
                        VAHICLE_NO = (new System.Web.UI.WebControls.ListItem(_Items2[i].VAHICLE_NO).ToString());
                        INTERNAL_INSPECTION_BY = (new System.Web.UI.WebControls.ListItem(_Items2[i].INTERNAL_INSPECTION_BY).ToString());
                        TP_INSPECTION_BY = (new System.Web.UI.WebControls.ListItem(_Items2[i].TP_INSPECTION_BY).ToString());
                        PREPARE_BY = (new System.Web.UI.WebControls.ListItem(_Items2[i].PREPARE_BY).ToString());
                        APPROVE_BY = (new System.Web.UI.WebControls.ListItem(_Items2[i].APPROVE_BY).ToString());

                        //CLIENT_ID = (new System.Web.UI.WebControls.ListItem(_Items2[i].CLIENT_ID).ToString());


                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_DISPATCH_NOTE";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@QID", QID);
                        cm.Parameters.AddWithValue("@CLIENT_ID", CLIENT_ID);
                        cm.Parameters.AddWithValue("@DELIVERY_ADDRESS", DELIVERY_ADDRESS);
                        cm.Parameters.AddWithValue("@SALE_ORDER_NO", SALE_ORDER_NO);
                        cm.Parameters.AddWithValue("@SALE_ORDER_DATE", SALE_ORDER_DATE);
                        cm.Parameters.AddWithValue("@DELIVERY_NO", DELIVERY_NO);
                        cm.Parameters.AddWithValue("@DELIVERY_DATE", DELIVERY_DATE);
                        cm.Parameters.AddWithValue("@ORDER_ACCEPTANCE_NO", ORDER_ACCEPTANCE_NO);
                        cm.Parameters.AddWithValue("@ORDER_ACCEPTANCE_DATE", ORDER_ACCEPTANCE_DATE);
                        cm.Parameters.AddWithValue("@DISPATCH_NO", DISPATCH_NO);
                        cm.Parameters.AddWithValue("@DISPATCH_DATE", DISPATCH_DATE);
                        cm.Parameters.AddWithValue("@TRASPORTER", TRASPORTER);
                        cm.Parameters.AddWithValue("@CNNO", CNNO);
                        cm.Parameters.AddWithValue("@DISPATCH_TERM", DISPATCH_TERM);
                        cm.Parameters.AddWithValue("@DISPATCH_THROUGH", DISPATCH_THROUGH);
                        cm.Parameters.AddWithValue("@VAHICLE_NO", VAHICLE_NO);
                        cm.Parameters.AddWithValue("@INTERNAL_INSPECTION_BY", INTERNAL_INSPECTION_BY);
                        cm.Parameters.AddWithValue("@TP_INSPECTION_BY", TP_INSPECTION_BY);
                        cm.Parameters.AddWithValue("@CREATED_DATE", today);
                        cm.Parameters.AddWithValue("@PREPARE_BY", PREPARE_BY);
                        cm.Parameters.AddWithValue("@APPROVE_BY", APPROVE_BY);
                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        result = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();

                        if (result == null)
                        {

                            data.MESSAGE = "Failed To Show";
                            data.ORIGINAL_ERROR = "Try Again Later";
                            data.ERROR_STATUS = true;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;
                        }


                    }


                    string url = "";
                    JavaScriptSerializer _convert = new JavaScriptSerializer();
                    url = Data;
                    var _Items = _convert.Deserialize<Insertdispathnoteitem[]>(url);
                    int cnt = _Items.Length;


                    for (int i = 0; i < cnt; i++)
                    {
                        pid = (new System.Web.UI.WebControls.ListItem(_Items[i].pid).ToString());
                        Qty = (new System.Web.UI.WebControls.ListItem(_Items[i].Qty).ToString());
                        Date = (new System.Web.UI.WebControls.ListItem(_Items[i].Date).ToString());
                        ProductRemark = (new System.Web.UI.WebControls.ListItem(_Items[i].ProductRemark).ToString());
                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_DISPATCH_NOTE_ITEM";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@DISPATCH_NOTE_ID", result);
                        cm.Parameters.AddWithValue("@ITEM_ID", pid);
                        cm.Parameters.AddWithValue("@QUANTITY", Qty);
                        cm.Parameters.AddWithValue("@DISPATCH_DATE", Date);
                        cm.Parameters.AddWithValue("@REMARK", ProductRemark);

                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        result2 = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();
                        //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                        //D.ExecuteQuery(query);


                    }


                    if (result2.Contains("Successfully"))
                    {

                        string siurl = "";
                        JavaScriptSerializer _convertsi = new JavaScriptSerializer();
                        siurl = SpecialInstructionData;
                        var _Itemsi = _convertsi.Deserialize<InsertSpecialInstructiondispatch[]>(siurl);
                        int cnt3 = _Itemsi.Length;


                        for (int i = 0; i < cnt3; i++)
                        {

                            SPECIAL_INSTRUCTION = (new System.Web.UI.WebControls.ListItem(_Itemsi[i].SPECIAL_INSTRUCTION).ToString());

                            SqlCommand cm = new SqlCommand();
                            cm.Connection = conn;
                            cm.CommandText = "INSERT_DISPATCH_NOTE_SINSTRUCTION";
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@DISPATCH_NOTE_ID", result);
                            cm.Parameters.AddWithValue("@SPECIAL_INSTRUCTIONS", SPECIAL_INSTRUCTION);
                            cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                            conn.Open();
                            cm.ExecuteNonQuery();
                            result2 = cm.Parameters["@RESULT"].Value.ToString();
                            SqlDataAdapter da = new SqlDataAdapter(cm);
                            da.SelectCommand = cm;
                            conn.Close();
                            //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                            //D.ExecuteQuery(query);


                        }

                        string piurl = "";
                        JavaScriptSerializer _convertpi = new JavaScriptSerializer();
                        piurl = PackingInstructionData;
                        var _Itempi = _convertpi.Deserialize<InsertPackageInstruction[]>(piurl);
                        int cnt4 = _Itempi.Length;


                        for (int i = 0; i < cnt4; i++)
                        {

                            PACKING_INSTRUCTION = (new System.Web.UI.WebControls.ListItem(_Itempi[i].PACKING_INSTRUCTION).ToString());

                            SqlCommand cm = new SqlCommand();
                            cm.Connection = conn;
                            cm.CommandText = "INSERT_DISPATCH_NOTE_PINSTRUCTION";
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@DISPATCH_NOTE_ID", result);
                            cm.Parameters.AddWithValue("@PACKING_INSTRUCTION", PACKING_INSTRUCTION);
                            cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                            conn.Open();
                            cm.ExecuteNonQuery();
                            result2 = cm.Parameters["@RESULT"].Value.ToString();
                            SqlDataAdapter da = new SqlDataAdapter(cm);
                            da.SelectCommand = cm;
                            conn.Close();
                            //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                            //D.ExecuteQuery(query);


                        }

                        string rurl = "";
                        JavaScriptSerializer _convertr = new JavaScriptSerializer();
                        rurl = Remark;
                        var _Itemr = _convertr.Deserialize<InsertRemark[]>(rurl);
                        int cnt5 = _Itemr.Length;


                        for (int i = 0; i < cnt5; i++)
                        {

                            REMARK = (new System.Web.UI.WebControls.ListItem(_Itemr[i].REMARK).ToString());

                            SqlCommand cm = new SqlCommand();
                            cm.Connection = conn;
                            cm.CommandText = "INSERT_DISPATCH_NOTE_REMARK";
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.Parameters.AddWithValue("@DISPATCH_NOTE_ID", result);
                            cm.Parameters.AddWithValue("@REMARK_NOTE", REMARK);
                            cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                            conn.Open();
                            cm.ExecuteNonQuery();
                            result2 = cm.Parameters["@RESULT"].Value.ToString();
                            SqlDataAdapter da = new SqlDataAdapter(cm);
                            da.SelectCommand = cm;
                            conn.Close();
                            //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                            //D.ExecuteQuery(query);


                        }
                        if (result2.Contains("Successfully"))
                        {

                            data.MESSAGE = "Successfully!";
                            data.ORIGINAL_ERROR = result2;
                            data.ERROR_STATUS = false;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;

                        }
                        else
                        {
                            data.MESSAGE = "Failed To Show";
                            data.ORIGINAL_ERROR = "Try Again Later";
                            data.ERROR_STATUS = true;
                            data.RECORDS = false;
                            g.Add(data);
                            Context.Response.Write(js.Serialize(g[0]));
                            return;
                        }

                    }
                    else
                    {
                        data.MESSAGE = "Failed To Show";
                        data.ORIGINAL_ERROR = "Try Again Later";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }


                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Show";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }



            }
        }

        [WebMethod]
        public void GetDispatchNoteData(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<GETDISPATCHNOTE> cm = new List<GETDISPATCHNOTE>();
            List<GeneralDataGETDISPATCHNOTE> g = new List<GeneralDataGETDISPATCHNOTE>();
            try
            {
                if (ACTION == "getdispatchdata")
                {

                    string qry = "select em.*,cm.clientname,da.address + ' - ' + da.mobile + ' - ' + da.email as fulladdress from DISPATCH_NOTE_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as cm on cm.ID=em.client_id LEFT OUTER JOIN DELIVERY_ADDRESS_MASTER as da on da.ID=em.delivery_address_id order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGETDISPATCHNOTE data = new GeneralDataGETDISPATCHNOTE();
                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            GETDISPATCHNOTE d = new GETDISPATCHNOTE();
                            d.DNID = row["ID"].ToString();
                            d.CLIENT_ID = row["CLIENT_ID"].ToString();
                            d.CLIENT_NAME = row["clientname"].ToString();
                            d.DELIVERY_ADDRESS = row["fulladdress"].ToString();
                            d.SALE_ORDER_NO = row["SALES_ORDER_NO"].ToString();

                            if (row["SALES_ORDER_DATE"].ToString() != "")
                            {
                                d.SALE_ORDER_DATE = Convert.ToDateTime(row["SALES_ORDER_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.SALE_ORDER_DATE = "";
                            }
                            d.DELIVERY_NO = row["DELIVERY_NOTE_NO"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            if (row["DELIVERY_NOTE_DATE"].ToString() != "")
                            {
                                d.DELIVERY_DATE = Convert.ToDateTime(row["DELIVERY_NOTE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.DELIVERY_DATE = "";
                            }

                            d.ORDER_ACCEPTANCE_NO = row["ORDER_ACCEPTANCE_NO"].ToString();
                            if (row["ORDER_ACCEPTANCE_DATE"].ToString() != "")
                            {
                                d.ORDER_ACCEPTANCE_DATE = Convert.ToDateTime(row["ORDER_ACCEPTANCE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.ORDER_ACCEPTANCE_DATE = "";
                            }
                            d.DISPATCH_NO = row["DISPATCH_NO"].ToString();
                            if (row["DISPATCH_DATE"].ToString() != "")
                            {
                                d.DISPATCH_DATE = Convert.ToDateTime(row["DISPATCH_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.DISPATCH_DATE = "";
                            }
                            d.TRASPORTER = row["TRANSPORTER"].ToString();
                            d.CNNO = row["CN_NO"].ToString();
                            d.DISPATCH_TERM = row["DISPATCH_TERM"].ToString();
                            d.DISPATCH_THROUGH = row["DISPATCH_THROUGH"].ToString();
                            d.VAHICLE_NO = row["VEHICLE_NO"].ToString();
                            d.INTERNAL_INSPECTION_BY = row["INTERNAL_INSPECTION_BY"].ToString();
                            d.TP_INSPECTION_BY = row["THIRD_PARTY_INSPECTION_BY"].ToString();

                            List<GetDispatchItemData> pd = new List<GetDispatchItemData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[DISPATCH_NOTE_ITEM] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.item_id where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                GetDispatchItemData ep = new GetDispatchItemData();
                                ep.itemname = row2["itemname"].ToString();
                                ep.quantity = row2["QUANTITY"].ToString();
                                if (row2["DISPATCH_DATE"].ToString() != "")
                                {
                                    ep.delivery_date = Convert.ToDateTime(row2["DISPATCH_DATE"].ToString()).ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    ep.delivery_date = "";
                                }
                                ep.ProductRemark = row2["REMARK"].ToString();
                                pd.Add(ep);
                            }
                            d.GetDispatchItemData = pd;

                            List<InsertPackageInstruction> pi = new List<InsertPackageInstruction>();
                            DataTable dt3 = D.GetDataTable("select * from [dbo].[DISPATCH_NOTE_PACKING_INSTRUCTION] where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row3 in dt3.Rows)
                            {
                                InsertPackageInstruction s = new InsertPackageInstruction();
                                s.PACKING_INSTRUCTION = row3["PACKING_INSTRUCTION"].ToString();
                                pi.Add(s);
                            }
                            d.GetpackageData = pi;

                            List<InsertSpecialInstructiondispatch> si = new List<InsertSpecialInstructiondispatch>();
                            DataTable dt4 = D.GetDataTable("select * from [dbo].[DISPATCH_NOTE_SPECIAL_INSTRUCTION] where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row4 in dt4.Rows)
                            {
                                InsertSpecialInstructiondispatch s = new InsertSpecialInstructiondispatch();
                                s.SPECIAL_INSTRUCTION = row4["SPECIAL_INSTRUCTION"].ToString();
                                si.Add(s);
                            }
                            d.GetspecialinsData = si;

                            List<InsertRemark> rm = new List<InsertRemark>();
                            DataTable dt5 = D.GetDataTable("select * from [dbo].[DISPATCH_NOTE_REMARK_NOTE] where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row5 in dt5.Rows)
                            {
                                InsertRemark r = new InsertRemark();
                                r.REMARK = row5["REMARK_NOTE"].ToString();
                                rm.Add(r);
                            }
                            d.GetremarkData = rm;
                            cm.Add(d);
                        }
                        data.GetDispatchData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGETDISPATCHNOTE data = new GeneralDataGETDISPATCHNOTE();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGETDISPATCHNOTE data = new GeneralDataGETDISPATCHNOTE();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]
        public void GetSingleDispatchNoteData(string ACTION, string DID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<GETDISPATCHNOTE> cm = new List<GETDISPATCHNOTE>();
            List<GeneralDataGETDISPATCHNOTE> g = new List<GeneralDataGETDISPATCHNOTE>();
            try
            {
                if (ACTION == "getdispatchdata")
                {

                    string qry = "select em.*,cm.clientname,da.address + ' - ' + da.mobile + ' - ' + da.email as fulladdress from DISPATCH_NOTE_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as cm on cm.ID=em.client_id LEFT OUTER JOIN DELIVERY_ADDRESS_MASTER as da on da.ID=em.delivery_address_id where em.Client_id = " + DID + " order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataGETDISPATCHNOTE data = new GeneralDataGETDISPATCHNOTE();
                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            GETDISPATCHNOTE d = new GETDISPATCHNOTE();
                            d.DNID = row["ID"].ToString();
                            d.CLIENT_ID = row["CLIENT_ID"].ToString();
                            d.CLIENT_NAME = row["clientname"].ToString();
                            d.DELIVERY_ADDRESS = row["fulladdress"].ToString();
                            d.SALE_ORDER_NO = row["SALES_ORDER_NO"].ToString();

                            if (row["SALES_ORDER_DATE"].ToString() != "")
                            {
                                d.SALE_ORDER_DATE = Convert.ToDateTime(row["SALES_ORDER_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.SALE_ORDER_DATE = "";
                            }
                            d.DELIVERY_NO = row["DELIVERY_NOTE_NO"].ToString();
                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            if (row["DELIVERY_NOTE_DATE"].ToString() != "")
                            {
                                d.DELIVERY_DATE = Convert.ToDateTime(row["DELIVERY_NOTE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.DELIVERY_DATE = "";
                            }

                            d.ORDER_ACCEPTANCE_NO = row["ORDER_ACCEPTANCE_NO"].ToString();
                            if (row["ORDER_ACCEPTANCE_DATE"].ToString() != "")
                            {
                                d.ORDER_ACCEPTANCE_DATE = Convert.ToDateTime(row["ORDER_ACCEPTANCE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.ORDER_ACCEPTANCE_DATE = "";
                            }
                            d.DISPATCH_NO = row["DISPATCH_NO"].ToString();
                            if (row["DISPATCH_DATE"].ToString() != "")
                            {
                                d.DISPATCH_DATE = Convert.ToDateTime(row["DISPATCH_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.DISPATCH_DATE = "";
                            }
                            d.TRASPORTER = row["TRANSPORTER"].ToString();
                            d.CNNO = row["CN_NO"].ToString();
                            d.DISPATCH_TERM = row["DISPATCH_TERM"].ToString();
                            d.DISPATCH_THROUGH = row["DISPATCH_THROUGH"].ToString();
                            d.VAHICLE_NO = row["VEHICLE_NO"].ToString();
                            d.INTERNAL_INSPECTION_BY = row["INTERNAL_INSPECTION_BY"].ToString();
                            d.TP_INSPECTION_BY = row["THIRD_PARTY_INSPECTION_BY"].ToString();

                            List<GetDispatchItemData> pd = new List<GetDispatchItemData>();
                            DataTable dt2 = D.GetDataTable("select em.*,lm.itemname from [dbo].[DISPATCH_NOTE_ITEM] as em LEFT OUTER JOIN ITEM_MASTER as lm on lm.ID=em.item_id where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                GetDispatchItemData ep = new GetDispatchItemData();
                                ep.itemname = row2["itemname"].ToString();
                                ep.quantity = row2["QUANTITY"].ToString();
                                if (row2["DISPATCH_DATE"].ToString() != "")
                                {
                                    ep.delivery_date = Convert.ToDateTime(row2["DISPATCH_DATE"].ToString()).ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    ep.delivery_date = "";
                                }
                                ep.ProductRemark = row2["REMARK"].ToString();
                                pd.Add(ep);
                            }
                            d.GetDispatchItemData = pd;

                            List<InsertPackageInstruction> pi = new List<InsertPackageInstruction>();
                            DataTable dt3 = D.GetDataTable("select * from [dbo].[DISPATCH_NOTE_PACKING_INSTRUCTION] where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row3 in dt3.Rows)
                            {
                                InsertPackageInstruction s = new InsertPackageInstruction();
                                s.PACKING_INSTRUCTION = row3["PACKING_INSTRUCTION"].ToString();
                                pi.Add(s);
                            }
                            d.GetpackageData = pi;

                            List<InsertSpecialInstructiondispatch> si = new List<InsertSpecialInstructiondispatch>();
                            DataTable dt4 = D.GetDataTable("select * from [dbo].[DISPATCH_NOTE_SPECIAL_INSTRUCTION] where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row4 in dt4.Rows)
                            {
                                InsertSpecialInstructiondispatch s = new InsertSpecialInstructiondispatch();
                                s.SPECIAL_INSTRUCTION = row4["SPECIAL_INSTRUCTION"].ToString();
                                si.Add(s);
                            }
                            d.GetspecialinsData = si;

                            List<InsertRemark> rm = new List<InsertRemark>();
                            DataTable dt5 = D.GetDataTable("select * from [dbo].[DISPATCH_NOTE_REMARK_NOTE] where dispatch_note_id = " + row["id"].ToString());
                            foreach (DataRow row5 in dt5.Rows)
                            {
                                InsertRemark r = new InsertRemark();
                                r.REMARK = row5["REMARK_NOTE"].ToString();
                                rm.Add(r);
                            }
                            d.GetremarkData = rm;
                            cm.Add(d);
                        }
                        data.GetDispatchData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataGETDISPATCHNOTE data = new GeneralDataGETDISPATCHNOTE();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataGETDISPATCHNOTE data = new GeneralDataGETDISPATCHNOTE();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]
        public void InsertDeliveryAddress(string type, string Client_Id, string Data)
        {

            List<GeneralData> g = new List<GeneralData>();
            JavaScriptSerializer js = new JavaScriptSerializer();

            string ADDRESS = "";
            string MOBILE = "";
            string EMAIL = "";

            string RESULT = "";
            if (type == "insertaddress")
            {
                try
                {
                    //D.ExecuteQuery("delete from QUOTATION_MASTER where ID=" + qid);
                    string url = "";
                    JavaScriptSerializer _convert = new JavaScriptSerializer();
                    url = "[" + Data + "]";
                    var _Items = _convert.Deserialize<Insertdeliveryaddress[]>(url);
                    int cnt = _Items.Length;


                    for (int i = 0; i < cnt; i++)
                    {
                        ADDRESS = (new System.Web.UI.WebControls.ListItem(_Items[i].ADDRESS).ToString());
                        MOBILE = (new System.Web.UI.WebControls.ListItem(_Items[i].MOBILE).ToString());
                        EMAIL = (new System.Web.UI.WebControls.ListItem(_Items[i].EMAIL).ToString());
                        SqlCommand cm = new SqlCommand();
                        cm.Connection = conn;
                        cm.CommandText = "INSERT_DELIVERY_ADDRESS";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@CLIENT_ID", Client_Id);
                        cm.Parameters.AddWithValue("@ADDRESS", ADDRESS);
                        cm.Parameters.AddWithValue("@MOBILE", MOBILE);
                        cm.Parameters.AddWithValue("@EMAIL", EMAIL);

                        cm.Parameters.Add("@RESULT", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                        conn.Open();
                        cm.ExecuteNonQuery();
                        RESULT = cm.Parameters["@RESULT"].Value.ToString();
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.SelectCommand = cm;
                        conn.Close();
                        //string query = "insert into ENQUIRY_PRODUCT_MASTER(enquiry_id,item_id,UNIT,QTY,UNIT_PRICE,SUB_TOTAL_PRICE) values('" + dt.Rows[0]["ID"].ToString() + "','" + pid + "','" + Unit + "','" + Qty + "','" + Rate + "','" + Amount + "')";
                        //D.ExecuteQuery(query);


                    }

                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Successfully Updated";
                    data.ORIGINAL_ERROR = RESULT;
                    data.ERROR_STATUS = false;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }
                catch (Exception ex)
                {
                    GeneralData data = new GeneralData();
                    data.MESSAGE = "Failed To Load";
                    data.ORIGINAL_ERROR = ex.Message;
                    data.ERROR_STATUS = true;
                    data.RECORDS = false;
                    g.Add(data);
                    Context.Response.Write(js.Serialize(g[0]));
                }

            }
        }

        [WebMethod]
        public void GetDeliveryAddressData(string ACTION)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<DeliveryAddress> cm = new List<DeliveryAddress>();
            List<GeneralDataDeliveryAddress> g = new List<GeneralDataDeliveryAddress>();
            try
            {
                if (ACTION == "getaddress")
                {

                    string qry = "SELECT ID,address + ' - ' + mobile + ' - ' + email as fulladdress FROM [dbo].[DELIVERY_ADDRESS_MASTER] order by id desc";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataDeliveryAddress data = new GeneralDataDeliveryAddress();
                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            DeliveryAddress d = new DeliveryAddress();
                            d.ID = row["ID"].ToString();
                            d.Address = row["fulladdress"].ToString();
                            cm.Add(d);
                        }
                        data.GetAddress = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataDeliveryAddress data = new GeneralDataDeliveryAddress();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataDeliveryAddress data = new GeneralDataDeliveryAddress();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]
        public void GetSinglePurchaseOrderData(string ACTION, string PID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PurchaseOrder> cm = new List<PurchaseOrder>();
            List<GeneralDataPurchaseOrder> g = new List<GeneralDataPurchaseOrder>();
            try
            {
                if (ACTION == "getpurchaseorder")
                {

                    string qry = "SELECT pm.*,lm.clientname FROM [dbo].[PURCHASE_MASTER] as pm,CLIENT_MASTER as lm where lm.id = pm.client_id and client_id = " + PID;

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataPurchaseOrder data = new GeneralDataPurchaseOrder();
                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            PurchaseOrder d = new PurchaseOrder();
                            d.ID = row["ID"].ToString();
                            d.Client = row["clientname"].ToString();
                            if (row["CREATEDAT"].ToString() != "")
                            {
                                d.Date = Convert.ToDateTime(row["CREATEDAT"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.Date = "";
                            }
                            d.FilePath = row["FILE_PDF"].ToString();
                            cm.Add(d);
                        }
                        data.GetPurchaseOrderData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataPurchaseOrder data = new GeneralDataPurchaseOrder();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataPurchaseOrder data = new GeneralDataPurchaseOrder();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]
        public void GetHistoryStatusData(string ACTION, string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<HistoryData> cm = new List<HistoryData>();
            List<GeneralDataHistoryData> g = new List<GeneralDataHistoryData>();
            try
            {
                if (ACTION == "gethistory")
                {

                    string qry = "select (select count(*) from QUOTATION_MASTER where client_id = " + ID + ") as Quotation,(select count(*) from ORDER_ACCEPTANCE_MASTER  where quotation_id = " + ID + ") as OrderAcceptance,(SELECT count(*) FROM [dbo].[PURCHASE_MASTER] where client_id = " + ID + ") as PurchaseOrder,(select count(*) from PROFORMA_MASTER where client_id = " + ID + ") as ProformaInvoice,(select count(*) from DISPATCH_NOTE_MASTER where Client_id = " + ID + ") as DispatchNote,(select count(*) from [dbo].[PAYMENT_RECEIVED_MASTER] where client_id = " + ID + ") as Payment";

                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataHistoryData data = new GeneralDataHistoryData();
                        data.MESSAGE = "Successfully!";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            HistoryData d = new HistoryData();
                            if (row["Quotation"].ToString() == "0")
                            {
                                d.QuotationStatus = "";
                            }
                            else
                            {
                                d.QuotationStatus = "active";
                            }
                            if (row["OrderAcceptance"].ToString() == "0")
                            {
                                d.OrderAcceptanceStatus = "";
                            }
                            else
                            {
                                d.OrderAcceptanceStatus = "active";
                            }
                            if (row["PurchaseOrder"].ToString() == "0")
                            {
                                d.PurchaseOrderStatus = "";
                            }
                            else
                            {
                                d.PurchaseOrderStatus = "active";
                            }
                            if (row["ProformaInvoice"].ToString() == "0")
                            {
                                d.ProformaInvoice = "";
                            }
                            else
                            {
                                d.ProformaInvoice = "active";
                            }
                            if (row["DispatchNote"].ToString() == "0")
                            {
                                d.DispatchNote = "";
                            }
                            else
                            {
                                d.DispatchNote = "active";
                            }
                            if (row["Payment"].ToString() == "0")
                            {
                                d.Payment = "";
                            }
                            else
                            {
                                d.Payment = "active";
                            }
                            //d.Payment = "";
                            //d.QuotationStatus = row["Quotation"].ToString();
                            //d.OrderAcceptanceStatus = row["OrderAcceptance"].ToString();
                            //d.PurchaseOrderStatus = row["PurchaseOrder"].ToString();
                            //d.ProformaInvoice = row["ProformaInvoice"].ToString();
                            //d.DispatchNote = row["DispatchNote"].ToString();

                            cm.Add(d);
                        }
                        data.GetHistoryStatus = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataHistoryData data = new GeneralDataHistoryData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataHistoryData data = new GeneralDataHistoryData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }

        [WebMethod]

        public void GetCityData(string ACTION, string StateID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<CityData> cm = new List<CityData>();
            List<GeneralDataCityData> g = new List<GeneralDataCityData>();
            try
            {
                if (ACTION == "getcity")
                {
                    string qry = "";
                    //string cookiename = HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value;
                    //if (cookiename == "admin")
                    //{
                    qry = "select * from citymaster where stateid = " + StateID;
                    //}
                    //else
                    //{
                    //string cookieid = HttpContext.Current.Request.Cookies["ADMIN_ID"].Value;
                    //qry = "select em.*,lm.clientname,bm.BENEFICIARY_NAME from QUOTATION_MASTER as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id LEFT OUTER JOIN BANK_MASTER as bm on bm.ID=em.bank_id where em.approval = 1 order by id desc";
                    //}
                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataCityData data = new GeneralDataCityData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            CityData d = new CityData();
                            d.ID = row["ID"].ToString();
                            d.CityName = row["Name"].ToString();


                            cm.Add(d);
                        }
                        data.GetCityData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataCityData data = new GeneralDataCityData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataCityData data = new GeneralDataCityData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
        [WebMethod]

        public void GetSinglePaymentData(string ACTION, string PID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PaymentData> cm = new List<PaymentData>();
            List<GeneralDataPaymentData> g = new List<GeneralDataPaymentData>();
            try
            {
                if (ACTION == "getpaymentdata")
                {
                    string qry = "";

                    qry = "select em.*,lm.clientname from [dbo].[PAYMENT_RECEIVED_MASTER] as em LEFT OUTER JOIN CLIENT_MASTER as lm on lm.ID=em.client_id where client_id = " + PID;
                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {
                        GeneralDataPaymentData data = new GeneralDataPaymentData();
                        data.MESSAGE = "";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = false;
                        data.RECORDS = true;
                        foreach (DataRow row in dt.Rows)
                        {
                            PaymentData d = new PaymentData();
                            d.ID = row["id"].ToString();
                            d.ClientName = row["clientname"].ToString();
                            d.Mode_Of_Payment = row["MODE_OF_PAYMENT"].ToString();
                            d.BankName = row["BANK_NAME"].ToString();
                            d.Cheque_no = row["CHEQUE_NO"].ToString();
                            if (row["DATE_OF_RECEIVED"].ToString() != "")
                            {
                                d.Date_of_Received = Convert.ToDateTime(row["DATE_OF_RECEIVED"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.Date_of_Received = "";
                            }

                            //d.date = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MM-yyyy");
                            //d.time = Convert.ToDateTime(row["date"].ToString()).ToString("HH:mm:ss tt");
                            d.Amount = row["AMOUNT"].ToString();
                            d.Payment_mode = row["PAYMENT_MODE"].ToString();
                            if (row["CREATED_DATE"].ToString() != "")
                            {
                                d.Created_Date = Convert.ToDateTime(row["CREATED_DATE"].ToString()).ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                d.Created_Date = "";
                            }



                            cm.Add(d);
                        }
                        data.GetPaymentData = cm;
                        g.Add(data);
                        Context.Response.Write(js.Serialize(g[0]));
                        return;
                    }
                    else
                    {
                        GeneralDataPaymentData data = new GeneralDataPaymentData();
                        data.MESSAGE = "Data Not Found ! ";
                        data.ORIGINAL_ERROR = "";
                        data.ERROR_STATUS = true;
                        data.RECORDS = false;
                        g.Add(data);
                    }
                    Context.Response.Write(js.Serialize(g[0]));
                    return;
                }
            }
            catch (Exception ex)
            {
                GeneralDataPaymentData data = new GeneralDataPaymentData();
                data.MESSAGE = "Failed To Load";
                data.ORIGINAL_ERROR = ex.Message;
                data.ERROR_STATUS = true;
                data.RECORDS = false;
                g.Add(data);
                Context.Response.Write(js.Serialize(g[0]));
            }
        }
    }
}
