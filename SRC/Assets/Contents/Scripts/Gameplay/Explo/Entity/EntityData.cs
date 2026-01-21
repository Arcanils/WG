using System.Collections;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo.Entity
{
    public class EntityData : ITarget
    {
        public readonly PositionComponent PosComp;
        public readonly StatsComponent StatsComp;
        public readonly HealthComponent HealthComp;
        public readonly MoveComponent MoveComp;
        public readonly TargetComponent TargetComp;

        public EntityData()
        {
            PosComp = new PositionComponent();
            StatsComp = new StatsComponent();
            HealthComp = new HealthComponent(StatsComp);
            MoveComp = new MoveComponent();
        }
    }
}