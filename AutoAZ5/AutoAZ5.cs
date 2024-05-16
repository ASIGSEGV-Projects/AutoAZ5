// See https://aka.ms/new-console-template for more information

using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using Round = PluginAPI.Core.Round;
using Server = Exiled.Events.Handlers.Server;

namespace AutoAZ5
{
    public class AutoAZ5 : Plugin<Config>
    {
        public static AutoAZ5 Instance = null!;
            
        public override string Name => "Auto AZ-5"; // The name of the plugin
        public override string Prefix => "auto_az5"; // Prefix for MyPlugin
        public override string Author => "ASIGSEGV"; // Author name
        public override Version Version => new Version(1, 0, 0); // Plugin version
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 1); // Current Version of MINE

        private Handlers.Server ServerHandler = null!;

        public override void OnEnabled()
        {
            RegisterEvents();
            Instance = this;
            Log.Debug("Done registering events.");
            // EXILED REQ
            base.OnEnabled(); // Call default implementation
        }
        
        public override void OnDisabled()
        {
            UnregisterEvents();
            Log.Debug("Done unregistering events.");
            // EXILED REQ
            base.OnDisabled(); // Call default implementation
        }

        private void RegisterEvents()
        {
            ServerHandler = new Handlers.Server();
            // Register
            Server.RestartingRound += ServerHandler.CallOffCoroutines;
            Server.RoundStarted += ServerHandler.StartWarheadCount;
            Exiled.Events.Handlers.Warhead.Detonated += ServerHandler.OnDetonation;
        }

        private void UnregisterEvents()
        {
            Server.RestartingRound -= ServerHandler.CallOffCoroutines;
            Server.RoundStarted -= ServerHandler.StartWarheadCount;
            Exiled.Events.Handlers.Warhead.Detonated -= ServerHandler.OnDetonation;
        }
    }
}
