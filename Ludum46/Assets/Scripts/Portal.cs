using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int m_sceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Egg") || other.gameObject.CompareTag("Player"))
        {
           LoadScene();
        }
    }

    [Button("Load Scene")]
    public void LoadScene()
    {
        SceneManager.LoadScene(m_sceneIndex);
    }
}
