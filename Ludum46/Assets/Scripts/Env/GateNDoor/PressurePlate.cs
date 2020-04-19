using System.Collections.Generic;
using UnityEngine;

namespace Env.GateNDoor
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private List<GateController> m_gates;
            
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OpenGates()
        {
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
