namespace ElevatorSystem.Requests
{
    public interface IRequest
    {
        int CurrentFloorNumber { get; }
        int DestinationFloorNumber { get; }
    }

    public class ElevatorRequest : IRequest
    {
        public int CurrentFloorNumber { get; private set; }
        public int DestinationFloorNumber { get; private set; }

        public ElevatorRequest(int currentFloor, int destinationFloor)
        {
            CurrentFloorNumber = currentFloor;
            DestinationFloorNumber = destinationFloor;
        }
    }

    public class FloorRequest : IRequest
    {
        public int CurrentFloorNumber { get; private set; }
        public int DestinationFloorNumber { get; private set; }

        public FloorRequest(int currentFloor, int destinationFloor)
        {
            CurrentFloorNumber = currentFloor;
            DestinationFloorNumber = destinationFloor;
        }
    }
}