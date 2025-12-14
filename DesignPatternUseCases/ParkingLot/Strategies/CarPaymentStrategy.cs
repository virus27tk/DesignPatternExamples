using System;
using ParkingLot.Interfaces;

namespace ParkingLot.Strategies
{
    public class CarPaymentStrategy : IPaymentStrategy
    {
        public decimal CalculateFee(DateTime entryTime, DateTime exitTime)
        {
            TimeSpan duration = exitTime - entryTime;
            return (decimal)(duration.TotalHours * 2); // $2 per hour
        }
    }
}