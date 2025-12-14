using System.Collections.Generic;
using System.Linq;
using ParkingLot.Enums;

namespace ParkingLot.Models
{
    public class Floor
    {
        public int FloorNumber { get; set; }
        public List<Spot> Spots { get; set; }

        public Floor(int floorNumber, int spotsPerFloor)
        {
            FloorNumber = floorNumber;
            Spots = new List<Spot>();
            for (int i = 0; i < spotsPerFloor; i++)
            {
                VehicleType type = (i % 3 == 0) ? VehicleType.Bike : (i % 3 == 1) ? VehicleType.Car : VehicleType.Truck;
                Spots.Add(new Spot(type));
            }
        }

        public bool HasFreeSpot(VehicleType type)
        {
            return Spots.Any(s => s.SpotType == type && s.Status == SpotStatus.Free);
        }

        public Spot GetFreeSpot(VehicleType type)
        {
            return Spots.First(s => s.SpotType == type && s.Status == SpotStatus.Free);
        }
    }
    
};
