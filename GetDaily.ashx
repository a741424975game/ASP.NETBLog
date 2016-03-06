<%@ WebHandler Language="C#" Class="GetDaily" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;//Session接口

public class GetDaily : IHttpHandler ,IReadOnlySessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.Form["action"] == "getUserName")
        {
            if (context.Session["userName"]!=null)
            {
                context.Response.Write(context.Session["userName"].ToString());
            }
            else
            {
                context.Response.Write("");
            }
        }
        if (context.Request.Form["action"]=="getDailyById")
        {
             if (context.Request.Form["dailyId"]!=null)
        {
            int dailyId;
            if (int.TryParse(context.Request.Form["dailyId"], out dailyId))
            {
                var daily = new List<DailyList>();
                if (new DailyBLL().Get_DailyById_toList(dailyId) != null)
                {
                    daily = new DailyBLL().Get_DailyById_toList(dailyId);
                    var json = JsonHelper.GetJson(daily);
                    context.Response.Write(json);
            }
            }
        }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}