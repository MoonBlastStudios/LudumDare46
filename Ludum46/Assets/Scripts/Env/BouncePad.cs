using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public int strength;
    
    private void OnCollisionEnter2D(Collision2D p_other)
    {
        var obj = p_other.gameObject;


        if (!(transform.position.y < obj.transform.position.y) || !obj.CompareTag("Player")) return;
        
        var rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
    }
}