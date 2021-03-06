using System;
using System.Reflection;

namespace EvoMp.Module.CommandHandler.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PlayerCommand : Attribute, ICommand
    {
        public PlayerCommand(string command, string[] commandAliases = null,
            PlayerOnlyState playerOnlyState = PlayerOnlyState.Any, int minHealth = 0)
        {
            Command = command;
            PlayerOnlyState = playerOnlyState;
            MinHealth = minHealth;
            CommandAliases = commandAliases ?? new string[] { };
        }

        public int MinHealth { get; }

        public string Command { get; set; }

        public string[] CommandAliases { get; set; }

        public PlayerOnlyState PlayerOnlyState { get; }

        public MethodInfo MethodInfo { get; set; }

        public object ClassInstance { get; set; }

        public string FullName()
        {
            return $"{MethodInfo.DeclaringType?.FullName}.{MethodInfo.Name}";
        }
    }
}
