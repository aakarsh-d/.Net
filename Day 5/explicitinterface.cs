
// class ResourceHandler : IDisposable, INotifier
// {
//     void IDisposable.Dispose()
//     {
//         Console.WriteLine("Resource disposed");
//     }
//     void INotifier.Log()
//     {
//         Console.WriteLine("Notification sent");
//     }
// }
// class Program{
// // Accessing via interface references
// public static void Main(string[] args)
// {IDisposable resource = new ResourceHandler();
// resource.Dispose();  // Works

// INotifier notifier = new ResourceHandler();
// notifier.Log();     // Works

// ResourceHandler obj = new ResourceHandler();
// obj.Dispose();      // ERROR: not accessible directly
// obj.Log();     }     // ERROR: not accessible directly
// }