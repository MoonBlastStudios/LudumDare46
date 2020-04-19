using UnityEngine;

namespace Env.GateNDoor
{
    public class GateController : MonoBehaviour
    {
        public Vector3 m_gateMove;
        public Transform m_gateTrans;
        
        public bool m_lachedGate; //Bool used to use 
        
        private bool m_pushed = false;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Open()
        {
            Debug.Log("Gate Opening");
            var gatePosition = m_gateTrans.position;
            
            if(!m_pushed)
            {
                gatePosition += m_gateMove;
                m_pushed = true;
            }
            
            m_gateTrans.position = gatePosition;

        }
 
        public void Close()
        {
            if (m_lachedGate) return;
            
            Debug.Log("Gate Closing");
            var gatePosition = m_gateTrans.position;
            gatePosition -= m_gateMove;
            m_gateTrans.position = gatePosition;
            m_pushed = false;
        }
        
    }
}
