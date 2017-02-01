using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class GrimReapersLair : World
    {
        public GrimReapersLair()
        {
            Name = "Grim Reaper's Lair";
            ClientWorldName = "Grim Reaper's Lair";
            Background = 0;
            Difficulty = 2;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.Reaper.jm", MapType.Json);
        }
    }
}
