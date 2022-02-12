using StudentFollowApi.Context;
using StudentFollowApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentFollowApi.Auth
{
    public class UserService:IDisposable
    {

        StudentFollowDbContext db = new StudentFollowDbContext();
        public UserViewModel ValidateUser(string userName,string password)
        {

            UserViewModel user = null;

           
                user = (from u in db.Users
                        join r in db.Roles
                        on u.RoleId equals r.Id
                        where u.UserName == userName && u.Password == password
                        select new UserViewModel() { 
                            UserName=u.UserName,
                            Role=r.Name
                        }).FirstOrDefault();

            return user;

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}