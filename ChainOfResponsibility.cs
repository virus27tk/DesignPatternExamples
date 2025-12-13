
namespace NewConsoleApp.Patterns
{
    public class LeaveRequest
    {
        public string EmployeeName { get; set; }
        public int NumberOfDays { get; set; }
        public string Reason { get; set; }

        public LeaveRequest(string employeeName, int numberOfDays, string reason)
        {
            EmployeeName = employeeName;
            NumberOfDays = numberOfDays;
            Reason = reason;
        }
    }

    public interface IHandler
    {
        void HandleRequest(LeaveRequest request);
    }

    public class EmployeeHandler : IHandler
    {
        private readonly IHandler _nextHandler;

        public EmployeeHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(LeaveRequest request)
        {
            if (request.NumberOfDays == 1)
            {
                Console.WriteLine($"EMPLOYEE approved {request.NumberOfDays} day(s) leave for {request.EmployeeName}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    public class ManagerHandler : IHandler
    {
        private readonly IHandler _nextHandler;

        public ManagerHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(LeaveRequest request)
        {
            if (request.NumberOfDays > 1 && request.NumberOfDays <= 2)
            {
                Console.WriteLine($"MANAGER approved {request.NumberOfDays} day(s) leave for {request.EmployeeName}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    public class DirectorHandler : IHandler
    {
        private readonly IHandler _nextHandler;

        public DirectorHandler(IHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(LeaveRequest request)
        {
            if (request.NumberOfDays <= 5)
            {
                Console.WriteLine($"DIRECTOR approved {request.NumberOfDays} day(s) leave for {request.EmployeeName}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }

    public class DefaultHandler : IHandler
    {
        public DefaultHandler() {}

        public void HandleRequest(LeaveRequest request)
        {
            Console.WriteLine($"MAX Leave Exceeded for {request.EmployeeName}. Cannot approve {request.NumberOfDays} day(s) leave.");
        }
    }

	public class ChainOfResponsibilityService
	{
        public void Execute()
        {
            IHandler defaultHandler = new DefaultHandler();
            IHandler directorHandler = new DirectorHandler(defaultHandler);
            IHandler managerHandler = new ManagerHandler(directorHandler);
            IHandler employeeHandler = new EmployeeHandler(managerHandler);
            
            // Creating leave requests
            LeaveRequest request1 = new LeaveRequest("Alice", 1, "Personal Work");
            LeaveRequest request2 = new LeaveRequest("Bob", 3, "Medical Leave");
            LeaveRequest request3 = new LeaveRequest("Charlie", 6, "Vacation");
            LeaveRequest request4 = new LeaveRequest("David", 1, "Emergency");

            // Processing leave requests
            employeeHandler.HandleRequest(request1);
            employeeHandler.HandleRequest(request2);
            employeeHandler.HandleRequest(request3);
            employeeHandler.HandleRequest(request4);
        }
	}
}
