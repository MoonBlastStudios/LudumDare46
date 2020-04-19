using Egg;
using UnityEngine;

namespace Player
{
    public class PlayerDrop : MonoBehaviour
    {
        [SerializeField] private PlayerGrab m_playerGrab;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            DropEgg();   
        }

        private void DropEgg()
        {
            if (!Input.GetButtonDown("Fire2") || !EggStateController.Instance.Grabbed) return;
        
            m_playerGrab.ResetGrab();
        }
    
    }
}
