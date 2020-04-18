 
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public int eggHoldingLayer;
    public Rigidbody2D rbEgg;
    public Rigidbody2D rbPlayer;
    public Transform playerTrans;
    public Transform eggTrans;
    bool touchingEgg = false;
    bool grabbedEgg = false;

    public Vector2 grabPosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Egg"){
            touchingEgg = true;
            collision.gameObject.layer = eggHoldingLayer;
        }
        else {
            touchingEgg = false;
            collision.gameObject.layer = 0;
        }

        Debug.Log(touchingEgg);
    }
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0") && touchingEgg == true){
            grabbedEgg = true;
            touchingEgg = false;
        }
    }

    private void FixedUpdate() {
        if (grabbedEgg == true){
            rbEgg.MovePosition(rbPlayer.position + grabPosion * Time.deltaTime);
        }
    }

}
