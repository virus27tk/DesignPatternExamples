# 🚗 Parking Lot Management System

A comprehensive .NET Console Application for managing a multi-floor parking lot system using design patterns and clean architecture principles.

## 📋 Table of Contents
- [Overview](#overview)
- [UML Diagram](#uml-diagram)
- [Project Structure](#project-structure)
- [Design Patterns Used](#design-patterns-used)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Architecture](#architecture)

## 🎯 Overview

This parking lot management system demonstrates the implementation of multiple design patterns including:
- **Strategy Pattern** for payment calculations
- **Factory Pattern** for creating payment strategies
- **Service Pattern** for business logic separation
- **Interface Segregation** for loose coupling

## 📊 UML Diagram

![UML Class Diagram](IMG_1867.png)

The UML class diagram above illustrates the relationships between all components in the parking lot management system, showing how the various design patterns are implemented and how the classes interact with each other.

## 📁 Project Structure

```
ParkingLot/
│
├── 📁 Enums/
│   ├── SpotStatus.cs          # Free/Occupied status enumeration
│   └── VehicleType.cs         # Bike/Car/Truck type enumeration
│
├── 📁 Models/
│   ├── Spot.cs                # Individual parking spot entity
│   ├── Vehicle.cs             # Vehicle information model
│   ├── Ticket.cs              # Parking ticket details
│   ├── Floor.cs               # Floor with collection of spots
│   └── ParkingLotModel.cs     # Main parking lot container
│
├── 📁 Interfaces/
│   ├── IPaymentStrategy.cs    # Payment calculation contract
│   ├── IParkingLotService.cs  # Parking operations contract
│   └── ITicketService.cs      # Ticket management contract
│
├── 📁 Services/
│   ├── ParkingLotService.cs   # Core parking lot operations
│   └── TicketService.cs       # Ticket generation & management
│
├── 📁 Strategies/
│   ├── BikePaymentStrategy.cs # $1/hour payment calculation
│   ├── CarPaymentStrategy.cs  # $2/hour payment calculation
│   └── TruckPaymentStrategy.cs# $3/hour payment calculation
│
├── 📁 Factories/
│   └── PaymentStrategyFactory.cs # Creates appropriate payment strategies
│
├── Program.cs                 # Application entry point & user interface
├── ParkingLot.csproj         # Project configuration
└── README.md                 # This file
```

## 🎨 Design Patterns Used

### 1. **Strategy Pattern**
- **Location:** `Strategies/` folder
- **Purpose:** Different payment calculation algorithms for different vehicle types
- **Implementation:** `IPaymentStrategy` interface with concrete implementations

### 2. **Factory Pattern**
- **Location:** `Factories/PaymentStrategyFactory.cs`
- **Purpose:** Creates appropriate payment strategy based on vehicle type
- **Benefits:** Encapsulates object creation logic

### 3. **Service Pattern**
- **Location:** `Services/` folder
- **Purpose:** Separates business logic from models and UI
- **Components:** `ParkingLotService`, `TicketService`

### 4. **Dependency Injection**
- **Implementation:** Constructor injection in services
- **Benefits:** Loose coupling, easier testing

## ✨ Features

- 🏢 **Multi-floor parking lot** with configurable capacity
- 🚲 **Multiple vehicle types** (Bike, Car, Truck)
- 💰 **Dynamic pricing** based on vehicle type and duration
- 🎫 **Ticket generation** with unique IDs
- 📊 **Real-time status** display of all floors and spots
- ⚡ **Efficient spot allocation** algorithm
- 🎯 **Clean separation** of concerns

## 🚀 Getting Started

### Prerequisites
- [.NET 9.0 SDK or later](https://dotnet.microsoft.com/download)
- Any IDE (Visual Studio, VS Code, or command line)

### Build and Run

1. **Clone the repository:**
   ```bash
   git clone <your-repository-url>
   cd ParkingLot
   ```

2. **Build the project:**
   ```bash
   dotnet build
   ```

3. **Run the application:**
   ```bash
   dotnet run
   ```

## 🎮 Usage

### Menu Options

1. **Park Vehicle**
   - Enter vehicle type (Bike, Car, or Truck)
   - System finds available spot and generates ticket

2. **Remove Vehicle**
   - Enter ticket ID
   - System calculates fee and frees the spot

3. **Show Status**
   - Displays all floors with spot availability

4. **Exit**
   - Terminates the application

### Example Workflow

```
=== Parking Lot System ===
Enter parking lot capacity: 3

Menu:
1. Park Vehicle
2. Remove Vehicle  
3. Show Status
4. Exit
Choose an option: 1
Car
Vehicle parked successfully. Ticket Number: 1234

Choose an option: 3
Floor 1:
  Spot 5539 (Bike): Free
  Spot 1634 (Car): Occupied
  ...
```

## 🏗️ Architecture

### Namespace Organization
- `ParkingLot.Models` - Data entities and domain models
- `ParkingLot.Services` - Business logic and operations
- `ParkingLot.Interfaces` - Contracts and abstractions
- `ParkingLot.Strategies` - Algorithm implementations
- `ParkingLot.Factories` - Object creation patterns
- `ParkingLot.Enums` - Type definitions

### Key Principles Applied
- **Single Responsibility Principle** - Each class has one reason to change
- **Open/Closed Principle** - Easy to extend without modifying existing code
- **Interface Segregation** - Clients depend on abstractions
- **Dependency Inversion** - High-level modules don't depend on low-level details

## 🔧 Extending the System

### Adding New Vehicle Types
1. Add new enum value in `VehicleType.cs`
2. Create new payment strategy in `Strategies/`
3. Update `PaymentStrategyFactory.cs`

### Adding New Features
1. Define interface in `Interfaces/`
2. Implement service in `Services/`
3. Update `Program.cs` for user interaction
