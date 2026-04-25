using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_System
{
    /*
    ========================================
            Properties / Attributes
    ========================================

    - vehicleId (string): Unique vehicle ID
    - make (string): Vehicle manufacturer
    - model (string): Vehicle model
    - year (integer): Manufacturing year
    - dailyRate (decimal/float): Daily rental rate
    - isAvailable (boolean): Current availability status

    ========================================
                   Methods
    ========================================

    - Constructor to initialize the vehicle

    - getVehicleInfo(): Returns formatted vehicle information

    - rent(): Marks vehicle as unavailable

    - returnVehicle(): Marks vehicle as available

    - calculateRentalCost(days): Calculates total cost for rental period

    ========================================
    */
    internal class Vehicle
    {
        public string VehicleID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
        public decimal VehicleDailyRate { get; set; }
        public bool IsAvailable { get; set; }

        public Vehicle(string vehicleID, string vehicleMake, string vehicleModel, int vehicleYear, decimal vehicleDailyRate, bool isAvailable)
        {
            VehicleID = vehicleID;
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
            VehicleYear = vehicleYear;
            VehicleDailyRate = vehicleDailyRate;
            IsAvailable = isAvailable;
        }

        public void GetVehicleInfo() 
        {
            Console.WriteLine($"Vechile {VehicleID} => {IsAvailable}");
            Console.WriteLine($"===================");
            Console.WriteLine($"{VehicleModel} - {VehicleMake}");
            Console.WriteLine($"Model Of the Year {VehicleYear}");
            Console.WriteLine($"Vehicle Daily Rate {VehicleDailyRate}");
        }

        public void Rent() 
        {
            if (!IsAvailable)
            {
                Console.WriteLine("Car Is not Available RigthNow !");
                return;
            }
            
            IsAvailable = false;
            Console.WriteLine("Car Rented Successfully !");
        }

        public void ReturnVehicle() 
        {
            if (IsAvailable)
            {
                Console.WriteLine("Car Is Already Available !");
                return;
            }

            IsAvailable = true;
            Console.WriteLine("Car Returned Successfully !");
        }

        public double CalcRentalCost(int days) 
        {
            double cost = 1200 * days;

            return cost;
        }
    }
}
