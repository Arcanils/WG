using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo.Entity
{
    public class AggroComponent
    {
        //AggroTowards entity
        public readonly Dictionary<uint, float> AggroByDico;
        public readonly List<uint> TauntedByList;
        
        public float ThreatCoef { get; private set; }

        public AggroComponent()
        {
            AggroByDico = new Dictionary<uint, float>();
            TauntedByList = new List<uint>();
        }
    }
}