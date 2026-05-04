// Amir Moeini Rad
// Dec 2025

// Main Concept: The Mediator Pattern in C#

// In this pattern, a mediator object encapsulates how a set of objects interact.
// This promotes loose coupling by keeping objects from referring to each other explicitly.

namespace MediatorDP
{
    // Mediator interface
    public interface IChatMediator
    {
        void Send(string message, User user);
        void Register(User user);
    }
    

    // Concrete mediator
    public class ChatRoom : IChatMediator
    {
        private readonly List<User> _users = [];

        public void Register(User user)
        {
            _users.Add(user);
        }
        
        public void Send(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                    user.Receive(message);
            }
        }
    }
    

    // Colleague
    public class User
    {
        private readonly IChatMediator _mediator;
        public string Name { get; }

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void Send(string message)
        {            
            Console.WriteLine($"{Name} sends: {message}");
            _mediator.Send(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"{Name} receives: {message}");
        }
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("The Mediator Design Pattern in C#.NET.");
            Console.WriteLine("--------------------------------------\n");

            var chat = new ChatRoom();
            var user1 = new User("Amir", chat);
            var user2 = new User("Arman", chat);
            var user3 = new User("Elham", chat);

            chat.Register(user1);
            chat.Register(user2);
            chat.Register(user3);

            user1.Send("Hello from the Mediator pattern!");

            Console.WriteLine("\nDone.");
        }
    }
}
