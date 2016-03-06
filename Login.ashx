<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;
using System.Web.SessionState;//Session接口

public class Login : IHttpHandler, IReadOnlySessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Session["userName"]==null)
        {
            context.Response.Write("");
        }
        else
        {
            context.Response.Write(context.Session["userName"].ToString());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}