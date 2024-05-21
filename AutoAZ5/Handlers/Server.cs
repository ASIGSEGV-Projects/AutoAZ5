using System.Collections.Generic;
using AutoAZ5.Package;
using Exiled.API.Features;
using MEC;
using Cassie = PluginAPI.Core.Cassie;
using util = AutoAZ5.Package.Utility;
namespace AutoAZ5.Handlers
{
    public class Server
    {
        public void CallOffCoroutines()
        {
            Log.Debug($"Round restarting, killing a total of {util.DestroyOnRoundEnd.Count} coroutine(s).");
            AutoWarhead.isAZ5Detonation = false;
            AutoAZ5.Instance.alphaWarheadExecuted = false;
            Timing.KillCoroutines(util.DestroyOnRoundEnd.ToArray());
            util.DestroyOnRoundEnd = new List<CoroutineHandle>();
        }
        
        public void StartWarheadCount()
        {
            Config config = AutoAZ5.Instance.Config;
            Log.Debug($"Alpha-Warhead countdown for: {config.AutoWarheadDelay} seconds to detonation!");
            util.RoundCallDelayed(config.AutoWarheadDelay, () =>
            {
                // boom boom time
                // Qualifies detonation is checked on method call
                AutoWarhead.PlayCassieWarning(config);
            });
        }

        public void OnDetonation()
        {
            if (!AutoWarhead.isAZ5Detonation) return; // Succesfully Detonated by AZ5
            if(AutoAZ5.Instance.Config.SuccessfulDetonationAnnouncement.IsEmpty()) return; // yas.
            Exiled.API.Features.Cassie.MessageTranslated(
                AutoAZ5.Instance.Config.SuccessfulDetonationAnnouncement,
                AutoAZ5.Instance.Config.SuccessfulDetonationAnnouncementSubtitles.IsEmpty() ? "" : AutoAZ5.Instance.Config.SuccessfulDetonationAnnouncementSubtitles
            );
        }
    }
}
