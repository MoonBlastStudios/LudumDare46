using System;
using Sirenix.OdinInspector;
using Tools.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class FlipDirection : MonoBehaviour
    {
        [SerializeField] private PlayerController m_playerController;

        private IntEvent m_flipEvent;

        [SerializeField] [ReadOnly] private int m_lastDirection = 0;


        private void Awake()
        {
            BindEvents();
        }

        private void Update()
        {
            LastDirection = (int)m_playerController.HorizontalInput;
        }

        private void BindEvents()
        {
            m_flipEvent = new IntEvent();
        }


        public int LastDirection
        {
            get => m_lastDirection;
            set
            {
                var roundedInput = (int)m_playerController.HorizontalInput;
                if (m_lastDirection != roundedInput && roundedInput != 0)
                {
                    Debug.Log("Player Changed Direction");
                    m_flipEvent.Invoke(value);
                    m_lastDirection = value;
                }
            }
        }

        public IntEvent FlipEvent => m_flipEvent;
    }
}
