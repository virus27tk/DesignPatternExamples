using System;
using ParkingLot.Interfaces;

namespace ParkingLot.Strategies
{
    public class TruckPaymentStrategy : IPaymentStrategy
    {
        public decimal CalculateFee(DateTime entryTime, DateTime exitTime)
        {
            TimeSpan duration = exitTime - entryTime;
            return (decimal)(duration.TotalHours * 3); // $3 per hour
        }
    }
}