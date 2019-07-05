namespace BusTracker.Console
{
    using System;
    using System.Threading;
    using BusTracker.Core;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var core = new Core();
            core.Start();

            RunUntilEscape(() =>
            {
                core.Update();
            }, 5000);

            Console.WriteLine("Done!");
        }

        private static void RunUntilEscape(Action action, int threshold)
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    action?.Invoke();
                    Thread.Sleep(threshold);
                    Console.Clear();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
