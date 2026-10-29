using UnityEditor.SceneManagement;
using UnityEditor.UI;
using UnityEngine;

public class Boot : MonoBehaviour
{
    static Boot _instance;



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
}
