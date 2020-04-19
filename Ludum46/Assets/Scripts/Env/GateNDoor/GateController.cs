using UnityEngine;

namespace Env.GateNDoor
{
    public class GateController : MonoBehaviour
    {
        public Vector3 m_gateMove;
        public float m_gateSpeed;
        public float m_gateDistanceDeadZone;
        
        private bool m_pushed = false;
        
        private Vector3 m_initialPosition;
        private Vector3 m_destinationPosition;
        

        // Start is called before the first frame update
        void Start()
        {
            m_initialPosition = transform.position;
            m_destinationPosition += m_initialPosition + m_gateMove;
        }

        // Update is called once per frame
        void Update()
        {
            MoveGate();
        }


        private void MoveGate()
        {
            //That means that the gate needs to open
            if (m_pushed)
            {
                var distance = Vector3.Distance(transform.position, m_destinationPosition);

                if (distance > m_gateDistanceDeadZone)
                {
                    transform.position = Vector3.Lerp(transform.position, m_destinationPosition,
                        Time.deltaTime * m_gateSpeed);
                }
            }
            else
            {
                var distance = Vector3.Distance(transform.position, m_initialPosition);

                if (distance > m_gateDistanceDeadZone)
                {
                    transform.position = Vector3.Lerp(transform.position, m_initialPosition,
                        Time.deltaTime * m_gateSpeed);
                }
            }
        }

        public void Open()
        {
            Debug.Log("Gate Opening");
            
            if(!m_pushed)
            {
                m_pushed = true;
            }
            
        }
 
        public void Close()
        {
            Debug.Log("Gate Closing");
            m_pushed = false;
        }
        
    }
}
