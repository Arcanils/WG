using System.Collections;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo.Entity
{
    public enum EEntityStats
    {
        DMG,
        HP,
        MP,
        MS,

        COUNT,
    }

    public class StatsComponent
    {
        public readonly float[] Stats;

        public float HP => Stats[(int)EEntityStats.HP];

        public StatsComponent()
        {
            Stats = new float[(int)EEntityStats.COUNT];
        }
    }
}