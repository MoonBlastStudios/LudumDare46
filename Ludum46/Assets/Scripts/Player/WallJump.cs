using System;
using UnityEngine;

namespace Player
{
    public class WallJump : MonoBehaviour
    {
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private string m_wallTag;

        private float m_width;
        private float m_height;
        private
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter2D(Collision2D p_other)
        {
            if (p_other.gameObject.CompareTag(m_wallTag))
            {
                m_playerController.JumpReset();
            }
        }
    }
}
