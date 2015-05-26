using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Utilities
{
    public class Methods
    {
        public static int GetUserType(string username)
        {
            var db = new DataClasses1DataContext();
            var user = db.Users.FirstOrDefault(u => u.username == username);

            switch(user.userType)
            {
                case (int)UserTypes.Admin:
                    return 0;
                case (int)UserTypes.Parrent:
                    return 2;
                case (int)UserTypes.Teacher:
                    return 1;
                default:
                    return -1;
            }
        }

         
    }
}