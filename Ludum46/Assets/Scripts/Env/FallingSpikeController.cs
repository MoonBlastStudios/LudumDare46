using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class FallingSpikeController : MonoBehaviour
{
    private Timer timer;
    private float m_endTime = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(m_endTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Tick(1))
        {
            Die();
        }
    }
    
    void Die()
    {
        Destroy(this.gameObject);
    }
}
