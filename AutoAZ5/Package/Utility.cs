using System;
using System.Collections.Generic;
using MEC;

namespace AutoAZ5.Package
{
    public class Utility
    {
        // Timing
        public static List<CoroutineHandle> DestroyOnRoundEnd = new List<CoroutineHandle>();
        public static void RoundCallDelayed(float delay, Action action)
        {
            DestroyOnRoundEnd.Add(Timing.CallDelayed(delay,action));
        }
    }
}