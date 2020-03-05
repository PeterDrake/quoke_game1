using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoMenu : MonoBehaviour
{
    //loads the scene with the name you give it
    public void loadDemoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
