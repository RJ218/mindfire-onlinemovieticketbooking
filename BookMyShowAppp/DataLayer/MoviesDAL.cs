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
     public void RegisterSeatInfo(BookSeat data)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var obj = new Booking();
            for(var i=0;i<data.SeatF.Count();i++)
            {
                obj.ShowId=data.ShowId;
                obj.TicketQuantity = (int)data.TicketQuantity;
                obj.Date = data.Date;
                obj.SeatId = Convert.ToInt32(data.SeatF[i].getseat);
                db.Bookings.Add(obj);
                db.SaveChanges();
            }
         }
        public IQueryable<int> userAuthentication(User user)
        {
            BookMyShowEntities4 entity_obj = new BookMyShowEntities4();
            var user_info = entity_obj.Users.Where(temp => temp.UserName == user.UserName && temp.Password == user.Password).Select(temp => temp.UserId);
            return user_info;
        }
        public void UserRegistration(User user)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            db.Users.Add(user);
            db.SaveChanges();
        }
        /*  public List<Seat> GetSeatNo(int query)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var q = db.Seats.Where(temp => temp.TheatreId == query).ToList();
            return q;
        }*/
    }
}

