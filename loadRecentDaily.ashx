<%@ WebHandler Language="C#" Class="LoadRecentDaily" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;//Session接口


public class LoadRecentDaily : IHttpHandler, IReadOnlySessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Session["userName"]==null)
        {
            context.Response.Write(null);
        }
        else
        {
            int amount = 7;//返回的最近日常的数量
            var list = new List<RecentDailyList_Daily_Date>();
            list = new DailyBLL().Recent_Daily(context.Session["userName"].ToString(), amount);
            var json = JsonHelper.GetJson(list);
            context.Response.Write(json);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}