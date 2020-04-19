using System;
using UnityEngine;

namespace Egg
{
    public class EggCollisionController : MonoBehaviour
    {
        [SerializeField] private string m_groundTag;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground") && other.transform.position.y < transform.position.y)
            {
                EggStateController.Instance.OnGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground") && other.transform.position.y < transform.position.y)
            {
                EggStateController.Instance.OnGround = false;
            }
        }
    }
}
