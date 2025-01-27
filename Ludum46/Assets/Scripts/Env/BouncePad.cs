﻿using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public Vector2 direction;
    public int strength;
    
    private void OnCollisionEnter2D(Collision2D p_other)
    {
        var obj = p_other.gameObject;
        
        var rb = obj.GetComponent<Rigidbody2D>();
        rb.AddForce(direction* strength, ForceMode2D.Impulse);

        if (obj.CompareTag("Player"))
        {
            var controller = obj.GetComponent<PlayerController>();
            controller.JumpReset();
        }
    }
}