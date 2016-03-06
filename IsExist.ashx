<%@ WebHandler Language="C#" Class="IsExist" %>

using System;
using System.Web;


public class IsExist : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string userName = context.Request.Form["name"];
        if (new RegisterBLL().UserName_Is_Exist(userName))
        {
            context.Response.Write("true");//js 中的 msg为string格式
        }
        else
        {
            context.Response.Write("false");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}