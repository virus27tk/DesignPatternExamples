using System;

namespace ParkingLot.Interfaces
{
    public interface IPaymentStrategy
    {
        decimal CalculateFee(DateTime entryTime, DateTime exitTime);
    }
}