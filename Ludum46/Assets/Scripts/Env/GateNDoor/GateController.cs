using UnityEngine;

namespace Env.GateNDoor
{
    public class GateController : MonoBehaviour
    {
        public Vector3 gateMove;
        public Transform gateTrans;
        
        bool pushed = false;

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
            var gatePosition = gateTrans.position;
            if(!pushed)
            {
                gatePosition += gateMove;
                pushed = true;
            }
            gateTrans.position = gatePosition;

        }

        public void Close()
        {
        
        }
    }
}
