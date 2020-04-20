using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopUpSpike : MonoBehaviour
{
    private Vector3 m_spawnPoint;
    
    private void Awake()
    {
        m_spawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            transform.position = m_spawnPoint;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
