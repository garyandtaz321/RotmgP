﻿namespace wServer.realm.worlds
{
    public class TheInnerSanctum : World
    {
        public TheInnerSanctum()
        {
            Name = "The Inner Sanctum";
            ClientWorldName = "{dungeons.The_Inner_Sanctum}";
            Background = 0;
            Difficulty = 5;
            ShowDisplays = true;
            AllowTeleport = true;
        }

        public override bool NeedsPortalKey => true;

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.innersanctum.wmap", MapType.Wmap);
        }
    }
}
