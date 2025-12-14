using ParkingLot.Models;

namespace ParkingLot.Interfaces
{
    public interface ITicketService
    {
        Ticket GenerateTicket(Vehicle vehicle, Spot spot);
        decimal CalculateFee(Ticket ticket);
        Ticket CloseTicket(Ticket ticket);
    }
}