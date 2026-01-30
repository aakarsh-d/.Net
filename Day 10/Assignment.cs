using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace EnterpriseLogSystem
{
    // ================================
    // SHORT-LIVED OBJECT (Gen 0)
    // ================================
    class LogEntry
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public LogEntry(string message)
        {
            Message = message;
            CreatedAt = DateTime.Now;
        }
    }

    // ================================
    // MEDIUM-LIVED OBJECT (Gen 1)
    // ================================
    class LogCache
    {
        private List<LogEntry> _cache = new List<LogEntry>();

        public void Add(LogEntry entry)
        {
            _cache.Add(entry);
        }

        public void Clear()
        {
            _cache.Clear(); // Makes objects eligible for GC
        }
    }

    // ================================
    // UNMANAGED RESOURCE HANDLER
    // (Finalize + Dispose Pattern)
    // ================================
    class FileLogger : IDisposable
    {
        private StreamWriter _writer;
        private bool disposed = false;

        public FileLogger(string filePath)
        {
            _writer = new StreamWriter(filePath, append: true);
            Console.WriteLine("File resource acquired.");
        }

        public void WriteLog(string message)
        {
            _writer.WriteLine($"{DateTime.Now}: {message}");
        }

        // FINALIZER (Safety Net)
        ~FileLogger()
        {
            Dispose(false);
        }

        // DISPOSE METHOD (Preferred)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Prevent finalizer execution
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Managed resources
                    _writer?.Close();
                    _writer?.Dispose();
                    Console.WriteLine("Managed resources released.");
                }

                // Unmanaged resources (if any)
                Console.WriteLine("Unmanaged resources released.");

                disposed = true;
            }
        }
    }

    // ================================
    // MAIN PROCESSOR
    // ================================
    class LogProcessor
    {
        private LogCache _cache = new LogCache();
        private WeakReference _weakCacheRef;

        public void ProcessLogs()
        {
            Console.WriteLine($"Initial Memory: {GC.GetTotalMemory(false)} bytes");

            // Create many short-lived objects (Gen 0)
            for (int i = 0; i < 10000; i++)
            {
                LogEntry entry = new LogEntry($"Log message {i}");
                _cache.Add(entry);
            }

            Console.WriteLine($"Memory After Log Creation: {GC.GetTotalMemory(false)} bytes");

            // Weak reference to allow GC
            _weakCacheRef = new WeakReference(_cache);

            // Clear cache (objects eligible for GC)
            _cache.Clear();
            _cache = null;

            // Force GC to demonstrate algorithm
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"Memory After GC: {GC.GetTotalMemory(true)} bytes");
            Console.WriteLine($"Is Cache Alive (WeakReference): {_weakCacheRef.IsAlive}");
        }
    }

    // ================================
    // APPLICATION ENTRY POINT
    // ================================
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Enterprise Log Processing System ===");

            // Demonstrate Dispose (Deterministic Cleanup)
            using (FileLogger logger = new FileLogger("app.log"))
            {
                logger.WriteLog("Application started.");
                logger.WriteLog("Processing logs...");
            } // Dispose called automatically here

            Console.WriteLine("FileLogger disposed.");

            // Demonstrate GC Algorithm
            LogProcessor processor = new LogProcessor();
            processor.ProcessLogs();

            // Show Generations
            object obj = new object();
            Console.WriteLine($"Generation of new object: {GC.GetGeneration(obj)}");

            Console.WriteLine("Application execution completed.");
        }
    }
}
