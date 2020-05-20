using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ClassLibrary1
{
    public class Class1
    {
       
        public List<Theatre> Display()
        {
            List<Theatre> obj;
            BookMyShowEntities1 check = new BookMyShowEntities1();
            
                obj = check.Theatres.ToList();
            
            return obj;
        }
        public List<TheatreShow> Check(int m)
        {
            BookMyShowEntities1 db = new BookMyShowEntities1();
            var query = (from s in db.Shows
                         join t in db.Theatres
                          on s.TheatreId equals t.TheatreId
                         where s.MovieId == m
                         select new TheatreShow
                         {
                             TheatreName = t.TheatreName,
                             MovieId = s.MovieId,
                            DateTime=s.DateTime
                        }).ToList();
            return query;
        }
    }
}
