using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager.tm_admin
{
    public partial class MyTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["POST_ID"] != null)
            {
                if(Request.Cookies["POST_ID"].Value == "1")
                {
                    thChkBox.Visible = true;
                }
            }
        }
    }
}