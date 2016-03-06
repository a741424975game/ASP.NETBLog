using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserDAL 用于实现用户信息与数据库的读入与写出
/// </summary>

namespace DAL
{
    public class UserDAL
    {
        //链接数据库
        private DataClassesDataContext db = new DataClassesDataContext();

        public UserDAL()
        {

        }

        public bool Insert_user(User newUser) //将新用户插入User表中
        {
            try
            {
                db.User.InsertOnSubmit(newUser);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert_user exception caught." + e);
                return false;
            }
        }

        public bool Update_user(User user) //更新用户信息
        {
            try
            {
                User past_user = db.User.First(u => u.userName == user.userName);
                past_user = user;
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Activate_user eception caught." + e);
                return false;
            }
        }

        public User Get_userByname(string userName)   //获取一个用户名为userName的User类   使用前必须用if判断是否能获取 否则会提示未实例的错误
        {
            try
            {
                return db.User.First(u => u.userName == userName);

            }
            catch (Exception e)
            {
                Console.WriteLine("Get_userByname eception caught." + e);
                return null;
            }

        }

        public bool Add_users_Daily(Daily newDaily)//将用户的新日常插入Daily表中
        {
            try
            {
                db.Daily.InsertOnSubmit(newDaily);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(" Add_users_Daily exception caught." + e);
                return false;
            }
        }

        public IQueryable<RecentDailyList_Daily_Date> Get_user_recentDaily(string userName, int amount)
        {
            try
            {
                var recentDaily = (from d in db.Daily
                                   where d.userName == userName 
                                   orderby d.id descending
                                   select new RecentDailyList_Daily_Date() { dailyId=d.id,dailyTitle = d.dailyTitle, date = d.date.ToString() }).Take(amount);
                return recentDaily;
            }
            catch (Exception e)
            {

                Console.WriteLine("Get_user_recentDaily exception caught." + e);
                return null;
            }
        }//获取先amout个用户的日常的题目和时间

        public int Count_user_Daily(string userName)//计算用户的日常数量
        {
            int count = db.Daily.Count(d => d.userName == userName);
            return count;

        }

        public IQueryable<DailyList_Title_Daily_Date> Get_user_Daily(string userName,int pageSize,int pageNum)//获取用户的日常并实现分页
        {
            try
            {
                var Daily = (from d in db.Daily
                             where d.userName == userName
                             orderby d.id descending
                             select new DailyList_Title_Daily_Date() {dailyId=d.id, dailyTitle = d.dailyTitle, dailyContent = d.dailyContent, date = d.date.ToString() }).Skip(pageSize*(pageNum-1)).Take(pageSize);
                return Daily;
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Get_user_Daily" + e);
                return null;
            }
        }

        public Daily Get_DailyById(int id)
        {
            try
            {
                return db.Daily.First(d => d.id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get_DailyById" + e);
                return null;
            }
        }//获取一个id为id的Daily类

        public bool DeleteDaily(int id)
        {
            try
            {
                db.Daily.DeleteOnSubmit(db.Daily.First(d=>d.id==id));
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                
                Console.WriteLine("DeleteDaily" + e);
                return false;
            }
        }//从数据库中删除一个id为id 的Daily

        public bool Update_daily(Daily daily)//更新日常信息
        {
            try
            {
                Daily past_daily = db.Daily.First(d=>d.id==daily.id);
                past_daily = daily;
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                
              Console.WriteLine("Update_daily" + e);
                return false;
            }
        }

    }

}

