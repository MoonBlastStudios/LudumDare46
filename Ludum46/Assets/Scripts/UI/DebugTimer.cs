using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DebugTimer : MonoBehaviour
    {
        
        public TextMeshProUGUI m_text;

        private float elapsedTime = 0;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            elapsedTime += Time.deltaTime;
            m_text.text = Math.Round(elapsedTime, 0).ToString();
        }
    }
}
