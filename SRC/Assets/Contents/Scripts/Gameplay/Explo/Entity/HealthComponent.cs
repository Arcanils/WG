using System.Collections;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo.Entity
{
    public enum EHealthStatus
    {
        Alive,
        KilledThisFrame,
        Killed,
    }
    public class HealthComponent
    {
        private readonly StatsComponent m_stats;

        public float Current { get; private set; }
        public float Perc {  get; private set; }
        public float Max {  get; private set; }
        public EHealthStatus Status { get; private set; }


        public HealthComponent(StatsComponent stats)
        {
            m_stats = stats;
            Current = 1f;
            Perc = 1f;
            Max = 1f;
        }

        public void Reset()
        {
            Status = EHealthStatus.Alive;
            Max = m_stats.HP;
            Current = Max;
        }

        public void Hit(float value)
        {
            Current -= value;

            if (Current < 0f)
                Status = EHealthStatus.KilledThisFrame;
        }

        public void Heal(float value)
        {
            Current = Mathf.Clamp(value + Current, Current, Max);
        }
    }
}