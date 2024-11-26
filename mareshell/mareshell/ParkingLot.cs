using System;
using System.Collections.Generic;
using System.Linq;

namespace mareshell
{
    internal class ParkingLot
    {
        private List<ParkingSpot> spots;
        private int totalCarSpots;
        private int totalMotoSpots;

        public ParkingLot(int totalCarSpots, int totalMotoSpots)
        {
            this.totalCarSpots = totalCarSpots;
            this.totalMotoSpots = totalMotoSpots;
            spots = new List<ParkingSpot>();

            for (int i = 1; i <= totalCarSpots; i++)
            {
                spots.Add(new ParkingSpot(i, "Car"));
            }

            for (int i = totalCarSpots + 1; i <= totalCarSpots + totalMotoSpots; i++)
            {
                spots.Add(new ParkingSpot(i, "Motorcycle"));
            }
        }

        public List<ParkingSpot> GetParkingStatus() => spots;

        public bool ParkVehicle(Vehicle vehicle)
        {
            var availableSpot = spots.FirstOrDefault(s => !s.IsOccupied && s.VehicleType == vehicle.VehicleType);
            if (availableSpot != null)
            {
                availableSpot.ParkVehicle(vehicle);
                return true;
            }
            return false;
        }

        public Vehicle RemoveVehicle(string licensePlate)
        {
            var spot = spots.FirstOrDefault(s => s.IsOccupied && s.Vehicle?.LicensePlate == licensePlate);
            if (spot != null)
            {
                var vehicle = spot.Vehicle;
                spot.FreeSpot();
                return vehicle;
            }
            return null;
        }

        // Add this method to get the vehicle from a specific parking spot
        public Vehicle GetVehicleBySpot(int spotNumber)
        {
            var spot = spots.FirstOrDefault(s => s.SpotNumber == spotNumber && s.IsOccupied);
            return spot?.Vehicle;
        }
    }
}