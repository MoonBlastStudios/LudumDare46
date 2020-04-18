using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

public class EggDrain : MonoBehaviour
{
    [SerializeField] private string m_groundTag;
    
    [FoldoutGroup("Drain Data")] [SerializeField] [ReadOnly] private float m_currentHealth = 100;
    [FoldoutGroup("Drain Data")] [SerializeField] private float m_maxHealth = 100;
    [FoldoutGroup("Drain Data")] [SerializeField] private float m_drainRate = 5;
    [FoldoutGroup("Drain Data")] [SerializeField] private float m_recoveryRate = 4;


    private bool m_drain = false;
    private bool m_gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameOver) return;
        
        if (m_drain)
        {
            Drain();
        }
        else
        {
            Recover();
        }
        
        if(Hud.Instance != null)
            Hud.Instance.UpdateBar(m_currentHealth / m_maxHealth);
    }


    [Button("Toggle Drain")]
    public void ToggleDrain(bool p_state)
    {
        m_drain = p_state;
    }

    private void Drain()
    {
        m_currentHealth -= Time.deltaTime * m_drainRate;

        if (m_currentHealth < 0)
        {
            Debug.Log("Egg Died");
            m_currentHealth = 0;
            m_gameOver = true;
        }
    }

    private void Recover()
    {
        if (m_currentHealth < m_maxHealth)
        {
            m_currentHealth += Time.deltaTime * m_recoveryRate;
        }
    }
}
