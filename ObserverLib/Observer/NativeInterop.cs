using System;
using System.Runtime.InteropServices;

namespace ObserverLib.Interop
{
    internal static class NativeInterop
    {
        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern bool WaitOnAddress(
            ref int Address,
            ref int CompareAddress,
            IntPtr AddressSize,
            uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern void WakeByAddressAll(ref int Address);
    }
}
