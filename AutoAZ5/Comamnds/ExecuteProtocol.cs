using System;
using AutoAZ5.Package;
using CommandSystem;
using GameCore;
using RemoteAdmin;

namespace AutoAZ5.Comamnds
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ExecuteProtocol: ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender player))
            {
                response = "Only a player can execute this command.";
                return false;
            }

            if (!player.CheckPermission(PlayerPermissions.WarheadEvents))
            {
                response = "No permission.";
                return false;
            }
            PluginAPI.Core.Log.Debug($"Player {player.Nickname} has activated az-5 via command");
            AutoWarhead.PlayCassieWarning(AutoAZ5.Instance.Config);
            response = "Activated AZ-5";
            return true;
        }

        public string Command { get; } = "execute_protocol_az5";
        public string[] Aliases { get; } = { "az5","autonuke" };
        public string Description { get; } = "Executes the autonuke early";
    }
}