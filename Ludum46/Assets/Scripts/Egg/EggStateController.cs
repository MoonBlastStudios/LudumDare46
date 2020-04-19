using System;
using UnityEngine;

namespace Egg
{
    public class EggStateController : MonoBehaviour
    {
        private static EggStateController m_instance;
        
        [SerializeField] private bool m_grabbed;
        [SerializeField] private bool m_underLamp;
        [SerializeField] private bool m_onGround;

        private void Awake()
        {
            BindInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void BindInstance()
        {
            if (m_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            m_instance = this;
        }

        public bool Grabbed
        {
            get => m_grabbed;
            set => m_grabbed = value;
        }

        public bool UnderLamp
        {
            get => m_underLamp;
            set => m_underLamp = value;
        }

        public bool OnGround
        {
            get => m_onGround;
            set => m_onGround = value;
        }

        public static EggStateController Instance => m_instance;
    }
}
