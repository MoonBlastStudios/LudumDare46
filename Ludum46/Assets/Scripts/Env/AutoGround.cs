using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Env
{
    public class AutoGround : MonoBehaviour
    {
        [SerializeField] private float m_force;
        [SerializeField] private bool m_reverse;
        
        [SerializeField] private List<Rigidbody2D> m_objectsOnPlatform;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            m_objectsOnPlatform.Add(other.rigidbody);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            m_objectsOnPlatform.Remove(other.rigidbody);
        }

        private void Move()
        {
            var dir = (m_reverse) ? Vector2.left : Vector2.right;

            foreach (var rigidBody in m_objectsOnPlatform)
            {
                rigidBody.AddForce(dir * (m_force * Time.deltaTime));
            }
        }
    }
}
