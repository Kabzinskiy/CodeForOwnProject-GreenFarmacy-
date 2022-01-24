using UnityEngine.SceneManagement;

namespace Loaders
{
        public class BasicLoader : ILoader
        {
            public void Load()
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    
}
