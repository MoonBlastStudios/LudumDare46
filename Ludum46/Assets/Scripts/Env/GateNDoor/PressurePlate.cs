using System.Collections.Generic;
using UnityEngine;

namespace Env.GateNDoor
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private List<GateController> m_gates;
            
        // Start is called before the first frame update

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Ground"))
        {
            OpenGates();
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if(!collision.gameObject.CompareTag("Ground"))
        {
            CloseGates();
        }
    }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OpenGates()
        {
            Debug.Log("Works");
            foreach (var gate in m_gates)
            {
                gate.Open();
            }
        }

        private void CloseGates()
        {
            foreach (var gate in m_gates)
            {
                gate.Close();
            }
        }
    }
}
