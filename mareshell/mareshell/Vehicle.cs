using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mareshell
{
    internal class Vehicle
    {
        public string LicensePlate { get; }
        public string VehicleType { get; }
        public DateTime EntryTime { get; }

        public Vehicle(string licensePlate, string vehicleType)
        {
            LicensePlate = licensePlate;
            VehicleType = vehicleType;
            EntryTime = DateTime.Now;  // Set the entry time to now
        }

    }
}
