﻿using System;
using Com.LuisPedroFonseca.ProCamera2D;
using Egg;
using Sirenix.OdinInspector;
using Tools;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerState m_playerState;
    
        [FoldoutGroup("Components")] [SerializeField] private Rigidbody2D m_rigidBody2D;
        [FoldoutGroup("Components")] [SerializeField] private FlipDirection m_flipDirection;
        [FoldoutGroup("Components")] [SerializeField] private PlayerSpineController m_playerSpineController;

        [FoldoutGroup("Shake Data")] [SerializeField] private ShakePreset m_doubleJumpShakeData;
        [FoldoutGroup("Shake Data")] [SerializeField] private ShakePreset m_dashShakeData;

        [FoldoutGroup("Movement Data")] [SerializeField] private float m_inputDeadZone;
        [FoldoutGroup("Movement Data")] [SerializeField] private Vector2 m_velocityDeadZone;
        [FoldoutGroup("Movement Data")] [SerializeField] private float m_acceleration;
        [FoldoutGroup("Movement Data")] [SerializeField] private float m_deceleration;
        [FoldoutGroup("Movement Data")] [SerializeField] private float m_maxMovementSpeed;

        [FoldoutGroup("Jump")] [SerializeField] private float m_jumpStrength;
        [FoldoutGroup("Jump")] [SerializeField] [ReadOnly] private bool m_jump;
        [FoldoutGroup("Jump")] [SerializeField] [ReadOnly]  private bool m_secondaryJumpAction;

        [FoldoutGroup("Dash")] [SerializeField]  private float m_dashForce;
        [FoldoutGroup("Dash")] [SerializeField]  private float m_dashDuration;
        [FoldoutGroup("Dash")] [SerializeField] [ReadOnly] private bool m_dash;

        private float m_horizontalInput;
        private float m_gravityScale;
        private Timer m_dashTimer;
        private GameObject m_ground;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            m_dashTimer = new Timer(m_dashDuration);
            m_gravityScale = m_rigidBody2D.gravityScale;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            BuildMovementInput();
            Dash();
            Jump();
            UpdateState();
        }

        private void FixedUpdate()
        {
            Move();
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag($"Ground") && transform.position.y > other.transform.position.y && !other.gameObject.Equals(m_ground))
            {
                Debug.Log("Collided With Ground");
                m_ground = other.gameObject;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            //We Left the ground that we were standing on
            if (other.gameObject.Equals(m_ground))
            {
                m_ground = null;
            }
            
        }

        private void BuildMovementInput()
        {
            m_horizontalInput = Input.GetAxisRaw("Horizontal");
        }

        private void UpdateState()
        {
            if (m_rigidBody2D.velocity.y > m_velocityDeadZone.y && m_ground == null)
            {
                State = PlayerState.Jumping;
            }
            else if (m_rigidBody2D.velocity.y < -m_velocityDeadZone.y && m_ground == null)
            {

                State = PlayerState.Falling;
            }
            else if(m_ground != null)
            {
                if (m_rigidBody2D.velocity.x > m_velocityDeadZone.x || m_rigidBody2D.velocity.x < -m_velocityDeadZone.x)
                {
                    if (m_rigidBody2D.velocity.x > -m_maxMovementSpeed - 1 && m_rigidBody2D.velocity.x < m_maxMovementSpeed + 1 || State != PlayerState.Dashing)
                    {
                        State = PlayerState.Moving;   
                    }
                }
                else
                {
                    State = PlayerState.Idle;
                }
            }
        
        }

        private void Move()
        {
            if (m_horizontalInput < -m_inputDeadZone && m_rigidBody2D.velocity.x > -m_maxMovementSpeed)
            {
                m_rigidBody2D.AddForce(Vector2.left * (m_acceleration * Time.deltaTime) );
                return;
            }
            
            if (m_horizontalInput > m_inputDeadZone && m_rigidBody2D.velocity.x < m_maxMovementSpeed)
            {
                m_rigidBody2D.AddForce(Vector2.right * (m_acceleration * Time.deltaTime));
                return;
            }

            if ((m_horizontalInput < -m_inputDeadZone || m_horizontalInput > m_inputDeadZone)) return;
            
            
            if (m_rigidBody2D.velocity.x > m_velocityDeadZone.x)
            {
                m_rigidBody2D.AddForce(Vector2.left * (m_deceleration * Time.deltaTime));
            }
            else if (m_rigidBody2D.velocity.x < -m_velocityDeadZone.x)
            {
                m_rigidBody2D.AddForce(Vector2.right * (m_deceleration * Time.deltaTime));
            }
            else
            {
                var velocity = m_rigidBody2D.velocity;
                velocity.x = 0;
                m_rigidBody2D.velocity = velocity;
            }
        }
    
        private void Jump()
        {
            if ((m_jump && m_secondaryJumpAction) || !Input.GetButtonDown("Jump")) return;

            if (m_jump)
            {
                m_secondaryJumpAction = true;
                
                m_playerSpineController.UpdateAnimation(!EggStateController.Instance.Grabbed
                    ? BonBonAnimationState.DoubleJump
                    : BonBonAnimationState.DoubleJumpWithEgg);
                
                ProCamera2DShake.Instance.Shake(m_doubleJumpShakeData);
            }
            else
            {
                m_playerSpineController.UpdateAnimation(!EggStateController.Instance.Grabbed
                    ? BonBonAnimationState.Jump
                    : BonBonAnimationState.JumpWithEgg);
            }

            
            var velocity = m_rigidBody2D.velocity;

            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            
            m_rigidBody2D.velocity = velocity;
            
            m_rigidBody2D.AddForce(Vector2.up * m_jumpStrength, ForceMode2D.Impulse);
        
            m_jump = true;
        }


        private void Dash()
        {

            if (m_dash)
            {
                if (!m_dashTimer.Tick(1)) return;

                m_rigidBody2D.gravityScale = m_gravityScale;
                var velocity = m_rigidBody2D.velocity;
                velocity = velocity * 0.25f;
                //m_dash = false;
                return;
            }

            if (!Input.GetKeyDown(KeyCode.LeftShift)) return;
            
            if (m_secondaryJumpAction) return; 
            
            Debug.Log("Dash");
            

            m_rigidBody2D.AddForce(new Vector2(m_flipDirection.LastDirection, 0) * m_dashForce,
                ForceMode2D.Impulse);

            ProCamera2DShake.Instance.Shake(m_dashShakeData);
            
            State = PlayerState.Dashing;
            m_rigidBody2D.gravityScale = 0;
            m_dash = true;
            m_secondaryJumpAction = true;
        }

        public void JumpReset()
        {
            m_jump = false;
        }
    


        public PlayerState State
        {
            get => m_playerState;
            set
            {
                if (m_playerState != value)
                {
                    switch (value)
                    {
                        case PlayerState.Idle:
                            m_jump = false;
                            m_secondaryJumpAction = false;
                            m_dash = false;

                            m_playerSpineController.UpdateAnimation(!EggStateController.Instance.Grabbed
                                ? BonBonAnimationState.Idle
                                : BonBonAnimationState.IdleWithEgg);

                            break;
                        case PlayerState.Moving:
                            m_jump = false;
                            m_secondaryJumpAction = false;
                            m_dash = false;

                            m_playerSpineController.UpdateAnimation(!EggStateController.Instance.Grabbed
                                ? BonBonAnimationState.Run
                                : BonBonAnimationState.RunWithEgg);

                            break;
                        case PlayerState.Jumping:
                            break;
                        case PlayerState.Falling:

                            m_playerSpineController.UpdateAnimation(!EggStateController.Instance.Grabbed
                                ? BonBonAnimationState.Fall
                                : BonBonAnimationState.FalLWithEgg);
                            break;
                        case PlayerState.None:
                            break;
                        case PlayerState.Dashing:
                            m_playerSpineController.UpdateAnimation(!EggStateController.Instance.Grabbed
                                ? BonBonAnimationState.Dash
                                : BonBonAnimationState.DashWithEgg);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(value), value, null);
                    }
                }

                m_playerState = value;
            }
        }


        public float MaxMovementSpeed => m_maxMovementSpeed;

        public float HorizontalInput => m_horizontalInput;
    }
}
