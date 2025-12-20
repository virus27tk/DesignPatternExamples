using System.Collections.Generic;
using System.Linq;
using ElevatorSystem.Core;
using ElevatorSystem.Commands;
using ElevatorSystem.Requests;
using ElevatorSystem.Strategies;

namespace ElevatorSystem.Controllers
{
    public class ElevatorController
    {
        private readonly List<Elevator> _elevators;
        private readonly List<Floor> _floors;
        private Queue<ICommand> _elevatorCommands;
        private readonly IElevatorMoveStrategy _moveStrategy;
        private readonly IElevatorSchedulerStrategy _schedulerStrategy;

        public ElevatorController(List<Elevator> elevators, Building building, IElevatorMoveStrategy moveStrategy, IElevatorSchedulerStrategy schedulerStrategy)
        {
            _elevators = elevators;
            _floors = building.Floors;
            _elevatorCommands = new Queue<ICommand>();
            _moveStrategy = moveStrategy;
            _schedulerStrategy = schedulerStrategy;
        }

        public void AddRequest(IRequest request)
        {
            ICommand command = new Command(request);
            _elevatorCommands.Enqueue(command);
        }

        public void ProcessRequests()
        {
            while (_elevatorCommands.Count > 0)
            {
                ICommand command = _elevatorCommands.Dequeue();
                command.Execute(_elevators, _moveStrategy, _schedulerStrategy);
            }
        }

        public List<Elevator> GetElevators()
        {
            return _elevators;
        }
    }
}