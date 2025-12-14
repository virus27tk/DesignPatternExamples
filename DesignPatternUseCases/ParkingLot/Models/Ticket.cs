using System;

namespace ParkingLot.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Spot Spot { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal? Fee { get; set; }

        public Ticket(int ticketId, Vehicle vehicle, Spot spot)
        {
            TicketId = ticketId;
            Vehicle = vehicle;
            Spot = spot;
            EntryTime = DateTime.Now;
        }

        public void CloseTicket()
        {
            ExitTime = DateTime.Now;
        }
    }
}