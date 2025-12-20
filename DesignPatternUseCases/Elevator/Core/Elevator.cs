using System;

namespace ElevatorSystem.Core
{
    public enum ElevatorState
    {
        Up,
        Down,
        Idle
    }

    public class Elevator
    {
        public int id {get; private set; }
        public int CurrentFloor { get; private set; }
        public ElevatorState State { get; private set; }

        public Elevator()
        {
            id = new Random().Next(1,1000);
            CurrentFloor = 0;
            State = ElevatorState.Idle;
        }

        public ElevatorState GetCurrentState()
        {
            return State;
        }
        
        public void SetState(ElevatorState state)
        {
            State = state;
        }
        
        public void MoveToFloor(int floorNumber)
        {
            CurrentFloor = floorNumber;
        }
    }
}