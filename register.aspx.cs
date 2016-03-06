using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            Response.Redirect("homePage.aspx");
        }
    }

    protected void signupBt_Click(object sender, EventArgs e)
    {
        RegisterBLL registerBLL = new RegisterBLL();
        string name = Request.Form["userNameTb"];
        string pWd = Request.Form["userPwdTb"];
        string pWdS = Request.Form["userPwdSTb"];
        string email = Request.Form["userEmailTb"];
        if (registerBLL.New_user(name, pWd, email))
        {
            Message.Alert("注册成功,请检查邮箱激活链接!","register.aspx");

        }
        else
        {
            Message.Alert("注册失败请联系管理员!","register.aspx");
        }
    }

}
        