using Managers;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

namespace Egg
{
    public class EggDrain : MonoBehaviour
    {
        [SerializeField] private string m_groundTag;
        
        [FoldoutGroup("Drain Data")] [SerializeField] [ReadOnly] private float m_currentHealth = 100;
        [FoldoutGroup("Drain Data")] [SerializeField] private float m_maxHealth = 100;
        [FoldoutGroup("Drain Data")] [SerializeField] private float m_drainRate = 5;
        [FoldoutGroup("Drain Data")] [SerializeField] private float m_recoveryRate = 4;


        private bool m_drain = false;
        private bool m_grabbed = false;
        private bool m_gameOver = false;

        // Start is called before the first frame update
        private void Start()
        {
            m_currentHealth = m_maxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
            if (m_gameOver) return;
        
            if (!EggStateController.Instance.IsSafe())
            {
                Drain();
            }
            else
            {
                Recover();
            }

            Hud.Instance.UpdateBar(m_currentHealth / m_maxHealth);
        }


        [Button("Toggle Drain")]
        public void ToggleDrain(bool p_state)
        {
            m_drain = p_state;
        }

        private void Drain()
        {
            m_currentHealth -= Time.deltaTime * m_drainRate;

            if (m_currentHealth < 0)
            {
                Debug.Log("Egg Died");
                m_currentHealth = 0;
                m_gameOver = true;
                
                ResetLevel.StartReset();
            }
        }

        private void Recover()
        {
            if (m_currentHealth < m_maxHealth)
            {
                m_currentHealth += Time.deltaTime * m_recoveryRate;
            }
        }
    }
}
