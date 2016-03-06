using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userActivated : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            ActivateBLL activateBLL = new ActivateBLL();
            string encodeUserName=Request.QueryString["name"];
            if (activateBLL.Activate_user(encodeUserName))
            {
                Message.Alert("激活成功!");
            }
            else
            {
                Message.Alert("账号已经激活,若不能登录,请联系管理员!");
            }
   
    }
}