using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_System
{
    /*
    ========================================
            Properties / Attributes
    ========================================

    - agencyName (string): Name of the rental agency
    - vehicles (List/Array of Vehicle objects): All vehicles in the fleet
    - customers (List/Array of Customer objects): All registered customers
    - rentals (List/Array of Rental objects): All rental records

    ========================================
                   Methods
    ========================================

    - Constructor to initialize the agency

    - addVehicle(vehicle): Adds vehicle to fleet

    - registerCustomer(customer): Registers a new customer

    - getAvailableVehicles(): Returns list of available vehicles

    - createRental(customer, vehicle, days): Creates new rental

    - completeRental(rentalId): Completes a rental and calculates final cost

    - getActiveRentals(): Returns all active rentals

    - getCustomerRentals(customerId): Returns customer's rental history

    - displayFleet(): Shows all vehicles and their status

    ========================================
    */
    internal class RentalAgency
    {
        public string AgencyName { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public List<Rental> Rentals { get; set; } = new();

        public RentalAgency(string agencyName)
        {
            AgencyName = agencyName;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                Vehicles.Add(vehicle);
                Console.WriteLine($"{vehicle.VehicleID} - Added Successfully !");
            }
        }

        public void RegisterCustomer(Customer customer) 
        {
            if (customer != null)
            {
                Customers.Add(customer);
                Console.WriteLine($"{customer.CustomerName} - Added Successfully !");
            }
        }

        public void GetAvailableVehicles() 
        {
            foreach (var vehicle in Vehicles)
            {
                if (vehicle.IsAvailable)
                {
                    Console.WriteLine($"{vehicle.VehicleID} : {vehicle.VehicleModel} - {vehicle.VehicleMake} - {vehicle.VehicleYear} Cost => {vehicle.VehicleDailyRate}");
                }
            }
        }

        public void CreateRental(Customer customer, Vehicle vehicle, int days) 
        {
            if (!vehicle.IsAvailable)
            {
                Console.WriteLine("[ERROR] Car isn't Available Now !");
                return;
            }

            string rentalID = $"R{Rentals.Count + 1}:D3";
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(days);

            var rental = new Rental(rentalID , customer , vehicle , startDate , endDate);
            Console.WriteLine("Car Rental Created Successfully");

            vehicle.Rent();
            Rentals.Add(rental);
        }
    }
}
