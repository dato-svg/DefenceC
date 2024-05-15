using UnityEngine;
using UnityEngine.SceneManagement;

namespace Component
{
    public class LevelManagerComponent : MonoBehaviour
    {
        
        public void ReloadThisLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        
        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public void GoHome()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadCurrectLevel(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        
    }
}
