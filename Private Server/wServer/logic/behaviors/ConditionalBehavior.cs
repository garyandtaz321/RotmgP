using wServer.realm;

namespace wServer.logic.behaviors
{
    public class ConditionalBehavior : Behavior
    {
        private readonly ConditionEffectIndex effect;
        private readonly Behavior behavior;

        public ConditionalBehavior(ConditionEffectIndex effect, Behavior behavior)
        {
            this.effect = effect;
            this.behavior = behavior;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            behavior.OnStateEntry(host, time);
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            if (host.HasConditionEffect(effect))
                behavior.Tick(host, time);
        }
    }
}
