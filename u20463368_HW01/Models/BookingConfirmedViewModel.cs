using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20463368_HW01.Models
{
    public class BookingConfirmedViewModel
    {
        /* Driver Inputs */
        public string BookingID { get; set; }
        public string BookingDate { get; set; }
        public string PickUpTime { get; set; }
        public string PickUpAddress { get; set; }
        public string Driver { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string DriverImage { get; set; }
        public string VehicleType { get; set; }
        public string VehicleRegistration { get; set; }
        public string VehicleImage { get; set; }
    }
}