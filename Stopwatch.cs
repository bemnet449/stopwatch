using System;
using System.Threading;

public class Stopwatch
{
    // Fields
    private int _timeElapsed; // in seconds
    private bool _isRunning;

    // Delegate and Events
    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    // Properties
    public int TimeElapsed => _timeElapsed;
    public bool IsRunning => _isRunning;

    // Methods
    public void Start()
    {
        if (_isRunning)
        {
            Console.WriteLine("Stopwatch is already running.");
            return;
        }

        _isRunning = true;
        OnStarted?.Invoke("Stopwatch Started!");
        StartTicking();
    }

    public void Stop()
    {
        if (!_isRunning)
        {
            Console.WriteLine("Stopwatch is not running.");
            return;
        }

        _isRunning = false;
        OnStopped?.Invoke("Stopwatch Stopped!");
    }

    public void Reset()
    {
        _timeElapsed = 0;
        _isRunning = false;
        OnReset?.Invoke("Stopwatch Reset!");
    }

private void StartTicking()
{
    new Thread(() =>
    {
        while (_isRunning)
        {
            Thread.Sleep(1000); // Simulate a tick every second
            _timeElapsed++;

            // Save current cursor position
            int currentCursorLeft = Console.CursorLeft;
            int currentCursorTop = Console.CursorTop;

            // Set cursor to bottom-left for Time Elapsed display
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine($"Time Elapsed: {_timeElapsed} seconds".PadRight(Console.WindowWidth));

            // Restore cursor position for user input
            Console.SetCursorPosition(currentCursorLeft, currentCursorTop);
        }

        // Clear the "Time Elapsed" line when the stopwatch stops
        int clearCursorLeft = Console.CursorLeft;
        int clearCursorTop = Console.CursorTop;
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.WriteLine("".PadRight(Console.WindowWidth)); // Clear the line
        Console.SetCursorPosition(clearCursorLeft, clearCursorTop);
    }).Start();
}


}
