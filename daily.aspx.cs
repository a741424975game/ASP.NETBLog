using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class daily : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void deleteDaily_Click(object sender, EventArgs e)
    {
        int dailyId;
        if (int.TryParse(Request.QueryString["dailyId"],out dailyId))
        {
            if (Session["userName"]!=null)
            {
                if (new DailyBLL().Comfirm_DeleteDaily(dailyId,Session["userName"].ToString()))
                {
                    if (Session["pageSize"] != null)
                    {
                        Session["totalDailyPage"] = new DailyBLL().Count_Daily_Page(Session["userName"].ToString(), int.Parse(Session["pageSize"].ToString()));
                    }
                    Message.Alert("删除成功","homePage.aspx");
                }
                else
                {
                    Message.Alert("删除失败");
                }
            }
            else
            {
                Message.Alert("删除失败");
            }
        }
        else
        {
            Message.Alert("删除失败");
        }
    }
    protected void editDailyBt_Click(object sender, EventArgs e)
    {
        int dailyId;
        if (int.TryParse(Request.QueryString["dailyId"], out dailyId))
        {
            if (Request.Form["dailyTitle"]!="")
            {
                string title = Request.Form["dailyTitle"];
                string content = Request.Form["editor"];
                if (Session["userName"]!=null)
                {
                    if (new DailyBLL().Comfirm_EditDaily(dailyId,title,content,Session["userName"].ToString()))
                    {
                        Message.Alert("提交成功");
                    }
                    else
                    {
                        Message.Alert("提交失败");
                    }
                }
                else
                {
                    Message.Alert("提交失败");
                }
            }
            else
            {
                Message.Alert("提交失败");
            }
        }
        else
        {
            Message.Alert("提交失败");
        }
    }
}