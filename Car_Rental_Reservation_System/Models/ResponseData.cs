using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rental_Reservation_System.Models
{
    public class ResponseData
    {
        public string Status { get; set; }
        public Exception Error { get; set; }
        public dynamic Data { get; set; }
    }
}