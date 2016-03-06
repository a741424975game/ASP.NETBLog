using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DAL;

/// <summary>
/// ChangePwdBLL 的摘要说明
/// </summary>
public class ChangePwdBLL
{
    private UserDAL userDAL = new UserDAL();
    private User user = new User();

	public ChangePwdBLL()
	{

	}

    public bool CheckOldPwd(string userName,string Pwd) 
    {
        if (userDAL.Get_userByname(userName)!=null)
        {
            this.user = userDAL.Get_userByname(userName);
            if (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd, "MD5")==this.user.userPwd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void ChangePwd(string Pwd)
    {
        this.user.userPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Pwd, "MD5");
        userDAL.Update_user(this.user);

    }

}