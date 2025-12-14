using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class Vehicle
    {
        public int VehicleNumber { get; set; }
        public VehicleType VehicleType { get; set; }

        public Vehicle(int vehicleNumber, VehicleType type)
        {
            VehicleNumber = vehicleNumber;
            VehicleType = type;
        }
    }
}