using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DAL;

/// <summary>
/// ActivateBLL 用于账户激活
/// </summary>
public class ActivateBLL
{
    private UserDAL userDAL = new UserDAL();

    public ActivateBLL()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public bool Activate_user(string encodeUserName)
    {
        string userName = EncodeDecode.Decode(encodeUserName);
        User user = userDAL.Get_userByname(userName);
        if (user != null)
        {
            if (user.state == 0)
            {
                user.state = 1;
                userDAL.Update_user(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        else {
            return false;
        }
    }

}
