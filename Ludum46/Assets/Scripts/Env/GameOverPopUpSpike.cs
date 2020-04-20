using Player;
using UnityEngine;

namespace Env
{
    public class GameOverPopUpSpike : MonoBehaviour
    {
        public PlayerGrab m_playerGrab;
        private Vector3 m_spawnPoint;
    
        private void Awake()
        {
            m_spawnPoint = transform.position;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Spike")
            {
                m_playerGrab.transform.position = m_spawnPoint;
                m_playerGrab.Grab();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
