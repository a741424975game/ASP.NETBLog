<%@ WebHandler Language="C#" Class="ChangePwd" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;//Session接口

public class ChangePwd : IHttpHandler ,IReadOnlySessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.Form["action"] == "getUserName")
        {
            if (context.Session["userName"]!=null)
            {
                context.Response.Write(context.Session["userName"].ToString());
            }
        }
        if (context.Request.Form["action"]=="checkOldPwd")
        {
            if (new ChangePwdBLL().CheckOldPwd(context.Request.Form["name"],context.Request.Form["pWd"]))
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("false");
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}