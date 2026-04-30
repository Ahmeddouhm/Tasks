using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_System
{
    /*
    ========================================
            Properties / Attributes
    ========================================

    - rentalId (string): Unique rental ID
    - customer (Customer): The customer renting
    - vehicle (Vehicle): The vehicle being rented
    - startDate (Date/DateTime): Rental start date
    - endDate (Date/DateTime): Rental end date
    - isActive (boolean): Whether rental is currently active

    ========================================
                   Methods
    ========================================

    - Constructor to initialize the rental

    - getRentalDuration(): Returns number of rental days

    - getTotalCost(): Calculates total rental cost

    - completeRental(): Marks rental as completed and returns vehicle

    - getRentalInfo(): Returns formatted rental information

    ========================================
    */
    internal class Rental
    {
        public string RentalID { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public bool IsActive { get; set; }

        public Rental(string rentalID, Customer customer, Vehicle vehicle, DateTime rentStartDate, DateTime rentEndDate)
        {
            RentalID = rentalID;
            Customer = customer;
            Vehicle = vehicle;
            RentStartDate = rentStartDate;
            RentEndDate = rentEndDate;
        }

        public int GetRentalDuration() 
        {
            var duration = RentEndDate - RentStartDate;

            return duration.Days;
        }

        public double GetTotalCost() 
        {
            return Vehicle.CalcRentalCost(GetRentalDuration());
        }

        public void CompleteRental() 
        {
            if (!Vehicle.IsAvailable)
            {
                Console.WriteLine("Rent Duration Ended !");
                Vehicle.IsAvailable = true;
            }
        }

        public void GetRentalInfo()
        {
            Console.WriteLine($"Rental : {RentalID} - {IsActive}");
            Console.WriteLine($"    By Customer {Customer.CustomerID} - {Customer.CustomerName}");
            Console.WriteLine($"    Vehicle : {Vehicle.VehicleID} - {Vehicle.VehicleModel}/{Vehicle.VehicleYear}");
        }
    }
}
