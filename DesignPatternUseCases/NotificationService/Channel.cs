using System;

namespace NotificationService
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void NotifyAll(INotification notification);
        void GetNotification(INotification notification);
    }

    public class Channel : IObservable
    {
        public List<IObserver> observers { get; set; }

        public Channel()
        {
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyAll(INotification notification)
        {
            foreach (var observer in observers)
            {
                observer.Update(notification);
            }
        }

        public void GetNotification(INotification notification)
        {
            var text = notification.GetContent();
            Console.WriteLine("Channel received notification: " + text);
            NotifyAll(notification);
        }
    }

    public interface IObserver
    {
        void Update(INotification notification);
    }

    public class Subscriber : IObserver
    {
        private string _name;
        private INotificationStrategy _notificationStrategy;
        public Subscriber(string name, INotificationStrategy notificationStrategy)
        {
            _name = name;
            _notificationStrategy = notificationStrategy;
        }
        public void Update(INotification notification)
        {
            _notificationStrategy?.DisplayNotification(notification, _name);
        }
    }

    public interface INotificationStrategy
    {
        void DisplayNotification(INotification notification, string subscriberName);
    }

    public class EmailNotificationStrategy : INotificationStrategy
    {
        public void DisplayNotification(INotification notification, string subscriberName)
        {
            var text = notification.GetContent();
            Console.WriteLine("Email Notification for " + subscriberName + ": " + text);
        }
    }

    public class SmsNotificationStrategy : INotificationStrategy
    {
        public void DisplayNotification(INotification notification, string subscriberName)
        {
            var text = notification.GetContent();
            Console.WriteLine("SMS Notification for " + subscriberName + ": " + text);
        }
    }

    public class NotificationService
    {
        public List<IObservable> observables  {get; set; }

        public NotificationService()
        {
            observables = new List<IObservable>();
        }

        public void AddObservable(IObservable observable)
        {
            observables.Add(observable);
        }

        public void SendNotification(INotification notification)
        {
            foreach (var observable in observables)
            {
                observable.GetNotification(notification);
            }
        }
    }
}