using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [FoldoutGroup("Components")] [SerializeField] private Rigidbody2D m_rigidBody2D;
    
    [FoldoutGroup("Movement Data")] [SerializeField] private float m_inputDeadZone;
    [FoldoutGroup("Movement Data")] [SerializeField] private float m_acceleration;
    [FoldoutGroup("Movement Data")] [SerializeField] private float m_maxMovementSpeed;

    private float m_horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        BuildMovementInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void BuildMovementInput()
    {
        m_horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        if (m_horizontalInput < -m_inputDeadZone && m_rigidBody2D.velocity.x > -m_maxMovementSpeed)
        {
            m_rigidBody2D.AddForce(Vector2.left * (m_acceleration * Time.deltaTime) );
        }
        else if (m_horizontalInput > m_inputDeadZone && m_rigidBody2D.velocity.x < m_maxMovementSpeed)
        {
            m_rigidBody2D.AddForce(Vector2.right * (m_acceleration * Time.deltaTime) );
        }
        
    }
}
