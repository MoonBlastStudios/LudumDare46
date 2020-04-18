using System;
using Spine.Unity;
using UnityEngine;

namespace Player
{
    public class PlayerSpineController : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation m_skele;
        [SerializeField] private FlipDirection m_flipDirection;


        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            BindListeners();
        }
        

        // Update is called once per frame
        void Update()
        {
        
        }

        private void BindListeners()
        {
            m_flipDirection.FlipEvent.AddListener(FlipPlayer);
        }

        private void FlipPlayer(int p_direction)
        {
            m_skele.skeleton.ScaleX = p_direction;
        }
    }
}
