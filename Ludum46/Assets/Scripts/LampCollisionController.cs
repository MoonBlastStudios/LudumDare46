using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCollisionController : MonoBehaviour
{ private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Egg")
        {
            Debug.Log("Entered Lamp");
        }
    }
}
