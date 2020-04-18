using System;
using Tools;
using UnityEngine;

namespace UI
{
    public class Hud : MonoBehaviour
    {
        private static Hud m_instance;
        
        [SerializeField] private HpBarController m_hpBarController;


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

        public static Hud Instance => m_instance;

        public void UpdateBar(float p_ratio)
        {
            m_hpBarController.UpdateValue(p_ratio);
        }
    }
}
