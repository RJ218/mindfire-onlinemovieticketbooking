using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class SeatNoDTO
    {
        public int SeatId { get; set; }
        public Nullable<int> TheatreId { get; set; }
        public Nullable<int> SeatNo { get; set; }
    }
}
