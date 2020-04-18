 
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public Transform playerTrans;
    public Transform eggTrans;
    bool touchingEgg = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Egg"){
            touchingEgg = true;
        }
        touchingEgg = false;
        Debug.Log(touchingEgg);
    }
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0") && touchingEgg == true){
            Debug.Log("working");
        }
    }
}
