//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int BookingId { get; set; }
        public Nullable<int> UserId { get; set; }
        public int TicketQuantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ShowId { get; set; }
        public Nullable<int> SeatId { get; set; }
    }
}
