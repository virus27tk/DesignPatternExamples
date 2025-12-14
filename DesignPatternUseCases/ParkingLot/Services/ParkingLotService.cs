using System;
using System.Collections.Generic;
using ParkingLot.Interfaces;
using ParkingLot.Models;

namespace ParkingLot.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private ParkingLotModel _parkingLot;
        private ITicketService _ticketService;
        private Dictionary<int, Ticket> _activeTickets;

        public ParkingLotService(ParkingLotModel parkingLot, ITicketService ticketService)
        {
            _parkingLot = parkingLot;
            _ticketService = ticketService;
            _activeTickets = new Dictionary<int, Ticket>();
        }

        public Ticket ParkVehicle(Vehicle vehicle)
        {
            foreach (var floor in _parkingLot.Floors)
            {
                if (floor.HasFreeSpot(vehicle.VehicleType))
                {
                    var spot = floor.GetFreeSpot(vehicle.VehicleType);
                    spot.OccupySpot();
                    var ticket = _ticketService.GenerateTicket(vehicle, spot);
                    _activeTickets.Add(ticket.TicketId, ticket);
                    return ticket;
                }
            }
            return null; // No free spot available
        }

        public Ticket ExitVehicle(int ticketId)
        {
            if (_activeTickets.ContainsKey(ticketId))
            {
                var ticket = _activeTickets[ticketId] as Ticket;
                ticket = _ticketService.CloseTicket(ticket);
                _activeTickets.Remove(ticket.TicketId);
                return ticket;
            }
            throw new ArgumentException("Invalid Ticket ID");
        }

        public void ShowStatus()
        {
            foreach (var floor in _parkingLot.Floors)
            {
                Console.WriteLine($"Floor {floor.FloorNumber}:");
                foreach (var spot in floor.Spots)
                {
                    Console.WriteLine($"  Spot {spot.SpotId} ({spot.SpotType}): {spot.Status}");
                }
            }
        }
    }
}