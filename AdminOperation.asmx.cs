using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI.WebControls;
using TaskManager.Models;
using System.Runtime.Caching;

namespace TaskManager
{
    /// <summary>
    /// Summary description for AdminOperation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminOperation : System.Web.Services.WebService
    {
        //SqlCommand cmd = new SqlCommand();
        SqlConnection cnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ECommerceAdmin"].ConnectionString.ToString());

        Connection cc = new Connection();
        GetData D = new GetData();
        public AdminOperation()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void AddTask(string type, string Data, string START_DATE, string DUE_DATE, string ASSIGN_TO, string REPEAT_TYPE, string CLIENT_GROUP, string NATURE_OF_WORK,string FINANCIAL_YEAR, string CONTACT_PERSON)
        {
            List<MESSAGE_RSULT> list = new List<MESSAGE_RSULT>();
            MESSAGE_RSULT rd = new MESSAGE_RSULT();
            string emp_id = HttpContext.Current.Request.Cookies["admin_id"].Value;

            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                //DateTime sdfsdf = Convert.ToDateTime(DUE_DATE);

                //DateTime ddd = DateTime.ParseExact(DUE_DATE,"yyyy-MM-dd",null);

                //DUE_DATE = String.Format("{0:y yy yyy yyyy}", Convert.ToDateTime(DUE_DATE));  // "8 08 008 2008"   year

                //IFormatProvider culture = new CultureInfo("en-US", true);
                //DateTime duedt = new DateTime();
                //DateTime.TryParse(DUE_DATE, out duedt);
                
                //DUE_DATE = dateDue.ToString();
                if (type == "add_task")
                {
                    //string FINANCIAL_YEAR = "";
                    string ASSESSMENT_YEAR = "";
                    string CONTACT_NUMBER = "" ;
                    string CONTACT_EMAIL_ID= "";
                    string TARGETED_DAYS= "";

                    //string ASSIGN_TO = "";
                    string REMINDER_DAY_BEFORE = "-1";
                    string SUBJECT = "";
                    string STATUS = "";
                    string PRIORITY = "";
                    string IS_REPEAT = "";
                    //    string REPEAT_TYPE = "";
                    string REPEAT_FOR_EVERYDAY = "";
                    string REPEAT_FOR_EVERYWEEK = "";
                    string MONTH_DAYS_NO = ""; // its dropdown value 
                    string MONTH_DAY_NO = ""; //its value of    Of every [1.2..] month
                    string MONTH_WEEK_SEQUENCE_TYPE = "";
                    string MONTH_WEEKSEQUENCE_DAY = "";
                    string MONTH_WEEKSEQUENCE_MONTH_NO = "";
                    string DESCRIPTION = "";
                    bool IS_EVERY_DAY = false;
                    //bool WORK_FROM_HOME = false;
                    string REPEAT_WEEK_ON = "";

                    bool IS_ON_DAYWISE = true;



                    //for repeat type :yearly
                    bool IS_YEARLY_DAYS_ON = false;
                    string YEARLY_DAYS_OF_MONTH = "";
                    string YEARLY_DAYS_NO = "";
                    string YEARLY_WEEKSEQUENCE_TYPE = "";
                    string YEARLY_WEEKSEQUENCE_NO = "";
                    string YEARLY_WEEKSEQUENCE_MONTH_NAME = "";


                    var _Items_attrm = js.Deserialize<AddTask>(Data);
                    //int cnt = _Items_attrm.Length;

                    //for (int i = 0; i < cnt; i++)
                    //{


                    REMINDER_DAY_BEFORE = (new ListItem(_Items_attrm.REMINDER_DAY_BEFORE).ToString());
                    if (REMINDER_DAY_BEFORE == "")
                        REMINDER_DAY_BEFORE = "-1";

                    IS_REPEAT = (new ListItem(_Items_attrm.IS_REPEAT).ToString());
                    SUBJECT = (new ListItem(_Items_attrm.SUBJECT).ToString());
                    STATUS = (new ListItem(_Items_attrm.STATUS).ToString());
                    PRIORITY = (new ListItem(_Items_attrm.PRIORITY).ToString());

                    // REPEAT_TYPE = (new ListItem(_Items_attrm.REPEAT_TYPE).ToString());
                    REPEAT_FOR_EVERYDAY = (new ListItem(_Items_attrm.REPEAT_FOR_EVERYDAY).ToString());
                    REPEAT_FOR_EVERYWEEK = (new ListItem(_Items_attrm.REPEAT_FOR_EVERYWEEK).ToString());

                    string is_on_daywise = (new ListItem(_Items_attrm.IS_ON_DAYWISE.ToString()).ToString());
                    IS_ON_DAYWISE = Convert.ToBoolean(is_on_daywise);
                    MONTH_DAYS_NO = (new ListItem(_Items_attrm.MONTH_DAYS_NO).ToString());
                    MONTH_DAY_NO = (new ListItem(_Items_attrm.MONTH_DAY_NO).ToString());

                    MONTH_WEEK_SEQUENCE_TYPE = (new ListItem(_Items_attrm.MONTH_WEEK_SEQUENCE_TYPE).ToString());

                    MONTH_WEEKSEQUENCE_DAY = (new ListItem(_Items_attrm.MONTH_WEEKSEQUENCE_DAY).ToString());
                    MONTH_WEEKSEQUENCE_MONTH_NO = (new ListItem(_Items_attrm.MONTH_WEEKSEQUENCE_MONTH_NO).ToString());
                    DESCRIPTION = (new ListItem(_Items_attrm.DESCRIPTION).ToString());

                    string is_every_day = (new ListItem(_Items_attrm.IS_EVERY_DAY.ToString()).ToString());
                    IS_EVERY_DAY = Convert.ToBoolean(is_every_day);

                    //string work_from_home = (new ListItem(_Items_attrm.WORK_FROM_HOME.ToString()).ToString());
                    //WORK_FROM_HOME = Convert.ToBoolean(work_from_home);

                    REPEAT_WEEK_ON = (new ListItem(_Items_attrm.REPEAT_WEEK_ON).ToString());

                    //for repeat type: yearly
                    YEARLY_DAYS_OF_MONTH = (new ListItem(_Items_attrm.YEARLY_DAYS_OF_MONTH).ToString());
                    YEARLY_DAYS_NO = (new ListItem(_Items_attrm.YEARLY_DAYS_NO).ToString());
                    YEARLY_WEEKSEQUENCE_TYPE = (new ListItem(_Items_attrm.YEARLY_WEEKSEQUENCE_TYPE).ToString());
                    YEARLY_WEEKSEQUENCE_NO = (new ListItem(_Items_attrm.YEARLY_WEEKSEQUENCE_NO).ToString());
                    YEARLY_WEEKSEQUENCE_MONTH_NAME = (new ListItem(_Items_attrm.YEARLY_WEEKSEQUENCE_MONTH_NAME).ToString());
                    string is_yearly_days_on = (new ListItem(_Items_attrm.IS_YEARLY_DAYS_ON.ToString()).ToString());
                    IS_YEARLY_DAYS_ON = Convert.ToBoolean(is_yearly_days_on);

                    //FINANCIAL_YEAR = (new ListItem(_Items_attrm.FINANCIAL_YEAR).ToString());
                    ASSESSMENT_YEAR = (new ListItem(_Items_attrm.ASSESSMENT_YEAR).ToString());
                    CONTACT_NUMBER = (new ListItem(_Items_attrm.CONTACT_NUMBER).ToString());
                    CONTACT_EMAIL_ID = (new ListItem(_Items_attrm.CONTACT_EMAIL_ID).ToString());
                    TARGETED_DAYS = (new ListItem(_Items_attrm.TARGETED_DAYS).ToString());                    
                    //  }

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "ADD_TASK";
                    cnn.Open();
                    cmd.Connection = cnn;

                    cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                    cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                    cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                    cmd.Parameters.AddWithValue("@DUE_DATE", DUE_DATE.ToString());
                    cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                    cmd.Parameters.AddWithValue("@STATUS", STATUS);
                    cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                    cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                    cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                    cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                    cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                    cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                    cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                    cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                    cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                    cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                    cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                    cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                    cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                    cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                    

                    //cmd.Parameters.AddWithValue("@CLIENT_GROUP", CLIENT_GROUP);
                    //cmd.Parameters.AddWithValue("@NATURE_OF_WORK", NATURE_OF_WORK);
                    //cmd.Parameters.AddWithValue("@FINANCIAL_YEAR", FINANCIAL_YEAR);
                    //cmd.Parameters.AddWithValue("@ASSESSMENT_YEAR", ASSESSMENT_YEAR);
                    //cmd.Parameters.AddWithValue("@CONTACT_PERSON", CONTACT_PERSON);
                    //cmd.Parameters.AddWithValue("@CONTACT_NUMBER", CONTACT_NUMBER);
                    //cmd.Parameters.AddWithValue("@CONTACT_EMAIL_ID", CONTACT_EMAIL_ID);
                    //cmd.Parameters.AddWithValue("@TARGETED_DAYS", TARGETED_DAYS);

                    cmd.Parameters.AddWithValue("@T_ID", 0).Direction = ParameterDirection.InputOutput;


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    string TASK_ID = cmd.Parameters["@T_ID"].Value.ToString();
                    //  string option_value = "";
                    if (IS_REPEAT == "True")
                    {
                        int tot_days = Convert.ToInt32((Convert.ToDateTime(DUE_DATE) - Convert.ToDateTime(START_DATE)).TotalDays);
                        if (REPEAT_TYPE == "Daily")
                        {
                            InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, START_DATE, SUBJECT, STATUS, PRIORITY, IS_REPEAT,REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO,MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                ,CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);

                            
                            for (int j = 0; j < tot_days; )
                            {
                                if (IS_EVERY_DAY == true)
                                    j++;
                                else
                                    j = j + Convert.ToInt32(REPEAT_FOR_EVERYDAY);

                                InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, Convert.ToDateTime(START_DATE).AddDays(j).ToString(), SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);

                                //cmd.Parameters.Clear();
                                //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                                //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                                //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                                //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                                //cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(START_DATE).AddDays(j));
                                //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                                //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                                //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                                //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                                //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                                //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                                //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                                //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                                //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                                //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                                //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                                //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                                //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                                //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                                //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                                //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                                ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                                //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);
                                //cmd.CommandType = CommandType.StoredProcedure;
                                //cmd.ExecuteNonQuery();
                            }
                        }
                        else if (REPEAT_TYPE == "Weekly")
                        {
                            if (REPEAT_WEEK_ON.ToString().EndsWith(","))
                                REPEAT_WEEK_ON = REPEAT_WEEK_ON.Remove(REPEAT_WEEK_ON.Length - 1, 1);

                            string[] repeat_on = REPEAT_WEEK_ON.Split(',');
                            int tot_week = Convert.ToInt32((Convert.ToDateTime(DUE_DATE) - Convert.ToDateTime(START_DATE)).TotalDays);
                            //tot_week = tot_week / 7;
                            cmd.Parameters.Clear();
                            cmd.CommandText = "ADD_TASK_MASTER";

                            for (int k = 0; k < repeat_on.Length; k++)
                            {
                                string repeat_on_day = repeat_on[k].ToString();
                                for (int j = 0; j <= tot_week; )
                                {
                                    DateTime wdate = Convert.ToDateTime(START_DATE).AddDays(j);
                                    if (repeat_on_day == wdate.DayOfWeek.ToString())
                                    {
                                        j = j + (7 * Convert.ToInt16(REPEAT_FOR_EVERYWEEK));
                                        InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, Convert.ToDateTime(wdate).ToString(), SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);

                                        //cmd.Parameters.Clear();
                                        //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                                        //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                                        //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                                        //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                                        //cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(wdate));
                                        //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                                        //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                                        //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                                        //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                                        //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                                        //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                                        //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                                        //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                                        ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                                        //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);
                                        //cmd.CommandType = CommandType.StoredProcedure;
                                        //cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        j = j + 1;
                                    }
                                    //j = j + 7;

                                }
                            }
                        }
                        #region Block for repeat type:monthly
                        else if (REPEAT_TYPE == "Monthly")
                        {
                            if (REPEAT_WEEK_ON.ToString().EndsWith(","))
                                REPEAT_WEEK_ON = REPEAT_WEEK_ON.Remove(REPEAT_WEEK_ON.Length - 1, 1);

                            DateTime mdate = Convert.ToDateTime(START_DATE);
                            int tot_day = Convert.ToInt32((Convert.ToDateTime(DUE_DATE) - Convert.ToDateTime(START_DATE)).TotalDays);
                            //tot_week = tot_week / 7;
                            cmd.Parameters.Clear();
                            cmd.CommandText = "ADD_TASK_MASTER";
                            int sequence_j = 1;
                            int month = 1;
                            for (int j = 0; j <= tot_day; )
                            {
                                if (IS_ON_DAYWISE == false)
                                {
                                    int sequence = Convert.ToInt32(GetSequenceOnString(MONTH_WEEK_SEQUENCE_TYPE));

                                    //j = j + Convert.ToInt16(MONTH_WEEKSEQUENCE_MONTH_NO);
                                    int delta = DayOfWeek.Monday - mdate.DayOfWeek;
                                    int delta1 = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), MONTH_WEEKSEQUENCE_DAY) - mdate.DayOfWeek;
                                    //FirstDayOfWeek(mdate);


                                    //DateTime monday = mdate.AddDays(delta);
                                    bool dddd = NthDayOfMonth(mdate, (DayOfWeek)Enum.Parse(typeof(DayOfWeek), MONTH_WEEKSEQUENCE_DAY), sequence);
                                    if (dddd == true)
                                    {
                                        InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, Convert.ToDateTime(mdate).ToString(), SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);

                                        //cmd.Parameters.Clear();
                                        //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                                        //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                                        //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                                        //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                                        //cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(mdate));
                                        //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                                        //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                                        //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                                        //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                                        //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                                        //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                                        //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                                        //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                                        ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                                        //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);
                                        //cmd.CommandType = CommandType.StoredProcedure;
                                        //cmd.ExecuteNonQuery();

                                        // var firstDayOfMonth = new DateTime(mdate.Year, mdate.Month, 1);
                                        //  int day_of_month = firstDayOfMonth.Day;
                                        int days = DateTime.DaysInMonth(mdate.Year, mdate.Month);
                                        int day = mdate.Day;
                                        int rest_days = days - Convert.ToInt16(day);
                                        mdate = mdate.AddDays(rest_days);
                                        j = (j + rest_days);
                                        //mdate = mdate.AddDays(rest_days * Convert.ToInt16(MONTH_WEEKSEQUENCE_MONTH_NO));
                                        //j = (j + rest_days) * Convert.ToInt16(MONTH_WEEKSEQUENCE_MONTH_NO);
                                    }
                                    else
                                    {
                                        j = j + 1;
                                        mdate = mdate.AddDays(1);
                                    }
                                }
                                else
                                {
                                    int nweday = mdate.Day;
                                    if (Convert.ToInt16(MONTH_DAYS_NO) == nweday)
                                    {
                                        var dayyy = new DateTime(mdate.Year, mdate.Month, Convert.ToInt16(MONTH_DAYS_NO));
                                        InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, Convert.ToDateTime(mdate).ToString(), SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);


                                        //cmd.Parameters.Clear();
                                        //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                                        //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                                        //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                                        //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                                        //cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(mdate));
                                        //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                                        //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                                        //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                                        //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                                        //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                                        //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                                        //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                                        //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                                        ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                                        //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);
                                        //cmd.CommandType = CommandType.StoredProcedure;
                                        //cmd.ExecuteNonQuery();
                                        //mdate = mdate.AddMonths(Convert.ToInt16(MONTH_DAY_NO));
                                        //int dayss = DateTime.DaysInMonth(mdate.Year, mdate.Month);
                                        //j = j + (dayss * Convert.ToInt16(MONTH_DAY_NO));
                                    }
                                    else
                                    {
                                        //int day = mdate.Day;
                                        //int days = DateTime.DaysInMonth(mdate.Year, mdate.Month);
                                        //int rest_days = days - Convert.ToInt16(day);
                                        //mdate = mdate.AddDays(rest_days);
                                        //j = j + rest_days + 100;
                                        mdate = mdate.AddDays(1);
                                        j++;
                                    }
                                }
                            }
                        }
                        #endregion


                        #region Block for repeat type:yearly
                        else if (REPEAT_TYPE == "Yearly")
                        {
                            DateTime mdate = Convert.ToDateTime(START_DATE);
                            int tot_day = Convert.ToInt32((Convert.ToDateTime(DUE_DATE) - Convert.ToDateTime(START_DATE)).TotalDays);
                            cmd.Parameters.Clear();
                            cmd.CommandText = "ADD_TASK_MASTER";
                            int sequence_j = 1;
                            int month = 1;
                            for (int j = 0; j <= tot_day; )
                            {
                                if (IS_YEARLY_DAYS_ON == true)
                                {

                                    var dayyy = new DateTime(mdate.Year, Convert.ToInt16(YEARLY_DAYS_OF_MONTH), Convert.ToInt16(YEARLY_DAYS_NO));
                                    int sequence = Convert.ToInt32(GetSequenceOnString(YEARLY_WEEKSEQUENCE_TYPE));

                                    //j = j + Convert.ToInt16(MONTH_WEEKSEQUENCE_MONTH_NO);
                                    int delta = DayOfWeek.Monday - mdate.DayOfWeek;
                                    int delta1 = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), MONTH_WEEKSEQUENCE_DAY) - mdate.DayOfWeek;
                                    //FirstDayOfWeek(mdate);
                                    //DateTime monday = mdate.AddDays(delta);
                                    bool dddd = NthDayOfMonth(mdate, (DayOfWeek)Enum.Parse(typeof(DayOfWeek), YEARLY_WEEKSEQUENCE_NO), sequence);
                                    int mnth = mdate.Month;
                                    if (dddd == true && mnth == Convert.ToInt16(YEARLY_WEEKSEQUENCE_MONTH_NAME))
                                    {
                                        InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, Convert.ToDateTime(mdate).ToString(), SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);


                                        //cmd.Parameters.Clear();
                                        //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                                        //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                                        //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                                        //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                                        //cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(mdate));
                                        //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                                        //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                                        //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                                        //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                                        //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                                        //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                                        //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                                        //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                                        ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                                        //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);
                                        //cmd.CommandType = CommandType.StoredProcedure;
                                        //cmd.ExecuteNonQuery();

                                        // var firstDayOfMonth = new DateTime(mdate.Year, mdate.Month, 1);
                                        //  int day_of_month = firstDayOfMonth.Day;
                                        int days = DateTime.DaysInMonth(mdate.Year, mdate.Month);

                                        int day = mdate.Day;
                                        int rest_days = days - Convert.ToInt16(day);
                                        mdate = mdate.AddDays(rest_days);
                                        j = (j + rest_days);
                                        //mdate = mdate.AddDays(rest_days * Convert.ToInt16(MONTH_WEEKSEQUENCE_MONTH_NO));
                                        //j = (j + rest_days) * Convert.ToInt16(MONTH_WEEKSEQUENCE_MONTH_NO);
                                    }
                                    else
                                    {
                                        j = j + 1;
                                        mdate = mdate.AddDays(1);
                                    }
                                }
                                else
                                {
                                    var dayyy1 = new DateTime(mdate.Year, Convert.ToInt16(YEARLY_DAYS_OF_MONTH), Convert.ToInt16(YEARLY_DAYS_NO));
                                    int nweday = mdate.Day;
                                    int mnth = mdate.Month;
                                    if (Convert.ToInt16(YEARLY_DAYS_OF_MONTH) == mnth && Convert.ToInt16(YEARLY_DAYS_NO) == nweday)
                                    {
                                        InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, Convert.ToDateTime(mdate).AddDays(j).ToString(), SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);

                                        //cmd.Parameters.Clear();
                                        //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                                        //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                                        //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                                        //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                                        //cmd.Parameters.AddWithValue("@DUE_DATE", Convert.ToDateTime(mdate));
                                        //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                                        //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                                        //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                                        //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                                        //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                                        //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                                        //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                                        //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                                        //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                                        ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                                        //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);
                                        //cmd.CommandType = CommandType.StoredProcedure;
                                        //cmd.ExecuteNonQuery();

                                        mdate = mdate.AddMonths(1);
                                        int dayss = DateTime.DaysInMonth(mdate.Year, mdate.Month);
                                        j = j + dayss;
                                    }
                                    else
                                    {
                                        mdate = mdate.AddDays(1);
                                        j++;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else// for no repeat
                    {
                        InsertTask(cmd, TASK_ID, ASSIGN_TO, emp_id, START_DATE, DUE_DATE, SUBJECT, STATUS, PRIORITY, IS_REPEAT, REPEAT_TYPE,
                                REPEAT_FOR_EVERYDAY, REPEAT_FOR_EVERYWEEK, IS_ON_DAYWISE, MONTH_DAYS_NO, MONTH_DAY_NO, MONTH_WEEK_SEQUENCE_TYPE,
                                MONTH_WEEKSEQUENCE_DAY, MONTH_WEEKSEQUENCE_MONTH_NO, DESCRIPTION, IS_EVERY_DAY, REPEAT_WEEK_ON, REMINDER_DAY_BEFORE
                                , CLIENT_GROUP, NATURE_OF_WORK, FINANCIAL_YEAR, ASSESSMENT_YEAR, CONTACT_PERSON, CONTACT_NUMBER, CONTACT_EMAIL_ID, TARGETED_DAYS);


                        //cmd.Parameters.Clear();
                        //cmd.CommandText = "ADD_TASK_MASTER";
                        //cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                        //cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
                        //cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
                        //cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
                        //cmd.Parameters.AddWithValue("@DUE_DATE", DUE_DATE);
                        //cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
                        //cmd.Parameters.AddWithValue("@STATUS", STATUS);
                        //cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
                        //cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
                        //cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
                        //cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
                        //cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
                        //cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
                        //cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
                        //cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
                        //cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
                        //cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                        //cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
                        //cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
                        ////cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                        //cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);

                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.ExecuteNonQuery();
                    }
                    rd.MESSAGE = "Thanks for subscribing Newsletter !";
                    rd.ERROR_STATUS = false;
                    //D.ExecuteQuery("insert into TASK_MASTER_COPY(TASK_OWNER,ASSIGN_TO,SUBJECT,START_DATE,DUE_DATE,STATUS,PRIORITY,DESCRIPTION,IS_REPEAT,CREATED) values ('" + Email + "','1','" + DateTime.Now + "')");
                    rd.ORIGINAL_ERROR = "";
                    rd.RECORDS = false;
                    list.Add(rd);
                    Context.Response.Write(js.Serialize(list[0]));
                }
            }
            catch (Exception ex)
            {
                rd.MESSAGE = "Failed to Register for Newsletter ! ";
                rd.ERROR_STATUS = true;
                rd.ORIGINAL_ERROR = ex.Message;
                rd.RECORDS = false;
                list.Add(rd);
                Context.Response.Write(js.Serialize(list[0]));
            }
        }

        private void InsertTask(SqlCommand cmd, string TASK_ID, string ASSIGN_TO, string emp_id, string START_DATE, string DUE_DATE, string SUBJECT, string STATUS, string PRIORITY, string IS_REPEAT, string REPEAT_TYPE, string REPEAT_FOR_EVERYDAY, string REPEAT_FOR_EVERYWEEK, bool IS_ON_DAYWISE, string MONTH_DAYS_NO, string MONTH_DAY_NO, string MONTH_WEEK_SEQUENCE_TYPE, string MONTH_WEEKSEQUENCE_DAY, string MONTH_WEEKSEQUENCE_MONTH_NO, string DESCRIPTION, bool IS_EVERY_DAY, string REPEAT_WEEK_ON, string REMINDER_DAY_BEFORE, string CLIENT_GROUP, string NATURE_OF_WORK, string FINANCIAL_YEAR, string ASSESSMENT_YEAR, string CONTACT_PERSON, string CONTACT_NUMBER, string CONTACT_EMAIL_ID, string TARGETED_DAYS)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "ADD_TASK_MASTER";
            cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
            cmd.Parameters.AddWithValue("@ASSIGN_TO", ASSIGN_TO);
            cmd.Parameters.AddWithValue("@TASK_OWNER", emp_id);
            cmd.Parameters.AddWithValue("@START_DATE", START_DATE);
            cmd.Parameters.AddWithValue("@DUE_DATE", DUE_DATE);
            cmd.Parameters.AddWithValue("@SUBJECT", SUBJECT);
            cmd.Parameters.AddWithValue("@STATUS", STATUS);
            cmd.Parameters.AddWithValue("@PRIORITY", PRIORITY);
            cmd.Parameters.AddWithValue("@IS_REPEAT", IS_REPEAT);
            cmd.Parameters.AddWithValue("@REPEAT_TYPE", REPEAT_TYPE);
            cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYDAY", REPEAT_FOR_EVERYDAY);
            cmd.Parameters.AddWithValue("@REPEAT_FOR_EVERYWEEK", REPEAT_FOR_EVERYWEEK);
            cmd.Parameters.AddWithValue("@IS_ON_DAYWISE", IS_ON_DAYWISE);
            cmd.Parameters.AddWithValue("@MONTH_DAYS_NO", MONTH_DAYS_NO);
            cmd.Parameters.AddWithValue("@MONTH_DAY_NO", MONTH_DAY_NO);
            cmd.Parameters.AddWithValue("@MONTH_WEEK_SEQUENCE_TYPE", MONTH_WEEK_SEQUENCE_TYPE);
            cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_DAY", MONTH_WEEKSEQUENCE_DAY);
            cmd.Parameters.AddWithValue("@MONTH_WEEKSEQUENCE_MONTH_NO", MONTH_WEEKSEQUENCE_MONTH_NO);
            cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
            cmd.Parameters.AddWithValue("@IS_EVERY_DAY", IS_EVERY_DAY);
            cmd.Parameters.AddWithValue("@REPEAT_WEEK_ON", REPEAT_WEEK_ON);
            //cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
            cmd.Parameters.AddWithValue("@REMINDER_DAY_BEFORE", REMINDER_DAY_BEFORE);

            cmd.Parameters.AddWithValue("@CLIENT_GROUP", CLIENT_GROUP);
            cmd.Parameters.AddWithValue("@NATURE_OF_WORK", NATURE_OF_WORK);
            cmd.Parameters.AddWithValue("@FINANCIAL_YEAR", FINANCIAL_YEAR);
            cmd.Parameters.AddWithValue("@ASSESSMENT_YEAR", ASSESSMENT_YEAR);
            cmd.Parameters.AddWithValue("@CONTACT_PERSON", CONTACT_PERSON);
            cmd.Parameters.AddWithValue("@CONTACT_NUMBER", CONTACT_NUMBER);
            cmd.Parameters.AddWithValue("@CONTACT_EMAIL_ID", CONTACT_EMAIL_ID);
            cmd.Parameters.AddWithValue("@TARGETED_DAYS", TARGETED_DAYS);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();

        }

        private bool NthDayOfMonth(DateTime date, DayOfWeek dow, int n)
        {
            int d = date.Day;
            return date.DayOfWeek == dow && (d - 1) / 7 == (n - 1);
        }

        public string GetSequenceOnString(string sequence)
        {
            string number = "";
            if (sequence == "First")
            {
                number = "1";
            }
            if (sequence == "Second")
            {
                number = "2";
            }
            if (sequence == "Third")
            {
                number = "3";
            }
            if (sequence == "Fourth")
            {
                number = "4";
            }
            if (sequence == "Last")
            {
                number = "4";
            }
            return number;
        }

        [WebMethod]
        public void DeleteTask(string type, string TASK_ID)
        {
            List<MESSAGE_RSULT> list = new List<MESSAGE_RSULT>();
            MESSAGE_RSULT rd = new MESSAGE_RSULT();
            string emp_id = "0";

            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                

                if (type == "delete_task")
                {
                    rd.MESSAGE = "Deleted successfully  !";
                    rd.ERROR_STATUS = false;
                    D.ExecuteQuery("delete from TASK_MASTER where ID=" + TASK_ID);
                    rd.ORIGINAL_ERROR = "";
                    rd.RECORDS = false;
                    list.Add(rd);
                    Context.Response.Write(js.Serialize(list[0]));
                }
            }
            catch (Exception ex)
            {
                rd.MESSAGE = "failed to delete ! ";
                rd.ERROR_STATUS = true;
                rd.ORIGINAL_ERROR = ex.Message;
                rd.RECORDS = false;
                list.Add(rd);
                Context.Response.Write(js.Serialize(list[0]));
            }
        }

        [WebMethod]
        public void DeleteSeletedTask(string type, string DELETE_TASK_IDS)
        {
            List<MESSAGE_RSULT> list = new List<MESSAGE_RSULT>();
            MESSAGE_RSULT rd = new MESSAGE_RSULT();
            string emp_id = "0";

            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                

                if (type == "delete_task")
                {
                    if (DELETE_TASK_IDS.ToString().EndsWith(","))
                        DELETE_TASK_IDS = DELETE_TASK_IDS.Remove(DELETE_TASK_IDS.Length - 1, 1);

                    rd.MESSAGE = "Deleted successfully  !";
                    rd.ERROR_STATUS = false;
                    D.ExecuteQuery("delete from TASK_MASTER where ID in (" + DELETE_TASK_IDS + ")");
                    rd.ORIGINAL_ERROR = "";
                    rd.RECORDS = false;
                    list.Add(rd);
                    Context.Response.Write(js.Serialize(list[0]));
                }
            }
            catch (Exception ex)
            {
                rd.MESSAGE = "failed to delete ! ";
                rd.ERROR_STATUS = true;
                rd.ORIGINAL_ERROR = ex.Message;
                rd.RECORDS = false;
                list.Add(rd);
                Context.Response.Write(js.Serialize(list[0]));
            }
        }

        [WebMethod]
        public void UpdateTask(string type, string NOTES, string DESCRIPTION, string STATUS, string TASK_ID, string SUBJECT, string TASK_OWNER_ID, string ACTUAL_WORK_FINISH_DATE, string ACTUAL_DAYS_TAKEN)
        {

            List<MESSAGE_RSULT> list = new List<MESSAGE_RSULT>();
            MESSAGE_RSULT rd = new MESSAGE_RSULT();
            string emp_id = "0";
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                string IS_CLOSED = "0";
                if (type == "close_task")
                {
                    string emp_name = HttpContext.Current.Request.Cookies["ADMIN_NAME"].Value;
                    emp_id = HttpContext.Current.Request.Cookies["ADMIN_ID"].Value;
                    rd.ERROR_STATUS = false;
                    DateTime? closed_date = null;

                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE_TASK";
                    cnn.Open();
                    cmd.Connection = cnn;
                    if (STATUS == "Completed")
                    {
                        IS_CLOSED = "1";
                        closed_date = DateTime.Now;
                        cmd.Parameters.AddWithValue("@CLOSED_DATE", closed_date);
                        cmd.Parameters.AddWithValue("@ACTUAL_DAYS_TAKEN", ACTUAL_DAYS_TAKEN);
                        cmd.Parameters.AddWithValue("@ACTUAL_WORK_FINISH_DATE", ACTUAL_WORK_FINISH_DATE);
                    }
                    else
                    {
                        IS_CLOSED = "0";
                    }
                    
                    cmd.Parameters.AddWithValue("@NOTES", NOTES);
                    cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                    cmd.Parameters.AddWithValue("@STATUS", STATUS);
                    cmd.Parameters.AddWithValue("@TASK_OWNER_ID", TASK_OWNER_ID);
                    cmd.Parameters.AddWithValue("@TASK_ID", TASK_ID);
                    //cmd.Parameters.AddWithValue("@WORK_FROM_HOME", WORK_FROM_HOME);
                    cmd.Parameters.AddWithValue("@IS_CLOSED", IS_CLOSED);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    if (STATUS == "Completed")
                    {
                        IS_CLOSED = "1";
                        //D.ExecuteQuery("update TASK_MASTER set WORK_FROM_HOME='" + WORK_FROM_HOME + "', IS_CLOSED='" + IS_CLOSED + "',DESCRIPTION='" + DESCRIPTION + "',STATUS='" + STATUS + "', CLOSED_DATE='" + DateTime.Now + "',NOTES='" + NOTES + "' where ID=" + TASK_ID);
                        rd.MESSAGE = "Task closed successfully  !";
                        D.ExecuteQuery("insert into NOTIFICATION_MASTER (MODULE_TYPE,NOTIFICATION_MESSAGE,EMPLOYEE_ID,CREATED,TASK_OWNER_ID) values('TASK','" + emp_name + " has closed the " + SUBJECT + " on " + DateTime.Now + "'," + emp_id + ",'" + DateTime.Now + "'," + TASK_OWNER_ID + ")");
                    }
                    else
                    {
                        //D.ExecuteQuery("update TASK_MASTER set WORK_FROM_HOME='" + WORK_FROM_HOME + "', IS_CLOSED='" + IS_CLOSED + "',DESCRIPTION='" + DESCRIPTION + "',STATUS='" + STATUS + "', UPDATED='" + DateTime.Now + "',NOTES='" + NOTES + "' where ID=" + TASK_ID);
                        rd.MESSAGE = "Task updated successfully  !";
                        D.ExecuteQuery("insert into NOTIFICATION_MASTER (MODULE_TYPE,NOTIFICATION_MESSAGE,EMPLOYEE_ID,CREATED,TASK_OWNER_ID) values('TASK','" + emp_name + " has updated the status of " + SUBJECT + " to " + STATUS + " on " + DateTime.Now + "'," + emp_id + ",'" + DateTime.Now + "'," + TASK_OWNER_ID + ")");
                    }
                    rd.ORIGINAL_ERROR = "";
                    rd.RECORDS = false;
                    list.Add(rd);
                    Context.Response.Write(js.Serialize(list[0]));
                }
            }
            catch (Exception ex)
            {
                rd.MESSAGE = "failed to closed ! ";
                rd.ERROR_STATUS = true;
                rd.ORIGINAL_ERROR = ex.Message;
                rd.RECORDS = false;
                list.Add(rd);
                Context.Response.Write(js.Serialize(list[0]));
            }
        }

        [WebMethod]
        public void GetMyTask(string type, string DropdownValue, string FROM_DATE, string TO_DATE)
        {
            List<ROOT_TASKDATA> root_list = new List<ROOT_TASKDATA>();
            List<AddTask> list = new List<AddTask>();
            ROOT_TASKDATA root_data = new ROOT_TASKDATA();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                string where = "";

                //where = " and (CONVERT(date,DUE_DATE)=convert(date,getdate()) or convert(date,due_date)<convert(date,getdate())) and IS_CLOSED='0'";            
                if (DropdownValue == "todays+overdue")
                {
                    where = " and (CONVERT(date,DUE_DATE)=convert(date,getdate()) or convert(date,due_date)<convert(date,getdate())) and IS_CLOSED='0'";
                }
                else if (DropdownValue == "myopentask")
                {
                    where = " and IS_CLOSED='0'";
                }
                else if (DropdownValue == "next7daystask")
                {
                    //where = " and convert(date,due_date)<=convert(date,DATEADD(DAY, 7, getdate())) and IS_CLOSED!='1'";
                    where = " and (convert(date,due_date)>=convert(date,getdate()) and convert(date,due_date)<=convert(date,DATEADD(DAY, 7, getdate()))) and IS_CLOSED!='1' ";
                }
                else if (DropdownValue == "overduetask")
                {
                    where = " and convert(date,due_date)<convert(date,getdate()) and IS_CLOSED='0'";
                }
                else if (DropdownValue == "filterbydate")
                {
                    where = " and convert(date,DUE_DATE) between '" + FROM_DATE + "' and '" + TO_DATE + "'";
                }
                else if (DropdownValue == "closetask")
                {
                    where = " and IS_CLOSED='1'";
                }
                else if (DropdownValue == "todaystask")
                {
                    where = " and convert(date,DUE_DATE)=convert(date,getdate())";
                }
                else if (DropdownValue == "In Progress" || DropdownValue == "Not Started")
                {
                    where = " and tm.STATUS='" + DropdownValue + "'";
                }
                else if (DropdownValue == "yesterdaycomletetask")
                {
                    where = " and CLOSED_DATE=convert(date,DATEADD(DAY, -1, getdate()))";
                }
                else if (DropdownValue == "Workfromhome")
                {
                    where = " and WORK_FROM_HOME=1";
                }

                else if (DropdownValue == "alltask")
                {
                    where = "";
                }
                if (type == "get_mytask")
                {
                    string emp_id = HttpContext.Current.Request.Cookies["admin_id"].Value;

                    string qry = "select convert(VARCHAR,tm.due_date,106) as DUEDATE,em.first_name+' '+em.last_name as TASK_OWNER_NAME,em.POST_ID,tm.* from TASK_MASTER as tm,employee_master as em  where em.ID=tm.TASK_OWNER and tm.ASSIGN_TO=" + emp_id + where + " order by tm.DUE_DATE asc";
                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            AddTask data = new AddTask();
                            if (row["WORK_FROM_HOME"].ToString() != "")
                            {
                                data.WORK_FROM_HOME = Convert.ToBoolean(row["WORK_FROM_HOME"].ToString());
                            }
                            else
                            {
                                data.WORK_FROM_HOME = false;
                            }


                            data.TASK_OWNER_NAME = row["TASK_OWNER_NAME"].ToString();
                            data.TASK_OWNER_ID = row["TASK_OWNER"].ToString();

                            data.TASK_ID = row["TASK_ID"].ToString();
                            data.ID = row["ID"].ToString();
                            data.SUBJECT = row["SUBJECT"].ToString();
                            data.DESCRIPTION = row["DESCRIPTION"].ToString();
                            data.REPEAT_TYPE = row["REPEAT_TYPE"].ToString();
                            data.STATUS = row["STATUS"].ToString();
                            data.PRIORITY = row["PRIORITY"].ToString();
                            data.DUE_DATE = Convert.ToDateTime(row["DUE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            data.START_DATE = Convert.ToDateTime(row["START_DATE"].ToString()).ToString("dd-MM-yyyy");
                            data.STATUS = row["STATUS"].ToString();
                            data.CREATED = row["CREATED"].ToString();
                            if (row["CLOSED_DATE"].ToString() != "")
                                data.CLOSED_DATE = Convert.ToDateTime(row["CLOSED_DATE"].ToString()).ToString("dd-MM-yyyy");
                            else
                                data.CLOSED_DATE = "pending";

                            data.IS_CLOSED = row["IS_CLOSED"].ToString();
                            data.NOTES = row["NOTES"].ToString();

                            data.CLIENT_GROUP = row["CLIENT_GROUP"].ToString();
                            data.NATURE_OF_WORK = row["NATURE_OF_WORK"].ToString();
                            data.CONTACT_PERSON = row["CONTACT_PERSON"].ToString();
                            data.CONTACT_NUMBER = row["CONTACT_NUMBER"].ToString();
                            data.CONTACT_EMAIL_ID = row["CONTACT_EMAIL_ID"].ToString();
                            data.FINANCIAL_YEAR = row["FINANCIAL_YEAR"].ToString();
                            data.ASSESSMENT_YEAR = row["ASSESSMENT_YEAR"].ToString();
                            data.TARGETED_DAYS = row["TARGETED_DAYS"].ToString();
                            data.ACTUAL_DAYS_TAKEN = row["ACTUAL_DAYS_TAKEN"].ToString();
                            data.ACTUAL_WORK_FINISH_DATE = row["ACTUAL_WORK_FINISH_DATE"].ToString();
                            data.POST_ID = HttpContext.Current.Request.Cookies["POST_ID"] != null ? HttpContext.Current.Request.Cookies["POST_ID"].Value : "0";

                            list.Add(data);
                        }
                        root_data.MESSAGE = "Fetched successfully !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = true;
                        root_data.TASK_DATA = list;
                        root_list.Add(root_data);
                    }
                    else
                    {
                        root_data.MESSAGE = "no data found !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = false;
                        root_data.TASK_DATA = list;
                        root_list.Add(root_data);
                    }
                    Context.Response.Write(js.Serialize(root_list[0]));
                }
            }
            catch (Exception ex)
            {
                root_data.MESSAGE = "Failed To get ! ";
                root_data.ERROR_STATUS = true;
                root_data.ORIGINAL_ERROR = ex.Message;
                root_data.RECORDS = false;
                root_list.Add(root_data);
                Context.Response.Write(js.Serialize(root_list[0]));
            }
        }


        [WebMethod]
        public void FilterDropdownChange(string type, string DropdownValue, string FROM_DATE, string TO_DATE)
        {
            List<ROOT_TASKDATA> root_list = new List<ROOT_TASKDATA>();
            List<AddTask> list = new List<AddTask>();
            ROOT_TASKDATA root_data = new ROOT_TASKDATA();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                if (type == "get_mytask")
                {
                    string emp_id = HttpContext.Current.Request.Cookies["admin_id"].Value;
                    string where = "";
                    if (DropdownValue == "todays+overdue")
                    {
                        where = " and CONVERT(date,DUE_DATE)=convert(date,getdate()) and convert(date,due_date)<convert(date,getdate()) and IS_CLOSED!='1'";
                    }
                    else if (DropdownValue == "myopentask")
                    {
                        where = " and IS_CLOSED!='1'";
                    }
                    else if (DropdownValue == "next7daystask")
                    {
                        where = " and IS_CLOSED!='1'";
                    }
                    else if (DropdownValue == "overduetask")
                    {
                        where = " and convert(date,due_date)<convert(date,getdate()) and IS_CLOSED!='1'";
                    }
                    else if (DropdownValue == "filterbydate")
                    {
                        where = " and DUE_DATE between '" + FROM_DATE + "' and '" + TO_DATE + "'";
                    }
                    else if (DropdownValue == "alltask")
                    {
                        where = "";
                    }

                    string qry = "select convert(VARCHAR,tm.due_date,106) as DUEDATE,em.first_name+' '+em.last_name as TASK_OWNER_NAME,tm.* from TASK_MASTER as tm,employee_master as em  where em.ID=tm.TASK_OWNER and tm.ASSIGN_TO=" + emp_id + where + " order by tm.DUE_DATE asc";
                    DataTable dt = D.GetDataTable(qry);
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            AddTask data = new AddTask();
                            data.TASK_OWNER_NAME = row["TASK_OWNER_NAME"].ToString();
                            data.TASK_ID = row["TASK_ID"].ToString();
                            data.ID = row["ID"].ToString();
                            data.SUBJECT = row["SUBJECT"].ToString();
                            data.DESCRIPTION = row["DESCRIPTION"].ToString();
                            data.REPEAT_TYPE = row["REPEAT_TYPE"].ToString();
                            data.STATUS = row["STATUS"].ToString();
                            data.PRIORITY = row["PRIORITY"].ToString();
                            data.DUE_DATE = Convert.ToDateTime(row["DUE_DATE"].ToString()).ToString("yyyy-MM-dd");
                            data.STATUS = row["STATUS"].ToString();
                            data.CREATED = row["CREATED"].ToString();
                            data.CLOSED_DATE = row["CLOSED_DATE"].ToString();
                            data.IS_CLOSED = row["IS_CLOSED"].ToString();
                            data.NOTES = row["NOTES"].ToString();

                            list.Add(data);
                        }
                        root_data.MESSAGE = "Fetched successfully !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = true;
                        root_data.TASK_DATA = list;
                        root_list.Add(root_data);
                    }
                    else
                    {
                        root_data.MESSAGE = "no data found !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = false;
                        root_data.TASK_DATA = list;
                        root_list.Add(root_data);
                    }
                    Context.Response.Write(js.Serialize(root_list[0]));
                }
            }
            catch (Exception ex)
            {
                root_data.MESSAGE = "Failed To get ! ";
                root_data.ERROR_STATUS = true;
                root_data.ORIGINAL_ERROR = ex.Message;
                root_data.RECORDS = false;
                root_list.Add(root_data);
                Context.Response.Write(js.Serialize(root_list[0]));
            }
        }

        [WebMethod]
        public void GetAllTask(string type, string DropdownValue, string FROM_DATE, string TO_DATE)
        {
            List<ROOT_TASKDATA> root_list = new List<ROOT_TASKDATA>();
            List<AddTask> list = new List<AddTask>();
            ROOT_TASKDATA root_data = new ROOT_TASKDATA();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                string where = "";

                //where = " and (CONVERT(date,DUE_DATE)=convert(date,getdate()) or convert(date,due_date)<convert(date,getdate())) and IS_CLOSED='0'";            
                if (DropdownValue == "todays+overdue")
                {
                    where = " and (CONVERT(date,DUE_DATE)=convert(date,getdate()) or convert(date,due_date)<convert(date,getdate())) and IS_CLOSED='0'";
                }
                else if (DropdownValue == "myopentask")
                {
                    where = " and IS_CLOSED='0'";
                }
                else if (DropdownValue == "next7daystask")
                {
                    //where = " and convert(date,due_date)<=convert(date,DATEADD(DAY, 7, getdate())) and IS_CLOSED!='1'";
                    where = " and (convert(date,due_date)>=convert(date,getdate()) and convert(date,due_date)<=convert(date,DATEADD(DAY, 7, getdate()))) and IS_CLOSED!='1' ";
                }
                else if (DropdownValue == "overduetask")
                {
                    where = " and convert(date,due_date)<convert(date,getdate()) and IS_CLOSED='0'";
                }
                else if (DropdownValue == "filterbydate")
                {
                    where = " and convert(date,DUE_DATE) between '" + FROM_DATE + "' and '" + TO_DATE + "'";
                }
                else if (DropdownValue == "closetask")
                {
                    where = " and IS_CLOSED='1'";
                }
                else if (DropdownValue == "todaystask")
                {
                    where = " and convert(date,DUE_DATE)=convert(date,getdate())";
                }
                else if (DropdownValue == "In Progress" || DropdownValue == "Not Started")
                {
                    where = " and tm.STATUS='" + DropdownValue + "'";
                }
                else if (DropdownValue == "yesterdaycomletetask")
                {
                    where = " and CLOSED_DATE=convert(date,DATEADD(DAY, -1, getdate()))";
                }
                else if (DropdownValue == "Workfromhome")
                {
                    where = " and WORK_FROM_HOME=1";
                }
                else if (DropdownValue == "alltask")
                {
                    where = "";
                }

                if (type == "get_alltask")
                {

                    string emp_id = HttpContext.Current.Request.Cookies["admin_id"].Value;

                    //get the task by owner (means only display that task whose owner is logined user)
                    //DataTable dt = D.GetDataTable("select convert(VARCHAR,tm.due_date,106) as DUEDATE,convert(VARCHAR,tm.due_date,105), em1.first_name+' '+em1.last_name as TASK_OWNER_NAME, tm.*,em.first_name+' '+em.last_name as ASSIGNED_EMPLOYEE_NAME from " +
                    //                                "TASK_MASTER as tm ,employee_master as em , employee_master as em1 where " +
                    //                                "em1.ID=tm.TASK_OWNER and em.ID=tm.ASSIGN_TO and tm.TASK_OWNER!=tm.ASSIGN_TO and tm.TASK_OWNER=" + emp_id + where + " order by tm.DUE_DATE asc");

                    //get the all task
                    DataTable dt = D.GetDataTable("select convert(VARCHAR,tm.due_date,106) as DUEDATE,convert(VARCHAR,tm.due_date,105), '' as TASK_OWNER_NAME, tm.*,em.first_name+' '+em.last_name as ASSIGNED_EMPLOYEE_NAME from " +
                                                    "  as tm ,employee_master as em where " +
                                                    "em.ID=tm.ASSIGN_TO and tm.TASK_OWNER!=tm.ASSIGN_TO " + where + " order by tm.DUE_DATE asc");

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            AddTask data = new AddTask();
                            data.ASSIGNED_EMPLOYEE_NAME = row["ASSIGNED_EMPLOYEE_NAME"].ToString();
                            data.TASK_OWNER_NAME = row["TASK_OWNER_NAME"].ToString();
                            data.TASK_ID = row["TASK_ID"].ToString();
                            data.ID = row["ID"].ToString();
                            data.SUBJECT = row["SUBJECT"].ToString();
                            data.DESCRIPTION = row["DESCRIPTION"].ToString();
                            data.REPEAT_TYPE = row["REPEAT_TYPE"].ToString();
                            data.STATUS = row["STATUS"].ToString();
                            data.PRIORITY = row["PRIORITY"].ToString();
                            data.DUE_DATE = Convert.ToDateTime(row["DUE_DATE"].ToString()).ToString("dd-MM-yyyy");
                            data.STATUS = row["STATUS"].ToString();
                            data.CREATED = row["CREATED"].ToString();
                            data.START_DATE = Convert.ToDateTime(row["START_DATE"].ToString()).ToString("dd-MM-yyyy");
                            data.CLOSED_DATE = row["CLOSED_DATE"].ToString();
                            data.IS_CLOSED = row["IS_CLOSED"].ToString();
                            data.NOTES = row["NOTES"].ToString();

                            data.CLIENT_GROUP = row["CLIENT_GROUP"].ToString();
                            data.NATURE_OF_WORK = row["NATURE_OF_WORK"].ToString();
                            data.CONTACT_PERSON = row["CONTACT_PERSON"].ToString();
                            data.CONTACT_NUMBER = row["CONTACT_NUMBER"].ToString();
                            data.CONTACT_EMAIL_ID = row["CONTACT_EMAIL_ID"].ToString();
                            data.FINANCIAL_YEAR = row["FINANCIAL_YEAR"].ToString();
                            data.ASSESSMENT_YEAR = row["ASSESSMENT_YEAR"].ToString();
                            data.TARGETED_DAYS = row["TARGETED_DAYS"].ToString();
                            data.ACTUAL_DAYS_TAKEN = row["ACTUAL_DAYS_TAKEN"].ToString();
                            data.ACTUAL_WORK_FINISH_DATE = row["ACTUAL_WORK_FINISH_DATE"].ToString();
                            
                            if (row["CLOSED_DATE"].ToString() != "")
                                data.CLOSED_DATE = Convert.ToDateTime(row["CLOSED_DATE"].ToString()).ToString("yyyy-MM-dd");
                            else
                                data.CLOSED_DATE = "pending";

                            list.Add(data);
                        }
                        root_data.MESSAGE = "Fetched successfully !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = true;
                        root_data.TASK_DATA = list;
                        root_list.Add(root_data);
                    }
                    else
                    {
                        root_data.MESSAGE = "no data found !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = false;
                        root_data.TASK_DATA = list;
                        root_list.Add(root_data);
                    }
                    Context.Response.Write(js.Serialize(root_list[0]));
                }
            }
            catch (Exception ex)
            {
                root_data.MESSAGE = "Failed To get ! ";
                root_data.ERROR_STATUS = true;
                root_data.ORIGINAL_ERROR = ex.Message;
                root_data.RECORDS = false;
                root_list.Add(root_data);
                Context.Response.Write(js.Serialize(root_list[0]));
            }
        }


        [WebMethod]
        public void GetDashboardNotification(string type)
        {
            List<ROOT_NOTIFICATION_MASTER> root_list = new List<ROOT_NOTIFICATION_MASTER>();
            List<NOTIFICATION_MASTER> list = new List<NOTIFICATION_MASTER>();
            ROOT_NOTIFICATION_MASTER root_data = new ROOT_NOTIFICATION_MASTER();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                if (type == "get_notification")
                {
                    string emp_id = HttpContext.Current.Request.Cookies["admin_id"].Value;

                    DataTable dt = D.GetDataTable("select em1.first_name+' '+em1.last_name as TASK_OWNER_NAME,nm.* from NOTIFICATION_MASTER as nm,EMPLOYEE_TEAM_ALOCATION as etm,employee_master as em1 where em1.ID=etm.EMPLOYEE_ID and etm.TEAM_ID=nm.EMPLOYEE_ID and etm.EMPLOYEE_ID=" + emp_id + " order by nm.ID desc");
                    DataTable dt1 = D.GetDataTable("select em1.first_name+' '+em1.last_name as TASK_OWNER_NAME,nm.* from NOTIFICATION_MASTER as nm,employee_master as em1 where em1.ID=nm.TASK_OWNER_ID and nm.TASK_OWNER_ID=" + emp_id + " and nm.EMPLOYEE_ID!=" + emp_id + " order by nm.ID desc");
                    dt.Merge(dt1);
                    dt.AcceptChanges();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            NOTIFICATION_MASTER data = new NOTIFICATION_MASTER();
                            data.NOTIFICATION_MESSAGE = row["NOTIFICATION_MESSAGE"].ToString();
                            data.EMPLOYEE_ID = row["EMPLOYEE_ID"].ToString();
                            data.ID = row["ID"].ToString();
                            data.MODULE_TYPE = row["MODULE_TYPE"].ToString();
                            data.CREATED = row["CREATED"].ToString();
                            data.TASK_OWNER_NAME = row["TASK_OWNER_NAME"].ToString();
                            list.Add(data);
                        }
                        root_data.MESSAGE = "Fetched successfully !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = true;
                        root_data.NOTIFICATION_DATA = list;
                        root_list.Add(root_data);
                    }
                    else
                    {
                        root_data.MESSAGE = "no data found !";
                        root_data.ERROR_STATUS = false;
                        root_data.ORIGINAL_ERROR = "";
                        root_data.RECORDS = false;
                        root_data.NOTIFICATION_DATA = list;
                        root_list.Add(root_data);
                    }
                    Context.Response.Write(js.Serialize(root_list[0]));
                }
            }
            catch (Exception ex)
            {
                root_data.MESSAGE = "Failed To get notification ! ";
                root_data.ERROR_STATUS = true;
                root_data.ORIGINAL_ERROR = ex.Message;
                root_data.RECORDS = false;
                root_list.Add(root_data);
                Context.Response.Write(js.Serialize(root_list[0]));
            }
        }

        [WebMethod]
        public void RemoveNotification(string type, string NOTIFICATION_ID)
        {
            List<MESSAGE_RSULT> list = new List<MESSAGE_RSULT>();
            MESSAGE_RSULT rd = new MESSAGE_RSULT();

            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                
                int i = 0;

                if (type == "delete_notification")
                {

                    D.ExecuteQuery("delete from NOTIFICATION_MASTER  where ID=" + NOTIFICATION_ID);
                    rd.MESSAGE = "Notification Deleted ! ";
                    rd.ERROR_STATUS = false;
                    rd.ORIGINAL_ERROR = "";
                    rd.RECORDS = false;
                    list.Add(rd);
                    Context.Response.Write(js.Serialize(list[0]));
                }
            }
            catch (Exception ex)
            {
                rd.MESSAGE = "Failed to delete notification  ! ";
                rd.ERROR_STATUS = true;
                rd.ORIGINAL_ERROR = ex.Message;
                rd.RECORDS = false;
                list.Add(rd);
                Context.Response.Write(js.Serialize(list[0]));
            }
        }


        [WebMethod]
        public void RemoveAllNotification(string type)
        {
            List<MESSAGE_RSULT> list = new List<MESSAGE_RSULT>();
            MESSAGE_RSULT rd = new MESSAGE_RSULT();

            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                string emp_id = HttpContext.Current.Request.Cookies["admin_id"].Value;
                if (type == "delete_all")
                {
                    D.ExecuteQuery("delete from NOTIFICATION_MASTER where ID in ( select nm.Id from NOTIFICATION_MASTER as nm,EMPLOYEE_TEAM_ALOCATION as etm,employee_master as em1 where em1.ID=etm.EMPLOYEE_ID and etm.TEAM_ID=nm.EMPLOYEE_ID and etm.EMPLOYEE_ID=" + emp_id + ")");
                    D.ExecuteQuery("delete from NOTIFICATION_MASTER where ID in (select nm.ID from NOTIFICATION_MASTER as nm,employee_master as em1 where em1.ID=nm.TASK_OWNER_ID and nm.TASK_OWNER_ID=" + emp_id + ")");

                    rd.MESSAGE = "Notification Deleted ! ";
                    rd.ERROR_STATUS = false;
                    rd.ORIGINAL_ERROR = "";
                    rd.RECORDS = false;
                    list.Add(rd);
                    Context.Response.Write(js.Serialize(list[0]));
                }
            }
            catch (Exception ex)
            {
                rd.MESSAGE = "Failed to delete notification  ! ";
                rd.ERROR_STATUS = true;
                rd.ORIGINAL_ERROR = ex.Message;
                rd.RECORDS = false;
                list.Add(rd);
                Context.Response.Write(js.Serialize(list[0]));
            }
        }








        //
        [WebMethod]
        public void AdminLogin(string type, string username, string password)
        {
            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                int i = 0;
                List<AdminMaster> list = new List<AdminMaster>();
                if (type == "adminlogin")
                {
                    DataTable dt = cc.GetData("Select * from ADMIN_MASTER where USERNAME='" + username + "' and PASSWORD='" + password + "'");
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        AdminMaster rd = new AdminMaster();
                        rd.ID = dt.Rows[i]["ID"].ToString();
                        rd.NAME = dt.Rows[i]["NAME"].ToString();
                        rd.EMAIL = dt.Rows[i]["EMAIL"].ToString();
                        rd.USERNAME = dt.Rows[i]["USERNAME"].ToString();
                        list.Add(rd);
                    }
                    Context.Response.Write(js.Serialize(list));
                    return;
                }
                else
                {
                    Context.Response.Write("Wrong Username and Password ! ");
                    return;
                }
            }
            catch
            {
                Context.Response.Write("Failed To Get Data !");
                return;
            }
        }

        [WebMethod]
        public void GetCustomer(string type)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            int i = 0;
            List<Customer> list = new List<Customer>();
            if (type == "Customer")
            {
                DataTable dt = cc.GetData("Select * from CUSTOMER where DELETED = '0'");

                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    Customer rd = new Customer();


                    rd.NAME = dt.Rows[i]["NAME"].ToString();
                    rd.MOBILE = dt.Rows[i]["MOBILE"].ToString();
                    rd.EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    rd.IS_VENDER = dt.Rows[i]["IS_VENDER"].ToString();
                    rd.ID = dt.Rows[i]["ID"].ToString();


                    rd.GUID = dt.Rows[i]["GUID"].ToString();
                    rd.USER_NAME = dt.Rows[i]["USER_NAME"].ToString();
                    rd.PASSWORD = dt.Rows[i]["PASSWORD"].ToString();
                    rd.VENDOR_ID = dt.Rows[i]["VENDOR_ID"].ToString();
                    rd.HAS_SHOPPING_CART_ITEMS = dt.Rows[i]["HAS_SHOPPING_CART_ITEMS"].ToString();
                    rd.STATUS = dt.Rows[i]["STATUS"].ToString();
                    rd.LAST_IP_ADDRESS = dt.Rows[i]["LAST_IP_ADDRESS"].ToString();
                    rd.CREATED_DATE = dt.Rows[i]["CREATED_DATE"].ToString();
                    rd.LAST_LOGIN_DATE = dt.Rows[i]["LAST_LOGIN_DATE"].ToString();
                    rd.BILLING_ADDRESS = dt.Rows[i]["BILLING_ADDRESS"].ToString();
                    rd.SHIPPING_ADDRESS = dt.Rows[i]["SHIPPING_ADDRESS"].ToString();

                    //rd.img = "http://vaishnavvanikmatrimony.com/backend/img/" + dt.Rows[i]["img"].ToString();
                    list.Add(rd);


                    //ThoughtMaster obj = new ThoughtMaster();
                    //obj.Id = dt.Rows[i]["ID"].ToString();
                    //obj.Message = dt.Rows[i]["Message"].ToString();
                    //list.Add(obj);
                }
                Context.Response.Write(js.Serialize(list));

            }
        }


        [WebMethod]
        public void DeleteCustomer(string id)
        {
            try
            {
                D.ExecuteQuery("update CUSTOMER set  DELETED=1 where ID=" + id);
                Context.Response.Write("CUSTOMER Deleted Successfully !");
                return;
            }
            catch
            {
                Context.Response.Write("Failed To Delete !");
                return;
            }
        }

        //cache memory  
        public class MemoryCacher
        {
            public object GetValue(string key)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                return memoryCache.Get(key);
            }

            public bool Add(string key, object value, DateTimeOffset absExpiration)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                return memoryCache.Add(key, value, absExpiration);
            }

            public void Delete(string key)
            {
                MemoryCache memoryCache = MemoryCache.Default;
                if (memoryCache.Contains(key))
                {
                    memoryCache.Remove(key);
                }
            }
        }
    }
}
