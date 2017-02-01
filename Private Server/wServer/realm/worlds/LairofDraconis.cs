using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wServer.realm.worlds
{
    public class LairofDraconis : World
    {
        public LairofDraconis()
        {
            Name = "Lair of Draconis";
            ClientWorldName = "Lair of Draconis";
            Background = 0;
            Difficulty = 4;
            AllowTeleport = false;
        }

        public override bool NeedsPortalKey => true;

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.LoD.jm", MapType.Json);
        }
    }
}
