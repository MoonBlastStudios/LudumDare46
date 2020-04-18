using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class FlipDirection : MonoBehaviour
    {
        [SerializeField] private PlayerController m_playerController;

        private UnityEvent m_flipEvent;

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
            m_flipEvent = new UnityEvent();
        }


        private int LastDirection
        {
            get => m_lastDirection;
            set
            {
                var roundedInput = (int)m_playerController.HorizontalInput;
                if (m_lastDirection != roundedInput && roundedInput != 0)
                {
                    Debug.Log("Player Changed Direction");
                    m_flipEvent.Invoke();
                    m_lastDirection = value;
                }
            }
        }
    }
}
