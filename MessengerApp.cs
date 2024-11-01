// Summary of the 5 SOLID programming principles.

// Single Responsibility Principle (S).
// Each class has a single responsibility, making the code easier to maintain and understand.

// Open Closed Principle (O).
// Messenger is open for extension (ExtendedMessenger and InjectedMessenger) but closed for modification.

// Liskov Substitution Principle (L).
// DerivedMessenger can replace Messenger without altering the correctness of the program.

// Interface Segregation Principle (I).
// IMessenger, INotifier, IAlerter keep interfaces focused on specific needs.

// Dependency Inversion Principle (D).
// InjectedMessenger depends on the INotifier abstraction, not a concrete class, ensuring a decoupled architecture.

using System;

namespace MessengerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example of Single Responsiblity Princple");
            IMessenger messenger = new Messenger();
            messenger.SendMessage("Test");
            Console.WriteLine("");

            Console.WriteLine("Example of Open Closed Princple");
            messenger = new ExtendedMessenger();
            messenger.SendMessage("Test");
            Console.WriteLine("");

            Console.WriteLine("Example of Liskov Substitution Princple");
            messenger = new DerivedMessenger();
            messenger.SendMessage("Test");
            Console.WriteLine("");

            Console.WriteLine("Example of Interface Segregation Princple");
            INotifier notifier = new Notifier();
            notifier.Notify();
            Console.WriteLine("");

            Console.WriteLine("Example of Dependency Inversion Princple");
            INotifier testNotifier = new TestNotifier();
            messenger = new InjectedMessenger(testNotifier);
            messenger.SendMessage("Test");
            Console.WriteLine("");
        }
    }

    interface IMessenger
    {
        void SendMessage(string message);
    }

    // Single Responsibility Principle (S).
    // This principle helps in keeping the software modules small, focused, and understandable. 
    // By ensuring that a class has only one reason to change, it simplifies debugging and maintenance, making it 
    // easier to update specific parts of the application without unintended side effects.

    // Importance
    // 1. Maintainability: When classes have a single, well-defined responsibility, they're easier to understand and modify.
    // 2. Testability: It's easier to write unit tests for classes with a single focus.
    // 3. Flexibility: Changes to one responsibility don't affect unrelated parts of the system.
    class Messenger : IMessenger
    {
        public virtual void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Open Closed Principle (O).
    // This principle promotes software extensibility and stability. By designing modules that are open for 
    // extension but closed for modification, developers can add new functionality without changing the existing codebase, 
    // reducing the risk of introducing bugs and ensuring that existing features remain stable.

    // Importance
    // 1. Extensibility: New features can be added without modifying existing code.
    // 2. Stability: Reduces the risk of introducing bugs when making changes.
    // 3. Flexibility: Adapts to changing requirements more easily.
    class ExtendedMessenger : Messenger
    {
        public override void SendMessage(string message)
        {
            Console.WriteLine($"This is an Extended {message}.");
        }
    }

    // Liskov Substitution Principle (L).
    // This principle is fundamental to the behavior of polymorphic systems. By ensuring that 
    // subclasses can be used interchangeably with their parent classes without altering the correctness of the program, 
    // Liskov substitution promotes reliability and predictability in the software, as new derived classes can be introduced without 
    // disrupting the system’s existing functionality.

    // Importance
    // 1. Polymorphism: Enables the use of polymorphic behavior, making code more flexible and reusable.
    // 2. Reliability: Ensures that subclasses adhere to the contract defined by the superclass.
    // 3. Predictability: Guarantees that replacing a superclass object with a subclass object won't break the program.

    class DerivedMessenger : Messenger
    {
        public override void SendMessage(string message)
        {
            base.SendMessage(message);

            Console.WriteLine($"Here we can add our own functionality, without affecting the existing code.");
        }
    }

    // Interface Segregation Principle (I).
    // This principle ensures that clients are not burdened with methods they do not use. 
    // By splitting large interfaces into smaller, more specific ones, it reduces the dependency of clients on interfaces 
    // they do not need, making the system more modular, easier to understand, and reducing the impact of changes.

    // Importance
    // 1. Decoupling: Reduces dependencies between classes, making the code more modular and maintainable.
    // 2. Flexibility: Allows for more targeted implementations of interfaces.
    // 3. Avoids unnecessary dependencies: Clients don't have to depend on methods they don't use.

    interface INotifier
    {
        void Notify();
    }

    class Notifier : INotifier
    {
        public virtual void Notify()
        {
            Console.WriteLine("Pop!");
        }
    }

    interface IAlerter
    {
        void CreateAlert();
    }

    class Alerter : IAlerter
    {
        public virtual void CreateAlert()
        {
            Console.WriteLine("Alert!");
        }
    }

    // Dependency Inversion Principle (D).
    // This principle encourages a decoupled architecture by ensuring that high-level modules depend on abstractions 
    // rather than on concrete implementations. By reversing the dependency direction, it enhances the flexibility and 
    // maintainability of the system, allowing for easier modifications and testing as different parts of the system 
    // become less interdependent.

    // Importance
    // 1. Loose coupling: Reduces dependencies between modules, making the code more flexible and easier to test.
    // 2. Flexibility: Enables changes to implementations without affecting clients.
    // 3. Maintainability: Makes code easier to understand and modify.

    class TestNotifier : Notifier
    {
        public override void Notify()
        {
            var startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine($"Notify started at {startTime}.");

            base.Notify();

            var endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine($"Notify finished at {endTime}.");

        }
    }

    class InjectedMessenger : Messenger
    {
        private readonly INotifier notifier;

        public InjectedMessenger(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public override void SendMessage(string message)
        {
            base.SendMessage(message);

            notifier.Notify();
        }

    }

}
