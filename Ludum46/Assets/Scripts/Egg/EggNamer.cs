using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Egg
{
    public class EggNamer : MonoBehaviour
    {
        [SerializeField] private TextMeshPro m_eggNameLabel;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        [Button("Name The Egg")]
        public void NameEgg(string p_name)
        {
            m_eggNameLabel.text = p_name;
        }
    }
}
