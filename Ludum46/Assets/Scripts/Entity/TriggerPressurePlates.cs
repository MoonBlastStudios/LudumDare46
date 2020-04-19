using Env.GateNDoor;
using UnityEngine;

namespace Entity
{
    public class TriggerPressurePlates : MonoBehaviour
    {
        // Start is called before the first frame update

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag($"PressurePlate")) return;

            var pressurePlateScript = collision.GetComponent<PressurePlate>();
            pressurePlateScript.OpenGates();
        }

        private void OnTriggerExit2D(Collider2D collision) 
        {
            if (!collision.CompareTag($"PressurePlate")) return;
            
            var pressurePlateScript = collision.GetComponent<PressurePlate>();
            pressurePlateScript.CloseGates();
        }
    }
}
