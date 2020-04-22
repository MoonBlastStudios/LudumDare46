using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Env
{
    public class SpikeExtender : MonoBehaviour
    {
        [SerializeField] private Vector3 m_offset;
        [SerializeField] private float m_speed;
        [SerializeField] private float m_extendTimer;
        [SerializeField] private float m_extendMarginError = 0.01f;
        [SerializeField] private bool m_extend;
        
        private Vector3 m_initialPosition;
        private Timer m_timer;

        // Start is called before the first frame update
        void Start()
        {
            m_timer = new Timer(m_extendTimer);

            m_initialPosition = m_extend ? transform.position - m_offset : transform.position;
            
        }

        // Update is called once per frame
        void Update()
        {

            if (m_timer.Tick(1))
            {
                m_extend = !m_extend;
            }

            if (m_extend)
            {
                Extend();
            }
            else
            {
                Retract();
            }
        }

        private void Retract()
        {
            if (Vector3.Distance(transform.position, m_initialPosition) > m_extendMarginError)
            {
                transform.position = Vector3.Lerp(transform.position, m_initialPosition, Time.deltaTime * m_speed);
            }
        }

        private void Extend()
        {
            var destination = m_initialPosition + m_offset;

            var distance = Vector3.Distance(transform.position, destination);
            
            Debug.Log(distance);
            
            if (distance > m_extendMarginError)
            {
                transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * m_speed);
            }
        }
    }
}
