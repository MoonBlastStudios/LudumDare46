using System.Collections;
using System.Collections.Generic;
using Egg;
using UnityEngine;


public class EggThrow : MonoBehaviour
{
    public Rigidbody2D rb_egg;
    
    bool Throw = false; 
    public Vector2 eggThrow;

    
    private float initialGravity = 0;
    
    private void Start() 
    {
        //eggThrow.x = 250f;
        //eggThrow.y = 250f;
        
        initialGravity = rb_egg.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown("mouse 0")){
            Throw = true;
        }*/

        if (EggStateController.Instance.Grabbed)
        {
            rb_egg.gravityScale = 0;
        }
        else
        {
            rb_egg.gravityScale = initialGravity;
        }
    }

    void FixedUpdate() 
    {
        if (Throw == true){
            
            rb_egg.AddForce(eggThrow);
            Throw = false;
        }
    }

}
