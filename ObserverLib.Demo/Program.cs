using System;
using System.Threading;
using ObserverLib.Observer;

namespace ObserverLib.Demo
{
    class Program
    {
        static void Main()
        {
            var observer = new SpinObserver();

            for (int i = 0; i < 3; i++)
            {
                int id = i;
                new Thread(() =>
                {
                    int lastSeen = observer.Version;
                    Console.WriteLine($"Observer {id} wartet...");
                    observer.WaitForNext(lastSeen);
                    Console.WriteLine($"Observer {id} wurde geweckt!");
                }).Start();
            }

            Thread.Sleep(1000);
            Console.WriteLine("Notifier: Zustand ändert sich jetzt.");
            observer.NotifyAll();

            Thread.Sleep(500);
        }
    }
}