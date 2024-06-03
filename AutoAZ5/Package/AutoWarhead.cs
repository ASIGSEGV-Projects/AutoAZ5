using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exiled.API.Features;
using MapGeneration;
using MEC;
using PluginAPI.Core;
using UnityEngine;
using Cassie = PluginAPI.Core.Cassie;
using Map = PluginAPI.Core.Map;
using Player = Exiled.API.Features.Player;
using Round = PluginAPI.Core.Round;
using Warhead = PluginAPI.Core.Warhead;

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
            if (AutoAZ5.Instance.alphaWarheadExecuted) return;
            if (!shouldContinue()) return; // Warhead doesn't meet criteria to detonate.
            if(config.AutoWarheadWarningCassieOverrides) Cassie.Clear();
            if (config.AutoWarheadWarningCassie.IsEmpty())
            {
                // user doesn't want a warning
                EngageAW(config);
                return;
            }
            AutoAZ5.Instance.alphaWarheadExecuted = true;
            float Duration = Exiled.API.Features.Cassie.CalculateDuration(config.AutoWarheadWarningCassie) + config.CassieWarningDelay;
            Exiled.API.Features.Cassie.MessageTranslated(
                config.AutoWarheadWarningCassie, 
                config.AutoWarheadWarningCassieSubtitles.IsEmpty() ? "" : config.AutoWarheadWarningCassieSubtitles, 
                true // always true no matter what????
            );
            Timing.RunCoroutine(FlickerLightsToRed());
            Utility.RoundCallDelayed(Duration, () => EngageAW(config));
        }
        static IEnumerator<float> FlickerLightsToRed()
        {
            yield return Timing.WaitForSeconds(5.0f);
            foreach (RoomLightController instance in RoomLightController.Instances)
                instance.ServerFlickerLights(3.5f);
            yield return Timing.WaitForSeconds(3.0f);
            foreach (RoomLightController instance in RoomLightController.Instances)
                instance.NetworkOverrideColor = Color.red;
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