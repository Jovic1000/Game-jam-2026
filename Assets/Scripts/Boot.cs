using UnityEditor.SceneManagement;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour
{
    static Boot _instance;

    public string _loadingScreenName;


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

    public async void LoadSceneWithLoadingScene(string SceneToLoad)
    {
        await SceneManager.LoadSceneAsync(_loadingScreenName, LoadSceneMode.Additive);
        var loadingScene = SceneManager.GetSceneByName(_loadingScreenName);


    }
}
