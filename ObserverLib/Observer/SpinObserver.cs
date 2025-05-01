using System;
using System.Threading;

namespace ObserverLib.Observer
{
    public class SpinObserver
    {
        private volatile int _version = 0;

        public int Version => Volatile.Read(ref _version);

        public void WaitForNext(int lastSeen)
        {
            var spinner = new SpinWait();
            while (Volatile.Read(ref _version) == lastSeen)
                spinner.SpinOnce();
        }

        public void NotifyAll()
        {
            Interlocked.Increment(ref _version);
        }
    }
}