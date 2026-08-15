using System;
using System.Collections.Generic;
using System.Text;

namespace Session1_Assignment_OOP
{
    internal struct DeliveryAddress
    {
        public string City{get; set;}
        public string Street{get; set;}
        public int BuildingNumber{get; set;}


        public override string ToString()
        {
            return $"City: {City}, Street: {Street}, Building Number: {BuildingNumber}";
        }

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }
        public string GetFullAddress()
        {
            return $"{Street} {BuildingNumber}, {City}";
        }
    }
}
