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
            BookMyShowEntities db = new BookMyShowEntities();
            var query = (from s in db.Shows
                         join t in db.Theatres
                          on s.TheatreId equals t.TheatreId
                         where s.MovieId == movieid
                         select new TheatreShow
                         {
                             TheatreName = t.TheatreName,
                             MovieId = (int)s.MovieId,
                             DateTime = (System.DateTime)s.DateTime,
                             TheatreId = t.TheatreId,
                             ShowId=s.ShowId
                         }).ToList();
            return query;
        }
        //method to return movie table entries to movie page
        public List<MovieTable> Movies()
        {
            BookMyShowEntities entity_obj = new BookMyShowEntities();
            var info = entity_obj.MovieTables.ToList();
            return info;
        }
        //method to get seat no for booking seat
        public List<Seat> GetSeatNo(int theatreid)
        {
            BookMyShowEntities db = new BookMyShowEntities();
            var query = db.Seats.Where(temp => temp.TheatreId == theatreid).ToList();
             return query;            
        }
        //method to register the booking info to booking table
     public void RegisterSeatInfo(BookSeat data)
        {
            BookMyShowEntities db = new BookMyShowEntities();
            var obj = new Booking();

            var bookingno = db.Bookings.Select(m => m.BookingId).Distinct().Count();
            bookingno++;
            for(var i=0;i<data.SeatF.Count();i++)
            {
                obj.ShowId=data.ShowId;
                obj.TicketQuantity = (int)data.TicketQuantity;
                obj.Date = Convert.ToDateTime(data.Date);
                obj.SeatId = Convert.ToInt32(data.SeatF[i].getseat);
                obj.BookingId = bookingno;
                db.Bookings.Add(obj);
                db.SaveChanges();
            }
         }
        public int userAuthentication(User user)
        {
            BookMyShowEntities entity_obj = new BookMyShowEntities();
            var user_info = entity_obj.Users.Where(temp => temp.UserName == user.UserName && temp.Password == user.Password).Select(temp => temp.UserId).FirstOrDefault();
            return user_info;
        }
        public void UserRegistration(User user)
        {
            BookMyShowEntities db = new BookMyShowEntities();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<Booking> GetBookingInfo(int showid)
        {
            BookMyShowEntities db = new BookMyShowEntities();
            var query = db.Bookings.Where(temp => temp.ShowId == showid).ToList();
            return query;
        }
        public List<Cast> GetCastInfo()
        {
            BookMyShowEntities db = new BookMyShowEntities();
            var query = db.Casts.ToList();
            return query;
        }

        /*  public List<Seat> GetSeatNo(int query)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var q = db.Seats.Where(temp => temp.TheatreId == query).ToList();
            return q;
        }*/
    }
}

