﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class HauntedCemeteryGates : World
    {
        public HauntedCemeteryGates()
        {
            Name = "Haunted Cemetery Gates";
            ClientWorldName = "Haunted Cemetery Gates";
            Background = 0;
            Difficulty = 3;
            AllowTeleport = true;
        }

        public override bool NeedsPortalKey => true;

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.HauntedCemeteryGates.jm", MapType.Json);
        }
    }
}
