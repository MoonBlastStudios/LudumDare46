using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Env
{
    public class IntervalSpike : MonoBehaviour
    {
        [SerializeField] private float m_interval;
        [SerializeField] private List<SpikeFallingTimer> m_spikes;

        private int m_currentSpike = 0;
        private Timer m_timer;

        // Start is called before the first frame update
        void Start()
        {
            m_timer = new Timer(m_interval);
        }

        // Update is called once per frame
        void Update()
        {
            if (!m_timer.Tick(1)) return;
            
            m_spikes[m_currentSpike].Spawn();

            if (m_currentSpike < m_spikes.Count - 1)
            {
                m_currentSpike++;
            }
            else
            {
                m_currentSpike = 0;
            }

        }
    }
}
