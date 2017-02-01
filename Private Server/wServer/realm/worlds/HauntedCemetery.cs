﻿#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class HauntedCemetery : World
    {
        public HauntedCemetery()
        {
            Name = "Haunted Cemetery";
            ClientWorldName = "Haunted Cemetery";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.HauntedCemetery.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new HauntedCemetery());
        }
    }
}