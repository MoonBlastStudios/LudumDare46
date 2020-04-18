using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EggThrow : MonoBehaviour
{
    public Rigidbody2D rb_egg;
    
    bool Throw = false; 
    public Vector2 eggThrow;

    private void Start() 
    {
        //eggThrow.x = 250f;
        //eggThrow.y = 250f;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("mouse 0")){
            Throw = true;
        }*/
    }

    void FixedUpdate() 
    {
        if (Throw == true){
            
            rb_egg.AddForce(eggThrow);
            Throw = false;
        }
    }

}
