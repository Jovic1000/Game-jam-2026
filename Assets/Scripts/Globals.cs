using UnityEngine;

public class Globals : MonoBehaviour
{

    static Globals _instance;
    private static GameObject _player;

    public static GameObject GetCurrentPlayer()
    {
        return _player;
    }

    public static void SetCurrentPlayer(GameObject newPlayer)
    {
        _player = newPlayer;
    }


    void Awake()
    {
        #region Instance
        // Destory any other instances if they are not the original
        if (_instance) { Destroy(gameObject); return; }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion
    }
}
