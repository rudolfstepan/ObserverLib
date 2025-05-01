using System;
using System.Threading;

using ObserverLib.Interop;

namespace ObserverLib.Observer
{
    public class MemoryObserver
    {
        private int _state;

        private const uint INFINITE = 0xFFFFFFFF;

        public int State
        {
            get => Volatile.Read(ref _state);
            set
            {
                Volatile.Write(ref _state, value);
                NativeInterop.WakeByAddressAll(ref _state);
            }
        }

        public bool WaitForChange(int lastSeenValue, uint timeoutMs = INFINITE)
        {
            int compare = lastSeenValue;
            return NativeInterop.WaitOnAddress(ref _state, ref compare, new IntPtr(sizeof(int)), timeoutMs);
        }
    }
}
