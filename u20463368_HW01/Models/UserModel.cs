using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20463368_HW01.Models
{
    public class UserModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PickUpTime { get; set; }
        public string Reason { get; set; }
        public string VehicleChoice { get; set; }
        public string DriverChoice { get; set; }
        public string PickUpAddress { get; set; }
    }
}