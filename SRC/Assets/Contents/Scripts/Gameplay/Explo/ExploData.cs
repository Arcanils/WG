using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo
{
    public interface IMission
    {

    }

    public class ExploData
    {
        public readonly List<IMission> InProgressMissions;

        public ExploData()
        {
            InProgressMissions = new List<IMission>();
        }

        public void StartNewDungeon()
        {

        }
    }
}