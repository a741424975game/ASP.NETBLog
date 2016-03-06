using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class addDaily : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"]==null)
        {
            Response.Redirect("login.aspx");
        }

    }
    protected void addDailyBt_Click(object sender, EventArgs e)
    {
        DailyBLL dailyBLL = new DailyBLL();
        string dailyTitle = Request.Form["dailyTitle"];
        string dailyContent = Request.Form["editor"];
        DateTime dateTime = DateTime.Now;
        if (dailyTitle!="")
        {
             if (dailyBLL.Add_Daily(Session["userName"].ToString(), dailyTitle, dailyContent, dateTime) == true)
            {
                //Message.Alert("添加成功", "addDaily.aspx");
                dailyTitle = "";
                dailyContent = "";
                if (Session["pageSize"]!=null)
                {
                    Session["totalDailyPage"] = new DailyBLL().Count_Daily_Page(Session["userName"].ToString(), int.Parse(Session["pageSize"].ToString()));
                }

                Response.Redirect("addDaily.aspx");
            }
            else
            {
                //Message.Alert("添加失败", "addDaily.aspx");
            }
        }
        else
	    {
            //Message.Alert("请输入标题和内容", "addDaily.aspx");
	    }
        
      
           
    }


}