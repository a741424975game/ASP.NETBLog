using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DAL;

/// <summary>
/// AddDailyBLL 用于用户记录日常
/// </summary>
public class DailyBLL
{
    private UserDAL userDAL = new UserDAL();
    private Daily daily = new Daily();
	
    public DailyBLL()
	{

	}

    public bool  Add_Daily(string userName,string dailyTitle ,string dailyContent,DateTime date)
    {
        daily.userName = userName;
        daily.dailyTitle = dailyTitle;
        daily.dailyContent = dailyContent;
        daily.date = date;
        if (userDAL.Add_users_Daily(daily))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public List<RecentDailyList_Daily_Date> Recent_Daily(string userName, int amount)
    {
        if (userDAL.Get_user_recentDaily(userName,amount)!=null)
        {
            return userDAL.Get_user_recentDaily(userName,amount).ToList();
        }
        else
        {
            return null;
        }
    }

    public int Count_Daily_Page(string userName, int pageSize)
    {
        int totalDailyNum = userDAL.Count_user_Daily(userName);
        int totalPageNum = Convert.ToInt16(Math.Ceiling((Convert.ToDouble(totalDailyNum))/(Convert.ToDouble(pageSize))));
        return totalPageNum;
    }

    public List<DailyList_Title_Daily_Date> Daily(string userName,int pageSize,int pageNum)
    {
        if (userDAL.Get_user_Daily(userName,pageSize,pageNum)!=null)
        {
            return userDAL.Get_user_Daily(userName,pageSize,pageNum).ToList();
        }
        else
        {
            return null;
        }
    }

    public List<DailyList> Get_DailyById_toList(int id)
    {
        if (userDAL.Get_DailyById(id)!=null)
        {
            daily = userDAL.Get_DailyById(id);
            var list = new List<DailyList>();
            list.Add(new DailyList(){userName=daily.userName,title=daily.dailyTitle,content=daily.dailyContent,date=daily.date.ToString()});
            return list;
            
        }
        else
        {
            return null;
        }
    }

    public Daily Get_DailyById(int id)
    {
        if (userDAL.Get_DailyById(id)!=null)
        {
            return userDAL.Get_DailyById(id);
        }
        else
        {
            return null;
        }
    }

    public bool Comfirm_DeleteDaily(int id, string userName)
    {
        if (userDAL.Get_DailyById(id)!=null)
        {
            if (userDAL.Get_DailyById(id).userName.Trim()==userName)
            {
                if (userDAL.DeleteDaily(id))
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
        else
        {
            return false;
        }
    }

    public bool Comfirm_EditDaily(int id,string title,string content,string userName)
    {
        if (userDAL.Get_DailyById(id)!=null)
        {
            Daily daily = userDAL.Get_DailyById(id);
            if (daily.userName.Trim()==userName)
            {
                daily.dailyTitle = title;
                daily.dailyContent = content;
                userDAL.Update_daily(daily);
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

}