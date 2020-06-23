using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ThShowDTO
    {
        public Nullable<int> ShowId { get; set; }
        public Nullable<int> MovieId { get; set; }
        public Nullable<int> TheatreId { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public string TheatreName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Nullable<int> Pincode { get; set; }
        public Nullable<int> Price { get; set; }
    }
}
