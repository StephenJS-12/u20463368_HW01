using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20463368_HW01.Models
{
    public class BookingModel
    {
        public string BookingID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string PickUpTime { get; set; }
        public string Reason { get; set; }
        public string Vehicle { get; set; }
        public string Driver { get; set; }
        public string PickUpAddress { get; set; }
    }
}