namespace mareshell
{
    internal class ParkingSpot
    {
        public int SpotNumber { get; }
        public string VehicleType { get; }
        public bool IsOccupied { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public ParkingSpot(int spotNumber, string vehicleType)
        {
            SpotNumber = spotNumber;
            VehicleType = vehicleType;
            IsOccupied = false;
            Vehicle = null;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            IsOccupied = true;
        }

        public void FreeSpot()
        {
            Vehicle = null;
            IsOccupied = false;
        }
    }
}
