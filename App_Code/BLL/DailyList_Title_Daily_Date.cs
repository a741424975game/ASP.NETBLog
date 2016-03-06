using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DailyList_Title_Daily_Date 的摘要说明
/// </summary>
public class DailyList_Title_Daily_Date
{
	public DailyList_Title_Daily_Date()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public int dailyId { get; set; }

    public string dailyTitle { get; set; }

    public string dailyContent { get; set; }

    public string date { get; set; }
}