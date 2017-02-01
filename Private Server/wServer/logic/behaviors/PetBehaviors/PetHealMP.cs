
using System;
using System.Linq;
using wServer.networking.svrPackets;
using wServer.realm;
using wServer.realm.entities;
using wServer.realm.entities.player;

namespace wServer.logic.behaviors.PetBehaviors
{
    internal class PetHealMP : Behavior
    {
        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 1000;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            int cool = (int)state;

            if (cool <= 0)
            {
                if (!(host is Pet)) return;
                Pet pet = host as Pet;
                if (pet.PlayerOwner == null) return;
                Player player = host.GetEntity(pet.PlayerOwner.Id) as Player;
                if (player == null) return;

                if (player != null)
                {
                    int maxMp = player.Stats[1] + player.Boost[1];
                    int h = GetMP(pet, ref cool);
                    if (h == -1) return;
                    int newMp = Math.Min(player.MaxMp, player.Mp + h);
                    if (newMp != player.Mp)
                    {
                        int n = newMp - player.Mp;
                        if (player.HasConditionEffect(ConditionEffectIndex.Quiet))
                        {
                            player.Owner.BroadcastPacket(new ShowEffectPacket
                            {
                                EffectType = EffectType.Trail,
                                TargetId = host.Id,
                                PosA = new Position { X = player.X, Y = player.Y },
                                Color = new ARGB(0xffffffff)
                            }, null);
                            player.Owner.BroadcastPacket(new NotificationPacket
                            {
                                ObjectId = player.Id,
                                Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"No Effect\"}}",
                                Color = new ARGB(0xFF0000)
                            }, null);
                            cool = 1000;
                            state = cool;
                            return;
                        }
                        player.Mp = newMp;
                        player.UpdateCount++;
                        player.Owner.BroadcastPacket(new ShowEffectPacket
                        {
                            EffectType = EffectType.Trail,
                            TargetId = host.Id,
                            PosA = new Position { X = player.X, Y = player.Y },
                            Color = new ARGB(0xffffffff)
                        }, null);
                        player.Owner.BroadcastPacket(new ShowEffectPacket
                        {
                            EffectType = EffectType.Potion,
                            TargetId = player.Id,
                            Color = new ARGB(0x6084e0)
                        }, null);
                        player.Owner.BroadcastPacket(new NotificationPacket
                        {
                            ObjectId = player.Id,
                            Text = "{\"key\":\"blank\",\"tokens\":{\"data\":\"+" + n + "\"}}",
                            Color = new ARGB(0x6084e0)
                        }, null);
                    }
                }
            }
            else
                cool -= time.thisTickTimes;

            state = cool;
        }

        private int GetMP(Pet host, ref int cooldown)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (host.FirstPetLevel.Ability == Ability.MagicHeal)
                        {
                            return CalculateMagicHeal(host.FirstPetLevel.Level, ref cooldown);
                        }
                        break;

                    case 1:
                        if (host.SecondPetLevel.Ability == Ability.MagicHeal)
                        {
                            return CalculateMagicHeal(host.SecondPetLevel.Level, ref cooldown);
                        }
                        break;

                    case 2:
                        if (host.ThirdPetLevel.Ability == Ability.MagicHeal)
                        {
                            return CalculateMagicHeal(host.ThirdPetLevel.Level, ref cooldown);
                        }
                        break;

                    default:
                        break;
                }
            }
            return -1;
        }

        private int CalculateMagicHeal(int level, ref int cooldown)
        {
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
            return (int)Math.Round(0.0000003111287813272 * Math.Pow(level, 4) - 0.0000256213162692859 * Math.Pow(level, 3) + 0.00444679769799348 * Math.Pow(level, 2) - 0.0623195688424998 * level + 1.14636993462723);
            throw new Exception("PetLevel not supported");
        }
    }
}

