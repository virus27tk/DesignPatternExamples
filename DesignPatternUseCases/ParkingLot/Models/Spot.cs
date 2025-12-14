using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class Spot
    {
        public int SpotId { get; set; }
        public VehicleType SpotType { get; set; }
        public SpotStatus Status { get; set; }

        public Spot(VehicleType type)
        {
            SpotId = new Random().Next(1000, 9999); // Random ID for simplicity
            SpotType = type;
            Status = SpotStatus.Free;
        }

        public void OccupySpot()
        {
            Status = SpotStatus.Occupied;
        }

        public void FreeSpot()
        {
            Status = SpotStatus.Free;
        }
    }
}