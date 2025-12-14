using System.Collections.Generic;

namespace ParkingLot.Models
{
    public class ParkingLotModel
    {
        public List<Floor> Floors { get; set; }

        public ParkingLotModel(int numberOfFloors)
        {
            Floors = new List<Floor>();
            for (int i = 0; i < numberOfFloors; i++)
            {
                Floors.Add(new Floor(i + 1, 10));
            }
        }
    }
}