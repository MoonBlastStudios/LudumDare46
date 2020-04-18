using Player;
using UnityEngine;
using Tools;

public class PlayerGrab : MonoBehaviour
{
    public FlipDirection flipDirectionController;
    public float readyCatchTime;
    public int eggHoldingLayer;
    public Rigidbody2D rbEgg;
    public Rigidbody2D rbPlayer;
    public Transform playerTrans;
    public Transform eggTrans;
    bool touchingEgg = false;
    bool grabbedEgg = false;
    bool readyToCatch = false;
    bool throwEgg = false;
    public Vector2 grabPosion;
    public Vector2 throwForce;


    private Timer readyCatchTimeTimer;

    private void Awake() {
        readyCatchTimeTimer = new Timer(readyCatchTime);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Egg") && readyToCatch)
        {
            grabbedEgg = true;
            rbEgg.gameObject.layer = eggHoldingLayer;
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0") && grabbedEgg)
        {
            rbEgg.velocity = Vector2.zero;
            var directionalThrowForce = throwForce;
            directionalThrowForce.x *= flipDirectionController.LastDirection;
            rbEgg.AddForce(directionalThrowForce, ForceMode2D.Impulse);
            grabbedEgg = false;
            rbEgg.gameObject.layer = 0;
            readyToCatch = false;
        }

        if(!readyToCatch)
        {
            if(readyCatchTimeTimer.Tick(1))
            {
                readyToCatch = true;
                Debug.Log("Can Catch Again");
            }
        }


        var distance = Vector2.Distance(rbPlayer.position, rbEgg.position);

        Debug.Log(distance);

        if(distance < 1f)
        {
            grabbedEgg = true;
            rbEgg.gameObject.layer = eggHoldingLayer;
        }
    }

    private void FixedUpdate()
    {
        if (grabbedEgg != true) return;

        rbEgg.MovePosition(rbPlayer.position + grabPosion * Time.deltaTime);
    }
}
