﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class BookSeatDTO
    {
        public int ShowId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> TicketQuantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public List<ValueDTO> SeatF { get; set; }
    }

    public class ValueDTO
    {
        public int getseat { get; set; }
    }

}
