using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"]==null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void changePwdBt_Click(object sender, EventArgs e)
    {
        ChangePwdBLL changePwdBLL=new ChangePwdBLL();
        string oldPwd = Request.Form["userOldPwdTb"];
        string newPwd = Request.Form["userPwdTb"];
        if (changePwdBLL.CheckOldPwd(Session["userName"].ToString(),oldPwd))
        {
            changePwdBLL.ChangePwd(newPwd);
            Message.Alert("密码更改成功!");
        }
        else
        {
            Message.Alert("密码更改失败,请联系管理员!");
        }
    }
}