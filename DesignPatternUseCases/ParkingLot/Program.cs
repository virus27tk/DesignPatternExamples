
using ParkingLot.Enums;
using ParkingLot.Models;
using ParkingLot.Services;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("=== Parking Lot System ===");
		Console.Write("Enter parking lot capacity: ");
		int capacity = int.Parse(Console.ReadLine() ?? "0");
		var lot = new ParkingLotModel(capacity);

		var parkingLotService = new ParkingLotService(lot, new TicketService());

		while (true)
		{
			Console.WriteLine("\nMenu:");
			Console.WriteLine("1. Park Vehicle");
			Console.WriteLine("2. Remove Vehicle");
			Console.WriteLine("3. Show Status");
			Console.WriteLine("4. Exit");
			Console.Write("Choose an option: ");
			var input = Console.ReadLine();
			switch (input)
			{
				case "1":
					var vehicleTypeString = Console.ReadLine();
					var vehicleType = Enum.Parse<VehicleType>(vehicleTypeString, true);

					var vehicle = new Vehicle(2909, vehicleType);
					var ticket = parkingLotService.ParkVehicle(vehicle);
					if (ticket is not null)
						Console.WriteLine($"Vehicle parked successfully. Ticket Number : {ticket.TicketId}");
					else
						Console.WriteLine("Parking lot is full!");
					break;
				case "2":
				    var ticketIdToExit = Console.ReadLine();
					var exitTicket = parkingLotService.ExitVehicle(int.Parse(ticketIdToExit));
					Console.WriteLine($"Vehicle Exited successfully. Ticket Number : {exitTicket.Fee}");
					break;
				case "3":
					parkingLotService.ShowStatus();
					break;
				case "4":
					Console.WriteLine("Exiting...");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
		}
	}
}
