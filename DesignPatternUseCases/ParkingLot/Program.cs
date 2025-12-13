
using ParkingLot.Models;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("=== Parking Lot System ===");
		Console.Write("Enter parking lot capacity: ");
		int capacity = int.Parse(Console.ReadLine() ?? "0");
		var lot = new ParkingLot.Models.ParkingLot(capacity);

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
					if (lot.ParkVehicle())
						Console.WriteLine("Vehicle parked successfully.");
					else
						Console.WriteLine("Parking lot is full!");
					break;
				case "2":
					if (lot.RemoveVehicle())
						Console.WriteLine("Vehicle removed successfully.");
					else
						Console.WriteLine("Parking lot is empty!");
					break;
				case "3":
					Console.WriteLine($"Occupied: {lot.Occupied} / {lot.Capacity}");
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
