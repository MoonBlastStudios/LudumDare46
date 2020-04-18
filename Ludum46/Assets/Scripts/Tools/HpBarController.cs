using System;
using System.Diagnostics;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace Tools
{
    public class HpBarController : MonoBehaviour
    {
        [Tooltip("The HP Bar to Control")]
        [FoldoutGroup("Components")] [SerializeField] private Image m_hpBar;

        [Tooltip("The Type of filling: Chunk = Instant, Smooth = Interpolation")]
        [FoldoutGroup("Fill Data")] [SerializeField] private FillType m_fillType;
        [Tooltip("The Fill Speed If Smooth Transition")]
        [FoldoutGroup("Fill Data")] [SerializeField] private float m_fillSpeed;

        [FoldoutGroup("Debug Data")] [SerializeField] [ReadOnly] private float m_currentVal = 0;
        [FoldoutGroup("Debug Data")] [SerializeField] [ReadOnly] private float m_defaultScale = 0;
        [FoldoutGroup("Debug Data")] [SerializeField] [ReadOnly] private float m_destinationVal = 0;

        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateBar();
        }

        private void Initialize()
        {
            m_currentVal = m_hpBar.transform.localScale.x;
            m_defaultScale = m_currentVal;
            m_destinationVal = m_currentVal;
            m_hpBar.fillAmount = 1;
        }

        private void UpdateBar()
        {
            if (m_fillType == FillType.Chunk || Math.Abs(m_currentVal - m_destinationVal) < 0.001) return;

            m_currentVal = Mathf.Lerp(m_currentVal, m_destinationVal, Time.deltaTime * m_fillSpeed);
            m_hpBar.fillAmount = m_currentVal;
        }

        
        [Button("Update Val")]
        public void UpdateValue(float p_val)
        {
            switch (m_fillType)
            {
                case FillType.Chunk:
                    m_hpBar.fillAmount = p_val;
                    break;
                case FillType.Smooth:
                    m_destinationVal = p_val * m_defaultScale;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void UpdateValue(float p_currentVal, float p_maxVal)
        {
            var ratio = p_currentVal / p_maxVal;
            
            switch (m_fillType)
            {
                case FillType.Chunk:
                    m_hpBar.fillAmount = ratio;
                    break;
                case FillType.Smooth:
                    m_destinationVal = ratio * m_defaultScale;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        
        
    }
}
