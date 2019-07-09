using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Connection
    {
        //SqlConnection cnnnn1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["asddsad"].ToString());
        SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ConnectionString.ToString());

        public Connection()
        {
        }
        public void ExecuteQuery(string qry)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public DataTable GetDataWithSP(SqlCommand sc)
        {
            DataTable dt = new DataTable();
            try
            {
                cnn.Open();


                SqlCommand cmd = sc;
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        public void ExecuteQueryWithSP(SqlCommand sc)
        {
            try
            {
                cnn.Open();
                SqlCommand cmd = sc;
                cmd.Connection = cnn;
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                cnn.Close();
            }

        }

        public void ExecuteQuery(string qry, SqlConnection con)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetData(string qry)
        {
            cnn.Open();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(qry, cnn);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public DataTable GetDataWithConn(string qry, SqlConnection con)
        {
            con.Open();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }

    public class AdminMaster
    {
        public string ID { get; set; }

        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string NAME { get; set; }

    }


    public class SelectRegisterData
    {
        public string id { get; set; }
        public string height { get; set; }

        public string weight { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string birthplace { get; set; }
        public string caste { get; set; }
        public string subcaste { get; set; }
        public string img { get; set; }
        public string education { get; set; }
        public string income { get; set; }


    }
    public class CategoryMaster
    {
        public string ID { get; set; }
        public string NAME { get; set; }
        public string PARENT_ID { get; set; }

        public string DESCRIPTION { get; set; }
        public string IMAGE_NAME { get; set; }
        public Boolean SHOW_ON_HOME_PAGE { get; set; }
        public Boolean INCLUDE_IN_TOP_MENUS { get; set; }

        public string DISPLAY_ORDER { get; set; }

        public string IS_NEW { get; set; }
        public string URL_KEY { get; set; }
        public Boolean STATUS { get; set; }
        public string TOTAL_PRODUCT { get; set; }

        public Boolean SHOP_BY_CATEGORY { get; set; }
        public string THUMB_IMAGE { get; set; }
    }
    public class Customer
    {
        public string GUID { get; set; }

        public string USER_NAME { get; set; }
        public string NAME { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public string IS_VENDER { get; set; }
        public string ID { get; set; }

        public string PASSWORD { get; set; }

        public string VENDOR_ID { get; set; }

        public string HAS_SHOPPING_CART_ITEMS { get; set; }

        public string STATUS { get; set; }

        public string LAST_IP_ADDRESS { get; set; }

        public string CREATED_DATE { get; set; }

        public string UPDATED_DATE { get; set; }

        public string LAST_LOGIN_DATE { get; set; }

        public string BILLING_ADDRESS { get; set; }

        public string SHIPPING_ADDRESS { get; set; }



    }




    public class MESSAGE_RSULT
    {
        public string MESSAGE { get; set; }
        public string ORIGINAL_ERROR { get; set; }
        public Boolean ERROR_STATUS { get; set; }
        //public int STATUS { get; set; }
        public Boolean RECORDS { get; set; }
    }

    public class GET_QUOTATION_DETAILS
    {
        public int ID { get; set; }
        public DateTime? QUOTATION_DATE { get; set; }
        public string DOC_NO { get; set; }
        public string QUOTATION_NO { get; set; }
        public string ENQUIRY_REFERENCE { get; set; }
        public DateTime? ENQUIERY_DATE { get; set; }
        public string TAXES { get; set; }
        public string FREIGHT_INSURANCE { get; set; }
        public string MODE_OF_DISPATCH { get; set; }
        public string SPECIAL_TERM { get; set; }
        public string CLIENTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string MOBILE { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCH { get; set; }
        public string ACCOUNT_NO { get; set; }
        public string RTGS_NEFT_CODE { get; set; }
        public string SWIFT_CODE { get; set; }
        public int? FREIGHT_CHARGES { get; set; }
        public decimal? TAX { get; set; }
        public decimal? SUB_TOTAL { get; set; }
        public decimal? TOTAL_AMT { get; set; }
        public string DELIVERY_TERM { get; set; }
        public string DELIVERY_SCHEDULE { get; set; }
        public string PAYMENT_TERMS { get; set; }


    }

    public class GET_QUOTATION_ITEAM_DETAILS
    {
        public string ITEMNAME { get; set; }
        public string UNIT { get; set; }
        public int? QUANTITY { get; set; }
        public int? UNIT_PRICE { get; set; }
        public int? TOTAL_PRICE { get; set; }
    }

    public class GET_PROFORMA_INVOICE_DETAILS
    {
        public int ID { get; set; }
        public DateTime? PI_DATE { get; set; } //PROFORMA_DATE as Pi_Date
        public string DOC_NO { get; set; }
        public string PI_NO { get; set; } // PROFORMA_REFERENCE as PI_NO
        public string ENQUIRY_REFERENCE { get; set; }
        public DateTime? ENQUIERY_DATE { get; set; }
        public string TAXES { get; set; }
        public string FREIGHT_INSURANCE { get; set; }
        public string MODE_OF_DISPATCH { get; set; }
        public string SPECIAL_TERM { get; set; }
        public string DELIVERY_TERM { get; set; }
        public string DELIVERY_SCHEDULE { get; set; }
        public string CLIENTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string MOBILE { get; set; }
        public string BENEFICIARY_NAME { get; set; }
        public string BANKNAME { get; set; }
        public string BRANCH { get; set; }
        public string ACCOUNT_NO { get; set; }
        public string RTGS_NEFT_CODE { get; set; }
        public string SWIFT_CODE { get; set; }
        public int? TAX { get; set; }
        public int? SUB_TOTAL { get; set; }
        public int? TOTAL_AMT { get; set; }
        public string HSN_SAC_CODE { get; set; }

    }

    public class GET_PROFORMA_INVOICE_ITEM_DETAILS
    {
        public string ITEMNAME { get; set; }
        public string UNIT { get; set; }
        public int? QUANTITY { get; set; }
        public int? UNIT_PRICE { get; set; }
        public int? TOTAL_PRICE { get; set; }
    }


    public class ROOT_TASKDATA
    {
        public string MESSAGE { get; set; }
        public string ORIGINAL_ERROR { get; set; }
        public Boolean ERROR_STATUS { get; set; }
        //public int STATUS { get; set; }
        public Boolean RECORDS { get; set; }
        public List<AddTask> TASK_DATA { get; set; }
    }

    public class AddTask
    {

        public string REMINDER_DAY_BEFORE { get; set; }
        public string ID { get; set; }
        public string TASK_ID { get; set; }
        public string ASSIGN_TO { get; set; }
        public string SUBJECT { get; set; }
        public string START_DATE { get; set; }
        public string DUE_DATE { get; set; }
        public string STATUS { get; set; }
        public string PRIORITY { get; set; }
        public string IS_REPEAT { get; set; }
        public string REPEAT_TYPE { get; set; }
        public string REPEAT_FOR_EVERYDAY { get; set; }
        public string REPEAT_FOR_EVERYWEEK { get; set; }

        public bool IS_ON_DAYWISE { get; set; }
        public string MONTH_DAYS_NO { get; set; }
        public string MONTH_DAY_NO { get; set; }
        public string MONTH_WEEK_SEQUENCE_TYPE { get; set; }
        public string MONTH_WEEKSEQUENCE_DAY { get; set; }
        public string MONTH_WEEKSEQUENCE_MONTH_NO { get; set; }
        public string DESCRIPTION { get; set; }
        public bool IS_EVERY_DAY { get; set; }
        public bool WORK_FROM_HOME { get; set; }

        public string REPEAT_WEEK_ON { get; set; }
        public string CREATED { get; set; }
        public string CLOSED_DATE { get; set; }
        public string IS_CLOSED { get; set; }

        public string NOTES { get; set; }
        public string TASK_OWNER_NAME { get; set; }
        public string TASK_OWNER_ID { get; set; }
        public string ASSIGNED_EMPLOYEE_NAME { get; set; }

        public bool IS_YEARLY_DAYS_ON { get; set; }
        public string YEARLY_DAYS_OF_MONTH { get; set; }
        public string YEARLY_DAYS_NO { get; set; }
        public string YEARLY_WEEKSEQUENCE_TYPE { get; set; }
        public string YEARLY_WEEKSEQUENCE_NO { get; set; }
        public string YEARLY_WEEKSEQUENCE_MONTH_NAME { get; set; }
        public string CLIENT_GROUP { get; set; }
        public string NATURE_OF_WORK { get; set; }
        public string FINANCIAL_YEAR { get; set; }
        public string ASSESSMENT_YEAR { get; set; }
        public string CONTACT_PERSON { get; set; }
        public string CONTACT_NUMBER { get; set; }
        public string CONTACT_EMAIL_ID { get; set; }
        public string TARGETED_DAYS { get; set; }

        public string ACTUAL_DAYS_TAKEN { get; set; }
        public string ACTUAL_WORK_FINISH_DATE { get; set; }
        public string POST_ID { get; set; }


    }
    public class ROOT_NOTIFICATION_MASTER
    {
        public string MESSAGE { get; set; }
        public string ORIGINAL_ERROR { get; set; }
        public Boolean ERROR_STATUS { get; set; }
        //public int STATUS { get; set; }
        public Boolean RECORDS { get; set; }
        public List<NOTIFICATION_MASTER> NOTIFICATION_DATA { get; set; }
    }
    public class NOTIFICATION_MASTER
    {
        public string ID { get; set; }
        public string MODULE_TYPE { get; set; }
        public string NOTIFICATION_MESSAGE { get; set; }
        public string CREATED { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string TASK_OWNER_NAME { get; set; }

    }
    public class GET_ORDER_ACCEPTANCE_INVOICE_DETAILS
    {
        public int ID { get; set; }
        public int? QUOTATION_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CUSTOMER_MOBILE { get; set; }
        public string CUSTOMER_ADDRESS { get; set; }
        public string CUSTOMER_PHONE { get; set; }
        public string CUSTOMER_EMAIL { get; set; }
        public string DELIVERY_ADDRESS { get; set; }
        public string DELIVERY_PHONE { get; set; }
        public string DELIVERY_EMAIL { get; set; }
        public string PROFORMA_NO { get; set; }
        public DateTime? PROFORMA_DATE { get; set; }
        public string PERCHASE_NO { get; set; }
        public DateTime? PERCHASE_DATE { get; set; }
        public string ORDER_ACCEPTANCE_NO { get; set; }
        public DateTime? ORDER_ACCEPTANCE_DATE { get; set; }
        public string INSPECTION_BY { get; set; }
        public string INSURANCE_BY { get; set; }
        public string MODE_OF_DISPATCH { get; set; }
        public string TRANSPORTER { get; set; }

        public string PREPARED_BY { get; set; }
        public string APPROVED_BY { get; set; }
    }
    public class GET_ORDER_ACCEPTANCE_INVOICE_SPECIAL_INSTRUCTION
    {
        public string SPECIAL_INSTRUCTIONS { get; set; }
    }
    public class GET_ORDER_ACCEPTANCE_INVOICE_ITEM_DETAILS
    {
        public string ITEMNAME { get; set; }
        public int? QUANTITY { get; set; }
        public DateTime? DELIVERY_DATE { get; set; }



    }
    public class GET_DISPATCH_NOTE_INVOICE_DETAILS
    {
        public long ID { get; set; }
        public long? CLIENT_ID { get; set; }
        public int? DELIVERY_ADDRESS_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CUSTOMER_MOBILE { get; set; }
        public string CUSTOMER_ADDRESS { get; set; }
        public string CUSTOMER_PHONE { get; set; }
        public string CUSTOMER_EMAIL { get; set; }
        public string DELIVERY_ADDRESS { get; set; }
        public string DELIVERY_PHONE { get; set; }
        public string DELIVERY_EMAIL { get; set; }

        public string SALES_ORDER_NO { get; set; }
        public DateTime? SALES_ORDER_DATE { get; set; }
        public string DELIVERY_NOTE_NO { get; set; }
        public DateTime? DELIVERY_NOTE_DATE { get; set; }
        public string ORDER_ACCEPTANCE_NO { get; set; }
        public DateTime? ORDER_ACCEPTANCE_DATE { get; set; }
        public string DISPATCH_NO { get; set; }
        public DateTime? DISPATCH_DATE { get; set; }
        public string TRANSPORTER { get; set; }
        public string CN_NO { get; set; }
        public string DISPATCH_TERM { get; set; }
        public string DISPATCH_THROUGH { get; set; }
        public string VEHICLE_NO { get; set; }
        public string INTERNAL_INSPECTION_BY { get; set; }
        public string THIRD_PARTY_INSPECTION_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string PREPARED_BY { get; set; }
        public string APPROVED_BY { get; set; }

    }
    public class GET_DISPATCH_NOTE_INVOICE_ITEM_DETAILS
    {
        public string ITEMNAME { get; set; }
        public int? QUANTITY { get; set; }
        public DateTime? DISPATCH_DATE { get; set; }
        public string REMARK { get; set; }

    }


    public class GET_DISPATCH_NOTE_INVOICE_PACKING_INSTRUCTION
    {
        public string PACKING_INSTRUCTION { get; set; }
    }
    public class GET_DISPATCH_NOTE_INVOICE_REMARK_NOTE
    {
        public string REMARK_NOTE { get; set; }
    }
    public class GET_DISPATCH_NOTE_INVOICE_SPECIAL_INSTRUCTION
    {
        public string SPECIAL_INSTRUCTION { get; set; }
    }


}