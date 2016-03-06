using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DAL;

/// <summary>
/// UserRegister 用于用户注册
/// </summary>
public class RegisterBLL
{
    private UserDAL userDAL = new UserDAL();
    private SMTPManager smtpManager = new SMTPManager();
    private User newUser = new User();

    public RegisterBLL()
	{
		
	}


    public  bool New_user(string userName,string userPwd,string userEmail)
    {
        if (userDAL.Get_userByname(userName)==null)
            {
                try
                {
                 newUser.userName = userName;
                newUser.userPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(userPwd, "MD5");
                newUser.userEmail = userEmail;
                newUser.state = 0;
                userDAL.Insert_user(newUser);
                string emailMassage = string.Format("http://a741424975game.xicp.net/userActivated.aspx?&name={0}", EncodeDecode.Encode(userName).Trim());//网址改为当前网页域名或地址,通过加密算法加密url中的name变量
                smtpManager.SendEmail("a414018479game@163.com", "Blog".Trim(), userEmail.Trim(), emailMassage.Trim(), "感谢您注册,请点击下面链接完成注册".Trim(), false);
                return true;
                }
                catch (Exception e)
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    public bool UserName_Is_Exist(string userName)
        {
            User user = userDAL.Get_userByname(userName);
            if (user!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

}

          
