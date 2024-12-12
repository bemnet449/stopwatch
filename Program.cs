using System;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        // Event Handlers
        stopwatch.OnStarted += message => Console.WriteLine(message);
        stopwatch.OnStopped += message => Console.WriteLine(message);
        stopwatch.OnReset += message => Console.WriteLine(message);

        Console.WriteLine("Console Stopwatch Application");
        Console.WriteLine("Press 'S' to Start, 'T' to Stop, 'R' to Reset, 'Q' to Quit.");

        bool running = true;
        while (running)
        {
            Console.Write("\nYour choice: ");
            string input = Console.ReadLine()?.ToUpper();

            switch (input)
            {
                case "S":
                    stopwatch.Start();
                    break;

                case "T":
                    stopwatch.Stop();
                    break;

                case "R":
                    stopwatch.Reset();
                    break;

                case "Q":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please press 'S', 'T', 'R', or 'Q'.");
                    break;
            }

            // Display elapsed time in real time
            Console.WriteLine($"Time Elapsed: {stopwatch.TimeElapsed} seconds");
        }

        Console.WriteLine("Exiting Stopwatch Application...");
    }
}
