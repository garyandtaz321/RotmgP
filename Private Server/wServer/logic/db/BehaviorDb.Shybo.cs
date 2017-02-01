using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;
using wServer.logic.behaviors.Drakes;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Shybo = () => Behav()
                    .Init("A Shybo Enemy",
                new State(

                new State("Fight",
                new Wander(.7),
                new Shoot(25, projectileIndex: 0, count: 2, shootAngle: 10, predictive: 0.2, coolDown: 100,
                coolDownOffset: 100)
                    )
                )
            )
            .Init("Shybo",
                new State(
                    new Prioritize(
                    new StayAbove(1, 200)
                    ),
                    new State("Idle",
                    new PlayerWithinTransition(3, "sizing"),
                    new NoPlayerWithinTransition(3, "Idle")
                    ),
                    new State("sizing",
                    new Taunt("its........SHYBO TIME!!!!!!!!!!!!!"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ConditionalEffect(ConditionEffectIndex.Paralyzed),
                    new ConditionalEffect(ConditionEffectIndex.Stunned),
                    new ChangeSize(100, 40),
                    new TimedTransition(500, "xd")
                    ),
                    new State("xd",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ConditionalEffect(ConditionEffectIndex.Paralyzed),
                    new ConditionalEffect(ConditionEffectIndex.Stunned),
                    new ChangeSize(100, 60),
                    new TimedTransition(500, "lmao")
                    ),
                    new State("lmao",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ConditionalEffect(ConditionEffectIndex.Paralyzed),
                    new ConditionalEffect(ConditionEffectIndex.Stunned),
                    new ChangeSize(100, 80),
                    new TimedTransition(500, "lmaoxd")
                    ),
                    new State("lmaoxd",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ConditionalEffect(ConditionEffectIndex.Paralyzed),
                    new ConditionalEffect(ConditionEffectIndex.Stunned),
                    new ChangeSize(100, 100),
                    new TimedTransition(500, "FIGHT")
                    ),
                    new State("FIGHT"),
                    new Wander(1),
                    new Shoot(25, projectileIndex: 0, count: 4, shootAngle: 10, predictive: 0.2, coolDown: 100,
                    coolDownOffset: 100),
                    new Spawn("Shybo Minion", 5, coolDown: 8000)
                    ),
                    new TierLoot(10, ItemType.Weapon, 0.07),
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.06),
                    new Threshold(0.18,
                    new ItemLoot("Kendo Stick", 0.0009)
                  )
            )
            .Init("Shybo Minion",
                new State(
                new EntityNotExistsTransition("Shybo", 50, "Despawn"),
                new State("Fight",
                new Wander(1.3),
                new Taunt(1, 10000, "Heck u! xd"),
                new Shoot(25, projectileIndex: 0, count: 4, shootAngle: 10, predictive: 0.2, coolDown: 100,
                coolDownOffset: 100)
                ),
                new State("Despawn",
                new Timed(1000, new Suicide())
                    )
                )
            );
    }
}
