 
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
        if (collision.gameObject.CompareTag("Egg"))
        {
            touchingEgg = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Egg"))
        {
            touchingEgg = false;
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0") && touchingEgg == true)
        {
            grabbedEgg = true;
            touchingEgg = false;
            rbEgg.gameObject.layer = eggHoldingLayer;
        }
    }

    private void FixedUpdate() {
        if (grabbedEgg == true)
        {
            rbEgg.MovePosition(rbPlayer.position + grabPosion * Time.deltaTime);
        }
    }

}
