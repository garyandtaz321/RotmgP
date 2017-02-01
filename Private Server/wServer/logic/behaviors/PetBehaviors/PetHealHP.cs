using System;
using System.Linq;
using wServer.networking.svrPackets;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

namespace wServer.logic.behaviors.PetBehaviors
{
    internal class PetHealHP : PetBehavior
    {
        //<Parameters>
        //   <MaxHeal min = "10" max="90" curve="exp_incr"/>
        //   <Cooldown min = "10" max="1" curve="dim_returns"/>
        //</Parameters>

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 1000;
            base.OnStateEntry(host, time, ref state);
        }

        protected override bool PlayerOwnerRequired => true;

        protected override void TickCore(Pet pet, RealmTime time, ref object state)
        {
            var cool = (int)state;
            if (cool <= 0)
            {
                Player player = pet.GetEntity(pet.PlayerOwner.Id) as Player;
                if (player == null) return;

                int maxHp = player.Stats[0] + player.Boost[0];
                int h = GetHP(pet, ref cool);
                if (h == -1) return;
                int newHp = Math.Min(maxHp, player.HP + h);
                if (newHp != player.HP)
                {
                    if (player.HasConditionEffect(ConditionEffectIndex.Sick))
                    {
                        player.Owner.BroadcastPacket(new ShowEffectPacket
                        {
                            EffectType = EffectType.Trail,
                            TargetId = pet.Id,
                            PosA = new Position { X = player.X, Y = player.Y },
                            Color = new ARGB(0xffffffff)
                        }, null);
                        player.Owner.BroadcastPacket(new NotificationPacket
                        {
                            ObjectId = player.Id,
                            Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"No Effect\"}}",
                            Color = new ARGB(0xFF0000)
                        }, null);
                        state = cool;
                        return;
                    }
                    int n = newHp - player.HP;
                    player.HP = newHp;
                    player.UpdateCount++;
                    player.Owner.BroadcastPacket(new ShowEffectPacket
                    {
                        EffectType = EffectType.Potion,
                        TargetId = player.Id,
                        Color = new ARGB(0xffffffff)
                    }, null);
                    player.Owner.BroadcastPacket(new ShowEffectPacket
                    {
                        EffectType = EffectType.Trail,
                        TargetId = pet.Id,
                        PosA = new Position { X = player.X, Y = player.Y },
                        Color = new ARGB(0xffffffff)
                    }, null);
                    player.Owner.BroadcastPacket(new NotificationPacket
                    {
                        ObjectId = player.Id,
                        Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"+" + n + "\"}}",
                        Color = new ARGB(0xff00ff00)
                    }, null);
                }
            }
            else
                cool -= time.thisTickTimes;

            state = cool;
        }

        private int GetHP(Pet host, ref int cooldown)
        {
            for (var i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (host.FirstPetLevel.Ability == Ability.Heal)
                        {
                            return CalculateHeal(host.FirstPetLevel.Level, ref cooldown);
                        }
                        break;

                    case 1:
                        if (host.SecondPetLevel.Ability == Ability.Heal)
                        {
                            return CalculateHeal(host.SecondPetLevel.Level, ref cooldown);
                        }
                        break;

                    case 2:
                        if (host.ThirdPetLevel.Ability == Ability.Heal)
                        {
                            return CalculateHeal(host.ThirdPetLevel.Level, ref cooldown);
                        }
                        break;
                }
            }
            return -1;
        }

        private int CalculateHeal(int level, ref int cooldown)
        {
            // Accurate enough for me
            if (Enumerable.Range(0, 30).Contains(level))
                cooldown = (int)Math.Round(10000 - level * 205.96666666666666666666666666667);
            if (Enumerable.Range(30, 20).Contains(level))
                cooldown = (int)Math.Round(3821 - (level - 30) * 58.15);
            if (Enumerable.Range(50, 20).Contains(level))
                cooldown = (int)Math.Round(2658 - (level - 50) * 35.00);
            if (Enumerable.Range(70, 20).Contains(level))
                cooldown = (int)Math.Round(1958 - (level - 70) * 26.9);
            if (Enumerable.Range(90, 11).Contains(level))
                cooldown = (int)Math.Round(1420 - (level - 90) * 42.0);
            return (int)Math.Round(5.83283522976111E-07 * Math.Pow(level, 4) - 0.0000469692310249639 * Math.Pow(level, 3) + 0.0076256636031656 * Math.Pow(level, 2) - 0.0776182463432286 * level + 10.0998122309192);
            throw new Exception("PetLevel not supported");
        }
    }
}
