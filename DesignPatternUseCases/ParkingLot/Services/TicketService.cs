using System;
using ParkingLot.Factories;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class TicketService : ITicketService
    {
        public Ticket GenerateTicket(Vehicle vehicle, Spot spot)
        {
            return new Ticket(new Random().Next(1000, 9999), vehicle, spot);
        }

        public decimal CalculateFee(Ticket ticket)
        {
            IPaymentStrategy paymentStrategy = PaymentStrategyFactory.GetPaymentStrategy(ticket.Vehicle.VehicleType);
            return paymentStrategy.CalculateFee(ticket.EntryTime, ticket.ExitTime.Value);
        }

        public Ticket CloseTicket(Ticket ticket)
        {
            ticket.CloseTicket();
            ticket.Fee = CalculateFee(ticket);
            ticket.Spot.FreeSpot();
            return ticket;
        }
    }
}