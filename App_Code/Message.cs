using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Massage 的摘要说明
/// </summary>
public class Message
{
    public static void Alert(string str_Message)
    {
        ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
        scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');", true);
    }
    public static void Alert(string str_Message, string redirect)
    {
        ClientScriptManager scriptManager = ((Page)System.Web.HttpContext.Current.Handler).ClientScript;
        scriptManager.RegisterStartupScript(typeof(string), "", "alert('" + str_Message + "');self.location='" + redirect + "'", true);
    }
}