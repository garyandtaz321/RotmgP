using System;
using System.Linq;
using wServer.networking.svrPackets;
using wServer.realm;
using wServer.realm.entities;

namespace wServer.logic.behaviors.PetBehaviors
{
    internal class PetElectric : Behavior
    {
        //State storage: cooldown

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = 0;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            if (state == null) return;
            int cool = (int)state;

            if (cool <= 0)
            {
                PetLevel level = null;
                if (host is Pet)
                {
                    Pet p = host as Pet;
                    level = p.GetPetLevelFromAbility(Ability.Electric, true);
                }
                else return;

                if (level == null) return;

                double dist = GetElectricDistance(host as Pet, level);

                Enemy[] targets = host.GetNearestEntities(dist).OfType<Enemy>().ToArray();
                foreach (Enemy e in targets)
                {
                    if (e.HasConditionEffect(ConditionEffectIndex.Invulnerable) || e.HasConditionEffect(ConditionEffectIndex.Invincible) || e.HasConditionEffect(ConditionEffectIndex.Stasis)) continue;
                    if (Random.Next(0, 100) > level.Level) break;

                    if (e.ObjectDesc == null | !e.ObjectDesc.Enemy) continue;

                    if (e.HasConditionEffect(ConditionEffectIndex.Invincible)) continue;

                    e.ApplyConditionEffect(new ConditionEffect
                    {
                        DurationMS = (int)(0.5 + level.Level * 0.035) * 1000, // This is not 100% accurate, but probably as close as production as you can get
                        Effect = ConditionEffectIndex.Paralyzed
                    });

                    e.Owner.BroadcastPacket(new ShowEffectPacket
                    {
                        EffectType = EffectType.ElectricFlashing,
                        PosA = new Position { X = level.Level * 40 }, // Not sure
                        TargetId = e.Id
                    }, null);

                    host.Owner.BroadcastPacket(new ShowEffectPacket
                    {
                        PosA = new Position { X = host.X, Y = host.Y },
                        EffectType = EffectType.ElectricBolts,
                        TargetId = host.Id,
                    }, null);

                    e.Damage(null, time, GetElectricDamage(host as Pet, level), false, new ConditionEffect
                    {
                        DurationMS = (int)(0.5 + level.Level * 0.035) * 1000,
                        Effect = ConditionEffectIndex.Paralyzed
                    });
                }

                cool = GetElectricCooldown(host as Pet, level) / host.Manager.TPS;
            }
            else
                cool -= time.thisTickTimes;

            state = cool;
        }

        private int GetElectricCooldown(Pet host, PetLevel type)
        {
            if (Enumerable.Range(0, 30).Contains(type.Level))
                return (int)(2.5 - type.Level * 0.01666666666666666666666666666667) * 1000;
            else if (Enumerable.Range(30, 20).Contains(type.Level))
                return (int)(2.0 - (type.Level - 30) * 0.025) * 1000;
            else if (Enumerable.Range(50, 20).Contains(type.Level))
                return (int)(1.5 - (type.Level - 50) * 0.025) * 1000;
            else if (Enumerable.Range(70, 20).Contains(type.Level))
                return (int)(1.5 - (type.Level - 70) * 0.025) * 1000;
            else if (Enumerable.Range(90, 11).Contains(type.Level))
                return (int)(0.5 - (type.Level - 90) * 0.04) * 1000;
            throw new Exception("PetLevel not supported");
        }

        private int GetElectricDamage(Pet host, PetLevel type)
        {
            if (Enumerable.Range(0, 30).Contains(type.Level))
                return (int)(5 + type.Level * 0.5);
            else if (Enumerable.Range(30, 20).Contains(type.Level))
                return (int)(20 + (type.Level - 30) * 1.7);
            else if (Enumerable.Range(50, 20).Contains(type.Level))
                return (int)(54 + (type.Level - 50) * 3.15);
            else if (Enumerable.Range(70, 20).Contains(type.Level))
                return (int)(117 + (type.Level - 70) * 5.35);
            else if (Enumerable.Range(90, 11).Contains(type.Level))
                return (int)(224 + (type.Level - 90) * 7.6);
            throw new Exception("PetLevel not supported");
        }

        private double GetElectricDistance(Pet host, PetLevel type)
        {
            if (Enumerable.Range(0, 30).Contains(type.Level))
                return Math.Round(0.1 + type.Level * 0.01333333333333333333333333333333, 2);
            if (Enumerable.Range(30, 20).Contains(type.Level))
                return Math.Round(0.5 + (type.Level - 30) * 0.025, 2);
            if (Enumerable.Range(5, 20).Contains(type.Level))
                return Math.Round(1.0 + (type.Level - 50) * 0.025, 2);
            if (Enumerable.Range(70, 20).Contains(type.Level))
                return Math.Round(1.5 + (type.Level - 70) * 0.025, 2);
            if (Enumerable.Range(90, 11).Contains(type.Level))
                return Math.Round(2.0 + (type.Level - 90) * 0.025, 2);
            throw new Exception("PetLevel not supported");
        }
    }
}