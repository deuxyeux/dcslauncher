using System;
using System.Runtime.InteropServices;

namespace DCSLauncher
{
    public static class PowerPlan
    {
        private static Guid GUID_BALANCED =
        new Guid("381b4222-f694-41f0-9685-ff5bb260df2e");
        private static Guid GUID_HIGHPERFORMANCE =
        new Guid("8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");

        [DllImport("powrprof.dll")]
        static extern uint PowerGetActiveScheme(
        IntPtr UserRootPowerKey,
        ref IntPtr ActivePolicyGuid);

        [DllImport("powrprof.dll")]
        static extern uint PowerSetActiveScheme(
        IntPtr UserRootPowerKey,
        ref Guid ActivePolicyGuid);

        public static void SetBalancedPowerPlan()
        {
            PowerSetActiveScheme(IntPtr.Zero, ref GUID_BALANCED);
        }
        public static void SetHighPerformancePowerPlan()
        {
            PowerSetActiveScheme(IntPtr.Zero, ref GUID_HIGHPERFORMANCE);
        }
    }
}