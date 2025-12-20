using System;
using System.Collections.Generic;
using ElevatorSystem.Core;
using ElevatorSystem.Controllers;
using ElevatorSystem.Requests;
using ElevatorSystem.Strategies;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Elevator System Simulation ===\n");

        // Create building with 10 floors
        var building = new Building(10);
        Console.WriteLine($"Building created with {building.TotalFloors} floors");

        // Create 3 elevators
        var elevators = new List<Elevator>
        {
            new Elevator(),
            new Elevator(),
            new Elevator()
        };
        Console.WriteLine($"Created {elevators.Count} elevators");

        // Create strategies
        var moveStrategy = new SimpleElevatorMoveStrategy();
        var schedulerStrategy = new FifoElevatorSchedulerStrategy();

        // Create controller
        var controller = new ElevatorController(elevators, building, moveStrategy, schedulerStrategy);
        Console.WriteLine("Elevator controller initialized\n");

        // Simulate elevator requests
        Console.WriteLine("--- Simulation Starting ---");
        
        // Request 1: From floor 0 to floor 5
        Console.WriteLine("Request: Floor 0 -> Floor 5");
        controller.AddRequest(new ElevatorRequest(0, 5));
        controller.ProcessRequests();
        DisplayElevatorStatus(elevators);

        // Request 2: From floor 3 to floor 8
        Console.WriteLine("Request: Floor 3 -> Floor 8");
        controller.AddRequest(new FloorRequest(3, 8));
        controller.ProcessRequests();
        DisplayElevatorStatus(elevators);

        // Request 3: From floor 7 to floor 1
        Console.WriteLine("Request: Floor 7 -> Floor 1");
        controller.AddRequest(new ElevatorRequest(7, 1));
        controller.ProcessRequests();
        DisplayElevatorStatus(elevators);

        // Request 4: Multiple requests
        Console.WriteLine("Multiple requests:");
        controller.AddRequest(new ElevatorRequest(2, 6));
        controller.AddRequest(new FloorRequest(9, 4));
        controller.AddRequest(new ElevatorRequest(1, 9));
        controller.ProcessRequests();
        DisplayElevatorStatus(elevators);

        Console.WriteLine("\n--- Simulation Complete ---");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static void DisplayElevatorStatus(List<Elevator> elevators)
    {
        Console.WriteLine("Elevator Status:");
        for (int i = 0; i < elevators.Count; i++)
        {
            var elevator = elevators[i];
            Console.WriteLine($"  Elevator {i + 1}: Floor {elevator.CurrentFloor}, State: {elevator.State}");
        }
        Console.WriteLine();
    }
}
