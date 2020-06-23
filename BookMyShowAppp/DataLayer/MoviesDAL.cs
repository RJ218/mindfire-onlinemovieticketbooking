using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
namespace DataLayer
{
   public class MoviesDAL
    {
     
        //constructor
        //method to return theatre and show table entries to book now page
        public List<TheatreShow> TheatreShowValue(int movieid)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var query = (from s in db.Shows
                         join t in db.Theatres
                          on s.TheatreId equals t.TheatreId
                          join m in db.MovieTables
                          on s.MovieId equals m.MovieId
                         where s.MovieId == movieid
                         select new TheatreShow
                         {
                             TheatreName = t.TheatreName,
                             MovieId = (int)s.MovieId,
                             Price=m.Price,
                             DateTime = (System.DateTime)s.DateTime,
                             TheatreId = t.TheatreId,
                             ShowId=s.ShowId
                         }).ToList();
            return query;
        }
        //method to return movie table entries to movie page
        public List<MovieTable> Movies()
        {
            BookMyShowEntities4 entity_obj = new BookMyShowEntities4();
            var info = entity_obj.MovieTables.ToList();
            return info;
        }
        //method to get seat no for booking seat
        public List<Seat> GetSeatNo(int theatreid)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var query = db.Seats.Where(temp => temp.TheatreId == theatreid).ToList();
             return query;            
        }
        //method to register the booking info to booking table
     public List<User> RegisterSeatInfo(BookSeat data)
        {
             
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var obj = new Booking();
            for(var i=0;i<data.SeatF.Count();i++)
            {
                obj.ShowId=data.ShowId;
                obj.UserId = data.UserId;
                obj.TicketQuantity = (int)data.TicketQuantity;
                obj.Date = data.Date;
                obj.SeatId = Convert.ToInt32(data.SeatF[i].getseat);
                db.Bookings.Add(obj);
                db.SaveChanges();
            }
           return (userddata(data.UserId));
         }
       
        public User userAuthentication(User user)
        {
            BookMyShowEntities4 entity_obj = new BookMyShowEntities4();
            var user_info = entity_obj.Users.Where(temp => temp.UserName == user.UserName && temp.Password == user.Password).Select(temp => temp.UserId).FirstOrDefault();//.ToList().Count;
            user.UserId = user_info;
            if (user_info !=0)
                return user;
            else
                return null;
        }
        public void UserRegistration(User user)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            db.Users.Add(user);
            db.SaveChanges();
        }
        public List<Booking> GetBookingInfo(int showid)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var query = db.Bookings.Where(temp => temp.ShowId == showid).ToList();
            return query;
        }
        public List<Cast> GetCastInfo()
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var query = db.Casts.ToList();
            return query;
        }
         public List<User> userddata(int? userid)
       {
           BookMyShowEntities4 db = new BookMyShowEntities4();
             var query = db.Users.Where(u => u.UserId == userid).ToList();
           /* var query = (from s in User
                         where s.UserId == userid
                         select new BookUser
                         {
                             UserId = s.UserId,
                             MobileNo = s.MobileNo,
                             EmailId = s.EmailId
                         }).ToList();
                  */
                                
            // BookUser bk = new BookUser()
            // bk = query.AsQueryable().Cast<BookUser>();
            // var q = db.Users.Where(temp => temp.UserId == userid).ToList();
            return (query);
       }
    }
}

