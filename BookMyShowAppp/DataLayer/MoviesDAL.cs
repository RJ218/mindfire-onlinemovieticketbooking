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
            BookMyShowEntities1 entity_obj = new BookMyShowEntities1();
            var info = entity_obj.MovieTables.ToList();
            return info;
        }
    }
}
