using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
   public class MoviesDAL
    {
      //  MoviesDAL dal = new MoviesDAL();
        public List<TheatreShow> Check(int m)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var query = (from s in db.Shows
                         join t in db.Theatres
                          on s.TheatreId equals t.TheatreId
                         where s.MovieId == m
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
      /*  public List<Seat> GetSeatNo(int query)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var q = db.Seats.Where(temp => temp.TheatreId == query).ToList();
            return q;
        }*/
        public List<MovieTable> Movies()
        {
            BookMyShowEntities4 entity_obj = new BookMyShowEntities4();
            var info = entity_obj.MovieTables.ToList();
            return info;
        }
        public List<Seat> GetSeatNo(int data)
        {
            BookMyShowEntities4 db = new BookMyShowEntities4();
            var query = db.Seats.Where(temp => temp.TheatreId == data).ToList();
             return query;            
        }
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
    }
    }

