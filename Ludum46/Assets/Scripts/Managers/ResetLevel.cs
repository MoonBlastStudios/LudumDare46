using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ResetLevel : MonoBehaviour
    {
        private bool m_loading;
        private int m_scene;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R) && !m_loading)
            {
                StartCoroutine(LoadYourAsyncScene());
            }
        }
        
        
    
    
    
        IEnumerator LoadYourAsyncScene()
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            m_loading = true;

            var asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            m_loading = false;
        }
    }
}
