using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pause_menu;

    public void HideMenu()
    {
        pause_menu.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        pause_menu.SetActive(true);
    }

    public void ShowMenu(GameObject menuObject)
    {
        menuObject.SetActive(true);
        HideMenu();
    }
}
