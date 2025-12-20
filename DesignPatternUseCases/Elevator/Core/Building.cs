using System;
using System.Collections.Generic;

namespace ElevatorSystem.Core
{
    public class Floor
    {
        public int FloorNumber { get; private set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
        }
    }

    public class Building
    {
        public int TotalFloors { get; private set; }
        public List<Floor> Floors { get; private set; }
        
        public Building(int totalFloors)
        {
            TotalFloors = totalFloors;
            Floors = new List<Floor>();
            for (int i = 0; i < totalFloors; i++)
            {
                Floors.Add(new Floor(i));
            }
        }
    }
}