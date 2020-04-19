using System.Collections.Generic;
using UnityEngine;

namespace Env.GateNDoor
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private Collider2D m_collider2D;
        [SerializeField] private bool m_onlyOnce;
        [SerializeField] private List<GateController> m_gates;

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OpenGates()
        {
            Debug.Log("Works");
            foreach (var gate in m_gates)
            {
                gate.Open();
            }
        }

        public void CloseGates()
        {
            if (m_onlyOnce) return;
            
            foreach (var gate in m_gates)
            {
                gate.Close();
            }
        }
    }
}
