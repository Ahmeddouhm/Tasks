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
    }
}
