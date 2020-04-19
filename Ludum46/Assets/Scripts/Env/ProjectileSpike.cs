using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class ProjectileSpike : MonoBehaviour
{
    
    private Rigidbody2D m_rb;

    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_rb.velocity = new Vector2(5,0);
    }
}
