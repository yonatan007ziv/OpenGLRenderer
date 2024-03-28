﻿using Microsoft.Extensions.Logging;

namespace GameEngine.Core.SharedServices.Implementations.Loggers;

public class ConsoleLogger : ILogger
{
    private readonly object _lock = new object();

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string message = formatter(state, exception);

        ConsoleColor clr;
        switch (logLevel)
        {
            default:
                clr = ConsoleColor.White;
                break;
            case LogLevel.Trace:
                clr = ConsoleColor.DarkGreen;
                break;
            case LogLevel.Debug:
                clr = ConsoleColor.Cyan;
                break;
            case LogLevel.Information:
                clr = ConsoleColor.Green;
                break;
            case LogLevel.Warning:
                clr = ConsoleColor.Yellow;
                break;
            case LogLevel.Error:
                clr = ConsoleColor.Red;
                break;
            case LogLevel.Critical:
                clr = ConsoleColor.DarkRed;
                break;
            case LogLevel.None:
                clr = ConsoleColor.White;
                break;
        }

        lock (_lock)
        {
            Console.ForegroundColor = clr;
            Console.Write("{0}:", logLevel.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" [{0}] {1}", "*CALLER*", message);
        }
    }
}