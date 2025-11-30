namespace InvoiceApp.DesignPatterns
{
    public interface ISubject
    {
        string Attach(IObserver observer);

        void Detach(string token);

        void Notify(string message);
    }

    public interface IObserver
    {
        void Update(string message);
    }

    public class VlogYouTubeChannel : ISubject
    {
        private Dictionary<string, IObserver> _observerTokens = new Dictionary<string, IObserver>();
        private readonly object _lock = new object();

        public VlogYouTubeChannel()
        {
        }

        public string Attach(IObserver observer)
        {
            if (_observerTokens.ContainsValue(observer))
            {
                return string.Empty;
            }

            lock (_lock)
            {
                var token = Guid.NewGuid().ToString();
                _observerTokens.Add(token, observer);
                return token;
            }
        }

        public void Detach(string token)
        {
            if (!_observerTokens.ContainsKey(token))
            {
                return;
            }
            
            lock (_lock)
            {
                var observer = _observerTokens[token];
                _observerTokens.Remove(token);
            }
        }

        public void Notify(string message)
        {
            List<IObserver> copyObservers;
            lock (_lock)
            {
                copyObservers = _observerTokens.Values.ToList();
            }
            
            foreach (var observer in copyObservers)
            {
                try
                {
                    observer.Update(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error notifying observer: {ex.Message}");
                    
                }
            }
        }

        public void UploadVideo(string videoTitle)
        {
            Console.WriteLine($"New video uploaded: {videoTitle}");
            Notify(videoTitle);
        }
    }
    public class NewsYouTubeChannel : ISubject
    {
        private Dictionary<string, IObserver> _observerTokens = new Dictionary<string, IObserver>();

        public NewsYouTubeChannel()
        {
        }

        public string Attach(IObserver observer)
        {
            if (_observerTokens.ContainsValue(observer))
            {
                return string.Empty;
            }

            var token = Guid.NewGuid().ToString();
            _observerTokens.Add(token, observer);
            return token;
        }

        public void Detach(string token)
        {
            if (!_observerTokens.ContainsKey(token))
            {
                return;
            };

            var observer = _observerTokens[token];
            _observerTokens.Remove(token);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observerTokens.Values)
            {
                try
                {
                    observer.Update(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error notifying observer: {ex.Message}");
                    
                }
            }
        }

        public void UploadVideo(string videoTitle)
        {
            Console.WriteLine($"New video uploaded: {videoTitle}");
            Notify(videoTitle);
        }
    }

    public class Subscriber : IObserver
    {
        public string Name { get; }

        public Subscriber(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{Name} received notification: New video titled '{message}' has been uploaded.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var newschannel = new NewsYouTubeChannel();
            var subscriber1 = new Subscriber("Alice");
            var subscriber2 = new Subscriber("Bob");

            var subscriptionToken1 = newschannel.Attach(subscriber1);
            var subscriptionToken2 = newschannel.Attach(subscriber2);

            newschannel.UploadVideo("Design Patterns in C# - Observer Pattern");

            newschannel.Detach(subscriptionToken1);

            newschannel.UploadVideo("Design Patterns in C# - Strategy Pattern");

            newschannel.Detach(subscriptionToken2);

            var VlogYouTubeChannel = new VlogYouTubeChannel();
            var subscriber3 = new Subscriber("Charlie");

            var token3 = VlogYouTubeChannel.Attach(subscriber3);
            VlogYouTubeChannel.UploadVideo("My Daily Vlog - Episode 1");
            VlogYouTubeChannel.Detach(token3);
        }
    }
}

