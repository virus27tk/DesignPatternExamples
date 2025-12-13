namespace ParkingLot.Models
{
    public class ParkingLot
    {
        public int Capacity { get; set; }
        public int Occupied { get; set; }

        public ParkingLot(int capacity)
        {
            Capacity = capacity;
            Occupied = 0;
        }

        public bool ParkVehicle()
        {
            if (Occupied < Capacity)
            {
                Occupied++;
                return true;
            }
            return false;
        }

        public bool RemoveVehicle()
        {
            if (Occupied > 0)
            {
                Occupied--;
                return true;
            }
            return false;
        }
    }
}
