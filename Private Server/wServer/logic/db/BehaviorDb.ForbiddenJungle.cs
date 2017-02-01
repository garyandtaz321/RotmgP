using wServer.logic.behaviors;
using wServer.logic.transitions;
using wServer.logic.loot;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ ForbiddenJungle = () => Behav()
            .Init("Mixcoatl the Masked God",
                new State(
                    new DropPortalOnDeath("Glowing Realm Portal", 100, PortalDespawnTimeSec: 360),
                    new State("default",
                        new PlayerWithinTransition(8, "basic")
                        ),
                    new State("basic",
                        new Prioritize(
                        
                            new Wander(0.1)
                            ),
                        new Shoot(10, predictive: 1, coolDown: 800),
                        new TimedTransition(10000, "shrink")
                        ),
                    new State("shrink",
                        new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "smallAttack")
                        ),
                    new State("smallAttack",
                        new Prioritize(
                            new Follow(1, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Flash(0x66FF00, 0.6, 9),
                        new Shoot(10, predictive: 1, coolDown: 750),
                        new Shoot(10, 9, projectileIndex: 1, predictive: 1, coolDown: 1000),
                        new TimedTransition(10000, "grow")
                        ),
                    new State("grow",
                        new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1050, "bigAttack")
                        ),
                    new State("bigAttack",
                        new Prioritize(
                            new Follow(0.2),
                            new Wander(0.1)
                            ),
                        new Flash(0x66FF00, 0.6, 9),
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 0, predictive: 1, coolDownOffset: 300, coolDown: 2000),
                        new Shoot(10, 4, projectileIndex: 1, predictive: 1, coolDownOffset: 100, coolDown: 2000),
                        new Shoot(10, 2, projectileIndex: 0, predictive: 1, coolDownOffset: 400, coolDown: 2000),
                        new TimedTransition(10000, "normalize")
                        ),
                    new State("normalize",
                        new Wander(0.3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(1000, "basic")
                        )
                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                
                new Threshold(0.025,
                    new ItemLoot("Staff of the Crystal Serpent", 0.11),

                    new ItemLoot("Cracked Crystal Skull", 0.11),

                    new ItemLoot("Crystal Bone Ring", 0.11),

                    new ItemLoot("Robe of the Tlatoani", 0.11)
                )
            )
           
            .Init("Mask Shaman",
                new State(
                    new Wander(0.875),
                    new Shoot(8, 5, 10, coolDown: 1000)
                    
                    )
            )
            .Init("Basilisk",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 3, shootAngle: 10, coolDown: 1000)

                    )
            )
            .Init("Mask Warrior",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 1, shootAngle: 10, coolDown: 1000)
                    )
            )
            .Init("Mask Hunter",
                new State(
                    new Prioritize(
                        new Follow(1, 8, 5),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 1, shootAngle: 10, coolDown: 1000)
                    )
            )
            .Init("Basilisk Baby",
                new State(
                    new Prioritize(
                        new Follow(1.5, 8, 1),
                        new Wander(0.25)
                        ),
                    new Shoot(8, 1, shootAngle: 10, coolDown: 500)
           
                    )
            )
            ;
    }
}