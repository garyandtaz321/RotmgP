#region

using wServer.networking;

#endregion

namespace wServer.realm.worlds
{
    public class OryxsChamber : World
    {
        public OryxsChamber()
        {
            Name = "Oryx's Chamber";
            ClientWorldName = "Oryx's Chamber";
            Background = 0;
            AllowTeleport = true;
        }

        protected override void Init()
        {
            LoadMap("wServer.realm.worlds.maps.oryxchamber.jm", MapType.Json);
        }

        public override World GetInstance(Client psr)
        {
            return Manager.AddWorld(new OryxsChamber());
        }
    }
}