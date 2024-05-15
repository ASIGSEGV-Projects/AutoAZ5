using System.Linq;
using PluginAPI.Core;
using Player = Exiled.API.Features.Player;

namespace AutoAZ5.Package
{
    public class AutoWarhead
    {
        public static bool isAZ5Detonation = false;
        private static bool shouldContinue()
        {
            return !Warhead.IsDetonated && Round.IsRoundStarted && !Round.IsRoundEnded;
        }
        
        public static void PlayCassieWarning(Config config)
        {
            if (!shouldContinue()) return; // Warhead doesn't meet criteria to detonate.
            if(config.AutoWarheadWarningCassieOverrides) Cassie.Clear();
            if (config.AutoWarheadWarningCassie.IsEmpty())
            {
                // user doesn't want a warning
                EngageAW(config);
                return;
            }
            float Duration = Exiled.API.Features.Cassie.CalculateDuration(config.AutoWarheadWarningCassie) + config.CassieWarningDelay;
            Exiled.API.Features.Cassie.MessageTranslated(
                config.AutoWarheadWarningCassie, 
                config.AutoWarheadWarningCassieSubtitles.IsEmpty() ? "" : config.AutoWarheadWarningCassieSubtitles, 
                true // always true no matter what????
            );
            Utility.RoundCallDelayed(Duration, () => EngageAW(config));
        }

        private static void EngageAW(Config config)
        {
            if (!shouldContinue()) return; // Warhead doesn't meet criteria to detonate.
            Warhead.IsLocked = false;
            if (!Warhead.IsDetonationInProgress){ Warhead.Start(); isAZ5Detonation = true; } // Start if not already in detonation (will get locked anyway)
            Warhead.IsLocked = true;
            // Broadcast
            if (!config.WarningText.IsEmpty())
            {
                Player.List.ToList().ForEach(p => 
                    p.Broadcast((ushort)config.WarningDuration, config.WarningText, Broadcast.BroadcastFlags.Normal, true)
                );
            }
        }
    }
}