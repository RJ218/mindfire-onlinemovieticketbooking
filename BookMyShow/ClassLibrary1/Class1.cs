using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public List<Theatre> Display()
        {
            List<Theatre> obj;
            using (BookMyShowEntities check = new BookMyShowEntities())
            {
                obj = check.Theatres.ToList();
            }
            return obj;
        }
    }
}
