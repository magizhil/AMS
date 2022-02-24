using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
namespace AMS.Models
{

    public static class Repository
    {
        
        static List<Users> users = new List<Users>() {
        
        new Users() {Name="KAI/gowtham.g",Roles="Admin,Editor"},
        new Users() {Name="xyz@gmail.com",Roles="Editor" }
    };

        public static Users GetUserDetails(Users user)
        {
            return users.Where(u => u.Name.ToLower() == user.Name.ToLower()).FirstOrDefault();
        }
    }
}