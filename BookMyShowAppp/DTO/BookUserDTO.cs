using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BookUserDTO
    {

        public int BookingId { get; set; }
        public int UserId { get; set; }
        public Nullable<long> MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
}
