using System;
using NotificationService;

namespace NotificationServiceApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var notification = new SimpleNotification();
			notification.text = "This is a test.";

			var notificationService = new NotificationService.NotificationService();
			var channel = new Channel();
			var subscriber1 = new Subscriber("Srujan1", new EmailNotificationStrategy());
			var subscriber2 = new Subscriber("Srujan2", new SmsNotificationStrategy());
			notificationService.AddObservable(channel);
			channel.AddObserver(subscriber1);
			channel.AddObserver(subscriber2);
			notificationService.SendNotification(notification);
		}
	}
}