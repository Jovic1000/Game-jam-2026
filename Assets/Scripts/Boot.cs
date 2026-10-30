using UnityEditor.SceneManagement;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    static Boot _instance;

    public static string _loadingScreenName;


    async void Awake()
    {
        #region Instance
        // Destory any other instances if they are not the original
        if (_instance) { Destroy(gameObject); return; }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion

        #region Loading

        #endregion
    }

    public static async void LoadSceneWithLoadingScene(string SceneToLoad, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
    {
        await SceneManager.LoadSceneAsync(_loadingScreenName, loadSceneMode);
        var loadingScene = SceneManager.GetSceneByName(_loadingScreenName);


    }

    public static void LoadScene(string SceneToLoad, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
    {
        SceneManager.LoadScene(SceneToLoad, loadSceneMode);
    }
}
