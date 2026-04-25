using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Rental_System
{
    /*
    ========================================
            Properties / Attributes
    ========================================

    - customerId (string): Unique customer ID
    - name (string): Customer's full name
    - phone (string): Contact phone number
    - email (string): Email address
    - driversLicenseNumber (string): Driver's license number

    ========================================
                   Methods
    ========================================

    - Constructor to initialize the customer

    - getCustomerInfo(): Returns formatted customer information

    ========================================
    */
    internal class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string DriverLicenseNumber { get; set; }

        public Customer(string customerID, string customerName, string customerPhone, string customerEmail, string driverLicenseNumber)
        {
            CustomerID = customerID;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            DriverLicenseNumber = driverLicenseNumber;
        }

        public void GetCustomerInfo()
        {
            Console.WriteLine($"Customer - {CustomerID}");
            Console.WriteLine("========================");
            Console.WriteLine($"Name: {CustomerName}");
            Console.WriteLine($"LicenseNumber: {DriverLicenseNumber}");
            Console.WriteLine($"Phone: {CustomerPhone}");
            Console.WriteLine($"Email: {CustomerEmail}");

        }
    }
}
