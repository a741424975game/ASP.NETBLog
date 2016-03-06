using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DAL;
/// <summary>
/// LoginBLL 用于用户登陆
/// </summary>
/// 


public class LoginBLL
{
    private UserDAL userDAL = new UserDAL();
    private SMTPManager smtpManager = new SMTPManager();
    private User user = new User();

	public LoginBLL()
	{
		
	}

    public bool Verify_user(string userName, string userPwd)
    {
        User user = userDAL.Get_userByname(userName);
        if (user == null)
        {
            return false;
        }
        else {
            if (user.userPwd==System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(userPwd, "MD5"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Is_activated(string userName)
    {
        User user = userDAL.Get_userByname(userName);
        if (user.state == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Resend_ActivateEmail(string userName)
    {
        if (userDAL.Get_userByname(userName)!=null)
        {
            user =userDAL.Get_userByname(userName);
            string userEmail = user.userEmail;
            string emailMassage = string.Format("http://localhost:2496/userActivated.aspx?&name={0}", EncodeDecode.Encode(userName).Trim());//网址改为当前网页地址,通过加密算法加密url中的name变量
            smtpManager.SendEmail("a414018479game@163.com", "Blog".Trim(), userEmail.Trim(), emailMassage.Trim(), "感谢您注册,请点击下面链接完成注册".Trim(), false);
        }
    }
    
}