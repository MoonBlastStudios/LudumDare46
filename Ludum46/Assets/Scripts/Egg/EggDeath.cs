using Player;
using UnityEngine;

namespace Egg
{
    public class EggDeath : MonoBehaviour
    {
        public PlayerGrab m_playerGrab;
        private Vector3 m_spawnPoint;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void Awake()
        {
            m_spawnPoint = transform.position;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "Spike") return;

            transform.position = m_spawnPoint;
            m_playerGrab.Grab();
        }
    }
}
