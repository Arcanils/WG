using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Contents.Scripts.Gameplay.Explo.Entity
{
    public class CustomAnimator : MonoBehaviour
    {
        [System.Serializable]
        public class CustomAnimation
        {
            [System.Serializable]
            public class CustomFrame
            {
                public Sprite Spr;
                public float Duration;
                public bool FlipX;
            }

            public string Key;
            public CustomFrame[] Frames;
            public bool Loop;
        }

        [System.Serializable]
        public class AnimData
        {
            public CustomAnimation[] Animations;
            public string StartAnim;
        }

        public SpriteRenderer TargetGraph;

        private Dictionary<string, CustomAnimation> m_animDico;
        private CustomAnimation m_currentAnim;
        private int m_frameIndex;
        private float m_endFrameTS;

        private bool m_disable;

        public bool IsFlipX { get; private set; }

        public CustomAnimator()
        {
            m_animDico = new Dictionary<string, CustomAnimation>();
            m_disable = true;
        }

        public void Update()
        {
            if (m_disable || m_endFrameTS > Time.time)
                return;

            if (++m_frameIndex < m_currentAnim.Frames.Length)
            {
                UpdateFrame();
                return;
            }

            if (m_currentAnim.Loop == true)
            {
                m_frameIndex = m_frameIndex % m_currentAnim.Frames.Length;
                UpdateFrame();
                return;
            }

            m_disable = true;
        }

        public void Init(AnimData data)
        {
            m_disable = false;

            m_animDico.Clear();
            foreach (var anim in data.Animations)
                m_animDico.Add(anim.Key, anim);

            SetAnim(data.StartAnim);
        }

        public void SetAnim(string animKey)
        {
            if (m_animDico.TryGetValue(animKey, out CustomAnimation anim) == false)
                throw new System.Exception();

            m_currentAnim = anim;
            m_frameIndex = 0;
            UpdateFrame();
        }

        private void UpdateFrame()
        {
            var current = m_currentAnim.Frames[m_frameIndex];
            TargetGraph.sprite = current.Spr;
            TargetGraph.flipX = IsFlipX ^ current.FlipX;

            m_endFrameTS = Time.time + current.Duration;
        }
    }

    public class EntityView : MonoBehaviour
    {
        public Transform GraphTrans;
        public CustomAnimator Animator;

        private void Awake()
        {
            
        }

        public void Init(Vector3 pos, Quaternion rot,
            CustomAnimator.AnimData animData)
        {
            ManualUpdate(pos, rot);
            Animator.Init(animData);
        }

        public void ManualUpdate(Vector3 pos, Quaternion rot)
        {
            GraphTrans.SetPositionAndRotation(pos, rot);
        }
    }

}