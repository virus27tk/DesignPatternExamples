using System.Collections.Generic;
using System.Linq;
using ElevatorSystem.Core;
using ElevatorSystem.Requests;

namespace ElevatorSystem.Strategies
{
    public interface IElevatorMoveStrategy
    {
        void MoveElevator(Elevator elevator, int destinationFloor);
    }
    
    public class SimpleElevatorMoveStrategy : IElevatorMoveStrategy
    {
        public void MoveElevator(Elevator elevator, int destinationFloor)
        {
            if (elevator.CurrentFloor < destinationFloor)
            {
                elevator.SetState(ElevatorState.Up);
            }
            else if (elevator.CurrentFloor > destinationFloor)
            {
                elevator.SetState(ElevatorState.Down);
            }
            else
            {
                elevator.SetState(ElevatorState.Idle);
            }

            elevator.MoveToFloor(destinationFloor);
        }
    }

    public class FifoElevatorMoveStrategy : IElevatorMoveStrategy
    {
        public void MoveElevator(Elevator elevator, int destinationFloor)
        {
            if (elevator.CurrentFloor < destinationFloor && elevator.GetCurrentState() != ElevatorState.Down)
            {
                elevator.SetState(ElevatorState.Up);
            }
            else if (elevator.CurrentFloor > destinationFloor && elevator.GetCurrentState() != ElevatorState.Up)
            {
                elevator.SetState(ElevatorState.Down);
            }
            else
            {
                elevator.SetState(ElevatorState.Idle);
            }

            elevator.MoveToFloor(destinationFloor);
        }
    }

    public interface IElevatorSchedulerStrategy
    {
        Elevator ScheduleElevator(List<Elevator> elevators, IRequest request);
    }

    public class SimpleElevatorSchedulerStrategy : IElevatorSchedulerStrategy
    {
        public Elevator ScheduleElevator(List<Elevator> elevators, IRequest request)
        {
            return elevators.First(_ => _.GetCurrentState() == ElevatorState.Idle);
        }
    }

    public class FifoElevatorSchedulerStrategy : IElevatorSchedulerStrategy
    {
        public Elevator ScheduleElevator(List<Elevator> elevators, IRequest request)
        {
            foreach (var elevator in elevators)
            {
                if (elevator.GetCurrentState() == ElevatorState.Idle)
                {
                    return elevator;
                }
                else if (elevator.GetCurrentState() == ElevatorState.Up && request.DestinationFloorNumber > elevator.CurrentFloor)
                {
                    return elevator;
                }
                else if (elevator.GetCurrentState() == ElevatorState.Down && request.DestinationFloorNumber < elevator.CurrentFloor)
                {
                    return elevator;
                }
            }

            return elevators.First();
        }
    }
}