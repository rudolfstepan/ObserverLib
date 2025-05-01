using System.Threading;
using ObserverLib.Observer;
using Xunit;

namespace ObserverLib.Tests
{
    public class SpinObserverTests
    {
        [Fact]
        public void Observer_IsNotified_WhenVersionChanges()
        {
            var obs = new SpinObserver();
            int initial = obs.Version;

            var wasNotified = false;

            var thread = new Thread(() =>
            {
                obs.WaitForNext(initial);
                wasNotified = true;
            });

            thread.Start();
            Thread.Sleep(100); // give time to block
            obs.NotifyAll();
            thread.Join();

            Assert.True(wasNotified);
        }
    }
}