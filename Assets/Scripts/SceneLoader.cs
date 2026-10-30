using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneSingle(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }

    public void LoadSceneAdditive(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
