<%@ WebHandler Language="C#" Class="Loginout" %>

using System;
using System.Web;
using System.Web.SessionState;//Session接口

public class Loginout : IHttpHandler ,IRequiresSessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Session["userName"] = null;
        context.Session["totalDailyPage"] = null;
        context.Response.Redirect("homePage.aspx");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}