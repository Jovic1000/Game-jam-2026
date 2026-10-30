using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontDoorSceneSwitch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }


}
