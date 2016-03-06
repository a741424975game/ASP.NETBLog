using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// RecentDailyList_Daily_Date 用于存储UserDAL中使用Get_user_recentDaily的recentDaily 匿名类型
/// </summary>
public class RecentDailyList_Daily_Date
{
	public RecentDailyList_Daily_Date()
	{

	}

    public int dailyId { get; set; }

    public string dailyTitle { get; set; }

    public string date { get; set; }

}