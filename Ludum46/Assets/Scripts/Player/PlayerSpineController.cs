using System;
using Spine.Unity;
using UnityEngine;

namespace Player
{
    public class PlayerSpineController : MonoBehaviour
    {
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private SkeletonAnimation m_skele;
        [SerializeField] private FlipDirection m_flipDirection;

        [SpineAnimation()] [SerializeField] private string m_idle;
        [SpineAnimation()] [SerializeField] private string m_idleWithEgg;
        
        [SpineAnimation()] [SerializeField] private string m_walk;
        [SpineAnimation()] [SerializeField] private string m_walkEgg;
        
        [SpineAnimation()] [SerializeField] private string m_jump;
        [SpineAnimation()] [SerializeField] private string m_jumpEgg;
        
        
        [SpineAnimation()] [SerializeField] private string m_doubleJump;
        [SpineAnimation()] [SerializeField] private string m_doubleJumpEgg;
        
        [SpineAnimation()] [SerializeField] private string m_dash;
        [SpineAnimation()] [SerializeField] private string m_dashWithEgg;
        
        
        [SpineAnimation()] [SerializeField] private string m_fall;
        [SpineAnimation()] [SerializeField] private string m_fallWithEgg;
        
        
        
        [SpineAnimation()] [SerializeField] private string m_throw;
        

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

        public void UpdateAnimation(BonBonAnimationState p_state)
        {
            switch (p_state)
            {
                case BonBonAnimationState.Idle:
                    m_skele.AnimationState.SetAnimation(0, m_idle, true);
                    break;
                case BonBonAnimationState.IdleWithEgg:
                    m_skele.AnimationState.SetAnimation(0, m_idleWithEgg, true);
                    break;
                case BonBonAnimationState.Run:
                    m_skele.AnimationState.SetAnimation(0, m_walk, true);
                    break;
                case BonBonAnimationState.RunWithEgg:
                    m_skele.AnimationState.SetAnimation(0, m_walkEgg, true);
                    break;
                case BonBonAnimationState.Jump:
                    m_skele.AnimationState.SetAnimation(0, m_jump, false);
                    break;
                case BonBonAnimationState.JumpWithEgg:
                    m_skele.AnimationState.SetAnimation(0, m_jumpEgg, false);
                    break;
                case BonBonAnimationState.DoubleJump:
                    m_skele.AnimationState.SetAnimation(0, m_doubleJump, false);
                    break;
                case BonBonAnimationState.DoubleJumpWithEgg:
                    m_skele.AnimationState.SetAnimation(0, m_doubleJumpEgg, false);
                    break;
                case BonBonAnimationState.Dash:
                    m_skele.AnimationState.SetAnimation(0, m_dash, false);
                    break;
                case BonBonAnimationState.DashWithEgg:
                    m_skele.AnimationState.SetAnimation(0, m_dashWithEgg, false);
                    break;
                case BonBonAnimationState.Throw:
                    m_skele.AnimationState.SetAnimation(1, m_throw, false).TimeScale = 4f;
                    m_skele.AnimationState.AddEmptyAnimation(1, 0.25f, 0.45f);
                    break;
                case BonBonAnimationState.Fall:
                    m_skele.AnimationState.SetAnimation(0, m_fall, true);
                    break;
                case BonBonAnimationState.FalLWithEgg:
                    m_skele.AnimationState.SetAnimation(0, m_fallWithEgg, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(p_state), p_state, null);
            }
        }

        private void BindListeners()
        {
            m_flipDirection.FlipEvent.AddListener(FlipPlayer);
        }

        private void FlipPlayer(int p_direction)
        {
            m_skele.skeleton.ScaleX = p_direction;
        }

        public SkeletonAnimation Skele => m_skele;
    }


    public enum BonBonAnimationState
    {
        Idle,
        IdleWithEgg,
        
        Run,
        RunWithEgg,
        
        Jump,
        JumpWithEgg,
        
        Fall,
        FalLWithEgg,
        
        DoubleJump,
        DoubleJumpWithEgg,
        
        Dash,
        DashWithEgg,
        
        Throw
        
    }
}
