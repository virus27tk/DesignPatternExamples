using System;
namespace NotificationService
{
    public interface INotification
    {
        string GetContent();
    }
    
    public class SimpleNotification : INotification
    {
        public string text { get; set; }

        public string GetContent()
        {
            return text;
        }
    }
}


