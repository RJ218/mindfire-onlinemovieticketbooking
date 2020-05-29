using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookMyShow.API.Models
{
    public class Userapi
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
}