using System;
using ParkingLot.Enums;
using ParkingLot.Interfaces;
using ParkingLot.Strategies;

namespace ParkingLot.Factories
{
    public class PaymentStrategyFactory
    {
        public static IPaymentStrategy GetPaymentStrategy(VehicleType type)
        {
            return type switch
            {
                VehicleType.Bike => new BikePaymentStrategy(),
                VehicleType.Car => new CarPaymentStrategy(),
                VehicleType.Truck => new TruckPaymentStrategy(),
                _ => throw new NotImplementedException()
            };
        }
    }
}