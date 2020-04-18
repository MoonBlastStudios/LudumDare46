using UnityEngine;

//Author: Angelo Halabi

namespace Tools
{
    public class Timer
    {
        private float m_currentTime = 0;
        private float m_startTime = 0;
        private float m_endTime = 0;

        /// <summary>
        /// This initializes the timer
        /// </summary>
        /// <param name="p_startTIme">THe Start Time of The timer</param>
        /// <param name="p_endTime"> When The Timer Ends</param>
        public Timer(float p_startTIme, float p_endTime)
        {
            m_currentTime = p_startTIme;
            m_startTime = p_startTIme;
            m_endTime = p_endTime;
        }
        
        /// <summary>
        /// Initializes the Timer with only an end time
        /// </summary>
        /// <param name="p_endTime"> The End Time Of The Timer</param>
        public Timer(float p_endTime)
        {
            m_currentTime = 0;
            m_startTime = 0;
            m_endTime = p_endTime;
        }

        public bool Tick(float p_spawnTimerTickRate)
        {
            if (m_currentTime < m_endTime)
            {
                m_currentTime += Time.deltaTime * p_spawnTimerTickRate;
                return false;
            }
            else
            {
                m_currentTime = 0;
                return true;
            }
        }

        public void UpdateEndTime(float p_val)
        {
            m_endTime = p_val;
        }

        public float CurrentTime => m_currentTime;

        public float StartTime => m_startTime;

        public float EndTime => m_endTime;
        
    }
}
