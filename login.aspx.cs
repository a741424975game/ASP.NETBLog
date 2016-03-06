using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            Response.Redirect("homePage.aspx");
        }
    }
    protected void goToSignupBt_Click(object sender, EventArgs e)
    {
        Response.Redirect("register.aspx");
    }
    protected void signinBt_Click(object sender, EventArgs e)
    {
        LoginBLL loginBLL = new LoginBLL();
        string name = Request.Form["userNameTb"];
        string pWd = Request.Form["userPwdTb"];
        if (name != "" & pWd != "") {
            if (loginBLL.Verify_user(name, pWd))
            {
                if (loginBLL.Is_activated(name))
                {
                    Session["userName"]=name;
                    Session["myDailyPageNum"] = 1;
                    Message.Alert("登陆成功!","homePage.aspx");
                }
                else
                {
                    Message.Alert("账号未激活,请通过邮箱链接激活账号,系统再次发送激活邮件。");
                    loginBLL.Resend_ActivateEmail("name");
                }
            }
            else
            {
                Message.Alert("用户名或密码错误!");
            }
        }
        else
        {
            Message.Alert("请输入用户名和密码!");

        }

    }

}