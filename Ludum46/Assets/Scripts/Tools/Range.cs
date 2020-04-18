using Sirenix.OdinInspector;
using UnityEngine;

namespace Tools
{
    [System.Serializable]
    public class Range
    {
        [SerializeField] private float m_lowRange;
        [SerializeField] private float m_highRange;


        public Range(float p_lowRange, float p_highRange)
        {
            m_lowRange = p_lowRange;
            m_highRange = p_highRange;
        }


        public void AddOffset(float p_offset)
        {
            m_lowRange += p_offset;
            m_highRange += p_offset;
        }
        
        public float LowRange => m_lowRange;

        public float HighRange => m_highRange;
    }

    public class Range<T>
    {
        [SerializeField] private T m_lowRange;
        [SerializeField] private T m_highRange;


        public Range(T p_lowRange, T p_highRange)
        {
            m_lowRange = p_lowRange;
            m_highRange = p_highRange;
        }

        public T LowRange => m_lowRange;

        public T HighRange => m_highRange;
    }
}
