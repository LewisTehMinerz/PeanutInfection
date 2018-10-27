﻿using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Timers;

namespace PeanutInfection
{
    partial class EventHandler : IEventHandlerPlayerDie
    {
        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (GamemodeManager.GamemodeManager.GetCurrentMode().Equals(plugin))
            {
                if (ev.Killer.TeamRole.Role == Role.SCP_173)
                {
                    ev.SpawnRagdoll = false;
                    var deathPos = ev.Player.GetPosition();

                    var respawnTimer = new Timer
                    {
                        AutoReset = false,
                        Enabled = true,
                        Interval = 1000
                    };

                    respawnTimer.Elapsed += delegate
                    {
                        ev.Player.ChangeRole(Role.SCP_173);
                        ev.Player.Teleport(deathPos);
                    };
                }
            }
        }
    }
}
