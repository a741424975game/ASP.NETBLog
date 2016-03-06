<%@ WebHandler Language="C#" Class="CountDailyPageNum" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;//Session接口

public class CountDailyPageNum : IHttpHandler, IRequiresSessionState

{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
                    if (context.Session["totalDailyPage"] == null)
            {
                if (context. Session["pageSize"]!=null)
                {
                   int pageSize = int.Parse(context.Session["pageSize"].ToString());
                if (context.Session["userName"]!=null)
                {
                    context.Session["totalDailyPage"] = new DailyBLL().Count_Daily_Page(context.Session["userName"].ToString(), pageSize);
                } 
                }
            }
        if (context.Request.Form["action"]=="getTotalDailyPage")
        {
            if (context.Session["totalDailyPage"]!=null)
            {
                context.Response.Write(context.Session["totalDailyPage"].ToString());
            }

        }
        
       if (context.Request.Form["action"]=="load")
        {
            int pageNum = int.Parse(context.Session["myDailyPageNum"].ToString());
            context.Response.Write(pageNum.ToString());
        }
        
        //if (context.Request.Form["action"] == "checkNextPage")
        //{
        //    int pageSize = int.Parse(context.Session["pageSize"].ToString());
        //    int nextPageNum = int.Parse(context.Request.Form["pageNum"])+1;
        //    if ((new DailyBLL().Daily(context.Session["userName"].ToString(), pageSize, nextPageNum)).Count==0)
        //    {
        //        context.Response.Write("NULL");
        //    }
        //    else
        //    {
        //        context.Response.Write("IsNotNULL");
        //    }
        //}

       if (context.Request.Form["action"]=="first")
       {
           context.Session["myDailyPageNum"] = 1;
           int pageNum = int.Parse(context.Session["myDailyPageNum"].ToString());
           context.Response.Write(pageNum.ToString());
       }
       if  (context.Request.Form["action"] == "plus")
        {
            context.Session["myDailyPageNum"] = (int.Parse(context.Session["myDailyPageNum"].ToString()) + 1);
            int pageNum = int.Parse(context.Session["myDailyPageNum"].ToString());
            context.Response.Write(pageNum.ToString());
        }
       if (context.Request.Form["action"] == "minus")
       {
           context.Session["myDailyPageNum"] = (int.Parse(context.Session["myDailyPageNum"].ToString()) - 1);
           int pageNum = int.Parse(context.Session["myDailyPageNum"].ToString());
           context.Response.Write(pageNum.ToString());
       }
      
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}