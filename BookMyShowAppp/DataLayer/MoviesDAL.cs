using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    
    public class MoviesDAL
    {
        public List<MovieTable> Movies()
        {
            BookMyShowEntities2 entity_obj = new BookMyShowEntities2();
            var info = entity_obj.MovieTables.ToList();
            return info;
        }

        public void UserRegistration(string username,string password,string mobileno,string address,string emailid)
        {
            User obj = new User();
            obj.UserName = username;
            obj.Password = password;
            obj.MobileNo = mobileno;
            obj.Address = address;
            obj.EmailId = emailid;
            BookMyShowEntities2 db = new BookMyShowEntities2();
            db.Users.Add(obj);
            db.SaveChanges();
        }

        public IQueryable<int> user_authentication(string username,string password)
        {
            BookMyShowEntities2 entity_obj = new BookMyShowEntities2();
            //var user_info = entity_obj.Users.SqlQuery("Select UserName,UserPassword from Users").ToList();
            var user_info = entity_obj.Users.Where(temp => temp.UserName == username && temp.Password == password).Select(temp => temp.UserId);
            

            //            var info = entity_obj.Users.ToList();
            //          var a = new List<string>();
            return user_info;
    //        return user_info;
        }
    }
}
