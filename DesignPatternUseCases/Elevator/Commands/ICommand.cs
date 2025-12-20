using System.Collections.Generic;
using ElevatorSystem.Core;
using ElevatorSystem.Requests;
using ElevatorSystem.Strategies;

namespace ElevatorSystem.Commands
{
    public interface ICommand
    {
        public void Execute(List<Elevator> elevators, IElevatorMoveStrategy moveStrategy, IElevatorSchedulerStrategy schedulerStrategy);
    }

    public class Command : ICommand
    {
        private readonly IRequest _request;

        public Command(IRequest request)
        {
            _request = request;
        }

        public void Execute(List<Elevator> elevators, IElevatorMoveStrategy moveStrategy, IElevatorSchedulerStrategy schedulerStrategy)
        {
            Elevator selectedElevator = schedulerStrategy.ScheduleElevator(elevators, _request);
            moveStrategy.MoveElevator(selectedElevator, _request.DestinationFloorNumber);
        }
    }
}