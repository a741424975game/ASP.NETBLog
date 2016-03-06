<%@ WebHandler Language="C#" Class="LoadDaily" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;//Session接口

public class LoadDaily : IHttpHandler,IReadOnlySessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
            if (context.Session["userName"]==null)
	    {
		        context.Response.Write(null);
	    }else
	    {
            if (context.Request.Form["pageNum"] != null && context.Session["pageSize"]!=null)
            {
                
                int pageSize = int.Parse(context.Session["pageSize"].ToString());
                int pageNum = int.Parse(context.Request.Form["pageNum"]);//string转int
                if (pageNum>0)
                {
                    var list = new List<DailyList_Title_Daily_Date>();
                    list = new DailyBLL().Daily(context.Session["userName"].ToString(), pageSize, pageNum);
                    var json = JsonHelper.GetJson(list);
                    context.Response.Write(json);
                }
                else
                {
                    context.Response.Write(null);
                }
            }
            else
            {
                context.Response.Write(null);
            }    
	    }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}