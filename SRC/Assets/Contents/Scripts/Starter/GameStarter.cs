using Assets.Contents.Scripts.Gameplay.Explo;
using System.Collections;
using UnityEngine;

namespace Assets.Contents.Scripts.Starter
{
    public class GameStarter : MonoBehaviour
    {
        private ExploController m_exploController;
        public void Start()
        {
            m_exploController = new ExploController();
            m_exploController.StartNewExplo();
        }
    }
}