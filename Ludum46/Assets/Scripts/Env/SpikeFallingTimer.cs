using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UIElements;

public class SpikeFallingTimer : MonoBehaviour
{
    private Timer timer;
    private float m_endTime = 5;
    private Position location;
    
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
            Spawn();
        }
    }

    public GameObject spike;
    void Spawn()
    {
        Instantiate(spike, transform.position, Quaternion.identity, null);
    }
}
