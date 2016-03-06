using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class homePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"]==null)
        {
            Response.Redirect("blogIntroduce.aspx");
        }
        else
        {
            if (Session["myDailyPageNum"]==null)
            {
                Session["myDailyPageNum"]=1;
            }
        }
    }
}