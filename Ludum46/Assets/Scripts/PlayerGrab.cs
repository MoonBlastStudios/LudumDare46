
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);

    }
        


    // Update is called once per frame
    void Update()
    {
        
    }
}
