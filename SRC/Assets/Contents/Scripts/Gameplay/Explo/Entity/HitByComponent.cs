using System.Collections;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo.Entity
{
    public class HitByComponent
    {
        private readonly HealthComponent m_hpComp;

        public HitByComponent(HealthComponent hpComp)
        {
            m_hpComp = hpComp;
        }

        public void Hit(float dmg)
        {
            m_hpComp.Hit(dmg);
        }
    }
}