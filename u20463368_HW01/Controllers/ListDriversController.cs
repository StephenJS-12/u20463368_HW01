using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using u20463368_HW01.Models;

namespace u20463368_HW01.Controllers
{
    public class ListDriversController : Controller
    {
        public static List<BookingModel> bookings = new List<BookingModel>();

        public ActionResult SelectService()
        {
            return View();
        }

        public ActionResult BookingForm()
        {
            return View();
        }
        public ActionResult RegularBookingConfirmed(string bookingData)
        {
            if (!string.IsNullOrEmpty(bookingData))
            {
                var booking = JsonConvert.DeserializeObject<BookingModel>(bookingData);

                // Create a view model to hold the booking details
                var bookingModel = new BookingModel
                {
                    BookingID = Guid.NewGuid().ToString(),
                    FullName = booking.FullName,
                    PhoneNumber = booking.PhoneNumber,
                    PickUpTime = booking.PickUpTime,
                    Reason = booking.Reason,
                    Vehicle = booking.Vehicle,
                    Driver = booking.Driver,
                    PickUpAddress = booking.PickUpAddress
                };

                // Add the booking to the list
                bookings.Add(bookingModel);

                return View(bookingModel);
            }

            // Handle the case where bookingData is null or empty
            return RedirectToAction("BookingForm");
        }

        public ActionResult ManagementTable()
        {
            List<DriverModel> drivers = GetDrivers();
            List<VehicleModel> vehicles = GetVehicles();

            var viewModel = new ListDriversViewModel
            {
                Drivers = drivers,
                Vehicles = vehicles
            };

            return View(viewModel);
        }

        public ActionResult RideHistory()
        {
            return View(bookings);
        }

        public ActionResult BookingConfirmed()
        {
            List<DriverModel> drivers = GetDrivers();
            List<VehicleModel> vehicles = GetVehicles();

            // Generate random indexes for selecting a driver and vehicle
            Random random = new Random();
            int driverIndex = random.Next(drivers.Count);
            int vehicleIndex = random.Next(vehicles.Count);

            // Get the selected driver and vehicle
            DriverModel driver = drivers[driverIndex];
            VehicleModel vehicle = vehicles[vehicleIndex];

            // Create a view model to hold the booking and driver/vehicle details
            var viewModel = new BookingConfirmedViewModel
            {
                BookingID = Guid.NewGuid().ToString(), // Generate a unique booking ID
                BookingDate = DateTime.Now.ToString("yyyy-MM-dd"), // Get the current date
                PickUpTime = "Immediatley",
                PickUpAddress = "123 Main Street, City",
                Driver = driver.FirstName + " " + driver.LastName,
                DriverPhoneNumber = driver.PhoneNumber,
                DriverImage = driver.Image,
                VehicleType = vehicle.VehicleType,
                VehicleRegistration = vehicle.VehicleRegistration,
                VehicleImage = vehicle.VehicleImage
            };

            // Store the booking data in the session to be accessed by the JavaScript code in the view
            Session["BookingData"] = viewModel;

            return View(viewModel);
        }

        static List<DriverModel> GetDrivers()
        {
            List<DriverModel> drivers = new List<DriverModel>();

            // Populate the drivers list with data
            drivers.Add(new DriverModel { FirstName = "Abigail", LastName = "dos Santos", PhoneNumber = "+27 86 776 3547", Service = "Advanced Life Support", Image = "/Content/Images/Abi.jpg" });
            drivers.Add(new DriverModel { FirstName = "Ethan", LastName = "Ramirez", PhoneNumber = "+27 76 823 9265", Service = "Basic Life Support", Image = "/Content/Images/Ethan.jpg" });
            drivers.Add(new DriverModel { FirstName = "Kamlika", LastName = "Patel", PhoneNumber = "+27 73 936 9935", Service = "Patient Transport", Image = "/Content/Images/Kamlika.jpg" });
            drivers.Add(new DriverModel { FirstName = "Liam", LastName = "Thompson", PhoneNumber = "+27 72 336 6355", Service = "Medical Utility Vehicle", Image = "/Content/Images/Liam.jpg" });
            drivers.Add(new DriverModel { FirstName = "Ava", LastName = "Nguyen", PhoneNumber = "+27 82 735 6448", Service = "Event Medical Ambulance", Image = "/Content/Images/Ava.jpg" });
            drivers.Add(new DriverModel { FirstName = "Musa", LastName = "Mokwena", PhoneNumber = "+27 83 025 9312", Service = "Air Ambulance", Image = "/Content/Images/Musa.jpg" });
            drivers.Add(new DriverModel { FirstName = "Masindi", LastName = "Mhlahleki", PhoneNumber = "+27 76 192 1146", Service = "Basic Life Support", Image = "/Content/Images/Masindi.jpg" });
            drivers.Add(new DriverModel { FirstName = "Lucas", LastName = "Johnson", PhoneNumber = "+27 63 883 2335", Service = "Patient Transport", Image = "/Content/Images/Lucas.jpg" });
            drivers.Add(new DriverModel { FirstName = "Emma", LastName = "Parker", PhoneNumber = "+27 73 446 1567", Service = "Advanced Life Support", Image = "/Content/Images/Emma.jpg" });
            drivers.Add(new DriverModel { FirstName = "Kivesh", LastName = "Padarath", PhoneNumber = "+27 76 377 6269", Service = "Medical Utility Vehicle", Image = "/Content/Images/Kivesh.jpg" });

            return drivers;
        }

        static List<VehicleModel> GetVehicles()
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();

            // Populate the vehicles list with data
            vehicles.Add(new VehicleModel { VehicleType = "Ambulance 1", VehicleRegistration = "ABC123", VehicleImage = "/Content/Images/Ambulance1.jpeg", VehicleService = "Advanced Life Support"});
            vehicles.Add(new VehicleModel { VehicleType = "Ambulance 2", VehicleRegistration = "DEF456", VehicleImage = "/Content/Images/Ambulance2.jpeg", VehicleService = "Medical Utility Vehicle" });
            vehicles.Add(new VehicleModel { VehicleType = "Ambulance 3", VehicleRegistration = "GHI789", VehicleImage = "/Content/Images/Ambulance3.jpeg", VehicleService = "Event Medical Ambulance" });
            vehicles.Add(new VehicleModel { VehicleType = "Medical SUV 1", VehicleRegistration = "ACE321", VehicleImage = "/Content/Images/Medical SUV 1.jpeg", VehicleService = "Basic Life Support" });
            vehicles.Add(new VehicleModel { VehicleType = "Shuttle 1", VehicleRegistration = "BDF654", VehicleImage = "/Content/Images/Shuttle 1.jpeg", VehicleService = "Patient Transport" });
            vehicles.Add(new VehicleModel { VehicleType = "Helicopter", VehicleRegistration = "GIJ987", VehicleImage = "/Content/Images/Helicopter.jpg", VehicleService = "Air Ambulance" });

            return vehicles;
        }
    }
}