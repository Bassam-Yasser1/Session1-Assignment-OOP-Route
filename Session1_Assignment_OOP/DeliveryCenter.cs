using System;
using System.Collections.Generic;
using System.Text;

namespace Session1_Assignment_OOP
{
    internal struct DeliveryCenter
    {
        Shipment[] shipments = new Shipment[10];

        public DeliveryCenter()
        {
        }

        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                {
                    return shipments[index];
                }
                else
                {
                    //if invalid index, return a default Shipment 
                    return new Shipment("ABC");
                }
            }
            set
            {
                if (index >= 0 && index < shipments.Length)
                {
                    shipments[index] = value;
                }
                
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                foreach (var shipment in shipments)
                {
                    if (shipment.TrackingCode == trackingCode)
                    {
                        return shipment;
                    }
                }
                //if not found, return a default Shipment 
                return new Shipment("ABC");
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i].TrackingCode == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }

    }
}
