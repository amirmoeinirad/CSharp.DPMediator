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
    }

    ///////////////////////////////////////////

    // Concrete mediator
    public class ChatRoom : IChatMediator
    {
        public void Send(string message, User user)
        {
            Console.WriteLine($"{user.Name}: {message}");
        }
    }

    ///////////////////////////////////////////

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
            Console.WriteLine("In User object...");
            Console.WriteLine("Sending a message via a mediator...");
            _mediator.Send(message, this);
        }
    }

    ///////////////////////////////////////////

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("The Mediator Design Pattern in C#.NET.");
            Console.WriteLine("--------------------------------------\n");

            var chat = new ChatRoom();

            var user = new User("Amir", chat);
            user.Send("Hello from the Mediator pattern!");

            Console.WriteLine("\nDone.");
        }
    }
}
