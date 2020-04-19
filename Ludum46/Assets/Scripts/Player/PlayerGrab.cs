using Egg;
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
    
    private bool grabbedEgg = false;
    private bool readyToCatch = false;

    public Vector2 grabPosion;
    public Vector2 throwForce;
    public Vector2 dropForce;


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
            readyToCatch = false;
            EggStateController.Instance.Grabbed = false;
        }

        if(!readyToCatch)
        {
            if (!readyCatchTimeTimer.Tick(1)) return;
            
            
            readyToCatch = true;
            Debug.Log("Can Catch Again");

            return;
        }

        var distancex = (rbPlayer.position.x - rbEgg.position.x);
        var distancey = (rbEgg.position.y - rbPlayer.position.y);
        //var distance = Vector2.Distance(rbPlayer.position, rbEgg.position);

        //Debug.Log(distancey);

        if((distancex < 1f && distancex > -1f) && (distancey < 2.1f && distancey > -0.45f))
        {
            grabbedEgg = true;
            rbEgg.gameObject.layer = eggHoldingLayer;
            EggStateController.Instance.Grabbed = true;
        }
    }

    private void FixedUpdate()
    {
        if (grabbedEgg != true) return;

        rbEgg.MovePosition(rbPlayer.position + grabPosion * Time.deltaTime);
    }


    public void ResetGrab()
    {
        rbEgg.velocity = Vector2.zero;
        var directionalDropForce = dropForce;
        directionalDropForce.x *= flipDirectionController.LastDirection;
        rbEgg.AddForce(directionalDropForce, ForceMode2D.Impulse);
        grabbedEgg = false;
        readyToCatch = false;
        readyCatchTimeTimer.ResetTimer();
        EggStateController.Instance.Grabbed = false;
    }
}
