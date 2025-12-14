using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface IParkingLotService
    {
        Ticket ParkVehicle(Vehicle vehicle);
        Ticket ExitVehicle(int ticketId);
        void ShowStatus();
    }
}