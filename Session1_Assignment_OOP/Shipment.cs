using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Session1_Assignment_OOP
{
    internal struct Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public Shipment(string trackingCode) 
        {
            TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50m;
            Destination = new DeliveryAddress("Giza", "Dokki", 1);
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public DeliveryAddress Destination { get; set; }

        //in case of invalid values, the properties will not be set and will keep their current values.
        public string TrackingCode
        {
            get { return trackingCode; }
            private set
            { if (!String.IsNullOrWhiteSpace(value))
                    trackingCode = value;
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    description = value;
            }
        }
        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                    weight = value;
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if(value > 0) 
                    deliveryFee = value;
            }
        }
        public decimal EstimatedCost
        {
            get { return (DeliveryFee + (weight * 5)); }
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            DeliveryFee = newFee;
        }

        public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: ${DeliveryFee}");
            Console.WriteLine($"Destination Address: {Destination}");
            Console.WriteLine($"Estimated Cost: ${EstimatedCost}");
        }
    }
}
