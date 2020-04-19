using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class ProjectileSpike : MonoBehaviour
{
    public Vector2 m_force;
    private Rigidbody2D m_rb;

    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_rb.velocity = m_force;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Egg"))
        {
            
        }
        
        Destroy(gameObject);
    }
}
