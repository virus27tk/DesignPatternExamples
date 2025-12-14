using System;
using ParkingLot.Interfaces;

namespace ParkingLot.Strategies
{
    public class BikePaymentStrategy : IPaymentStrategy
    {
        public decimal CalculateFee(DateTime entryTime, DateTime exitTime)
        {
            TimeSpan duration = exitTime - entryTime;
            return (decimal)(duration.TotalHours * 1); // $1 per hour
        }
    }
}