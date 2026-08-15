using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.InteropServices;

namespace Session1_Assignment_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
        #region Part1 - Theoretical Questions
            #region Q1
            //in case of struct a new copy is made so modifying the copy does not affect the original struct,
            //while in case of class a reference is made so modifying the copy affects the original class.
            #endregion
            #region Q2
            //1. I cannot apply validation on the data assigned to the members
            //2. Changing the naming of the members directly affects the usages of these members from outside the struct which decreases Writability
            //3. No privacy to the fields as the data is exposed to the outside
            
            //Private fields hide the internal data, while public properties provide controlled access as I desire.
            //Properties can implement validation and rules, preventing invalid values and improving encapsulation and maintainability.
            #endregion
            #endregion
        #region Copy Mechanism
            Console.WriteLine("======Copy Mechanism======");
            Console.WriteLine();

            DeliveryAddress Address01 = new DeliveryAddress("Giza", "Dokki", 25);
            DeliveryAddress Address02 = Address01; // make a copy of Address01 and assign it to Address02 

            Console.WriteLine("Before Modification");
            Console.WriteLine("Address01:");
            Console.WriteLine(Address01);
            Console.WriteLine("Address02:");
            Console.WriteLine(Address02);

            // modify the properties of Address02 
            Address02.City = "Cairo";
            Address02.Street = "Abbas El-Akad";
            Address02.BuildingNumber = 100;

            //as struct is a value type, Address02 is a copy of Address01, so modifying Address02 does not affect Address01.
            Console.WriteLine();
            Console.WriteLine("After Modification");
            Console.WriteLine("Address01:");
            Console.WriteLine(Address01);
            Console.WriteLine("Address02:");
            Console.WriteLine(Address02);
            Console.WriteLine();
            #endregion
            #region Part2
            // a. Create a DeliveryCenter
            DeliveryCenter center = new DeliveryCenter();

            // b & c. Read data for three shipments and add them
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter details for Shipment {i + 1}");

                Console.Write("Tracking Code: ");
                string trackingCode = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();


                Console.Write("Weight (kg): ");
                decimal weight;
                while (!decimal.TryParse(Console.ReadLine(), out weight))
                {
                    Console.Write("Invalid value. Enter weight again: ");
                }

                Console.Write("Delivery Fee: ");
                decimal deliveryFee;
                while (!decimal.TryParse(Console.ReadLine(), out deliveryFee))
                {
                    Console.Write("Invalid value. Enter delivery fee again: ");
                }

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Street: ");
                string street = Console.ReadLine();

                Console.Write("Building Number: ");
                int buildingNumber;
                while (!int.TryParse(Console.ReadLine(), out buildingNumber))
                {
                    Console.Write("Invalid value. Enter building number again: ");
                }

                DeliveryAddress address =
                    new DeliveryAddress(city, street, buildingNumber);

                Shipment shipment = new Shipment(
                    trackingCode,
                    description,
                    weight,
                    deliveryFee,
                    address
                );

                if (center.AddShipment(shipment))
                {
                    Console.WriteLine("Shipment added successfully.\n");
                }
                else
                {
                    Console.WriteLine("Failed to add shipment.\n");
                }
            }

            // d. Print the three shipments using the integer indexer
            Console.WriteLine("\n===== All Shipments =====");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nShipment {i + 1}:");
                center[i].PrintShipment();
            }

            // e. Ask the user for a tracking code
            Console.Write("\nEnter tracking code to search: ");
            string searchCode = Console.ReadLine();

            // f. Search using the string indexer
            Shipment foundShipment = center[searchCode];

            // g. Print shipment if found
            if (foundShipment.TrackingCode == "ABC")
            {
                Console.WriteLine("Shipment not found.");
            }
            else
            {
                Console.WriteLine("\n===== Shipment Found =====");
                foundShipment.PrintShipment();
            }

            // Demonstrate DeliveryAddress struct copy behavior
            Console.WriteLine("\n===== DeliveryAddress Copy Behavior =====");

            DeliveryAddress address1 =
                new DeliveryAddress("Giza", "Dokki", 10);

            // Struct assignment creates a COPY
            DeliveryAddress address2 = address1;

            Console.WriteLine("Before changing address2:");
            Console.WriteLine($"Address 1: {address1}");
            Console.WriteLine($"Address 2: {address2}");

            // Change the copy
            address2.BuildingNumber = 20;
            address2.Street = "Mohamed Ali";

            Console.WriteLine("\nAfter changing address2:");
            Console.WriteLine($"Address 1: {address1}");
            Console.WriteLine($"Address 2: {address2}");
            #endregion


        }
    }
}