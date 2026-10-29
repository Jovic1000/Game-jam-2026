using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{

    public MenuInstance[] _menus;

    [SerializeField] private MenuInstance _loadedMenu;

    [SerializeField] private List<MenuInstance> _loadedSubMenus;


    #region DisplayMenu
    // Main Function
    public void DisplayMenu(MenuInstance menu)
    {
        MenuCleanup();

        menu.Enable();
        _loadedMenu = menu;
    }

    public void DisplayMenu(int index)
    { 
        DisplayMenu(_menus[index]);
    }


    public void DisplayMenu(string menuName)
    {

        foreach (MenuInstance menu in _menus)
        {
            if (menu.name == menuName) { DisplayMenu(menu); break; }
        }
    }
    #endregion


    public void DisableMenu()
    {
        _loadedMenu.Disable();
        _loadedMenu = null;
    }


    public void DisableAllSubMenus()
    {
        // Disable Menus
        foreach (MenuInstance subMenu in _loadedSubMenus)
        {
            subMenu.Disable();
        }

        // Clear List
        _loadedSubMenus.Clear();
    }
    private void MenuCleanup()
    {
        DisableAllSubMenus();
        DisableMenu();
    }

    #region DisplaySubMenu
    // Main Function
    public void DisplaySubMenu(MenuInstance subMenu)
    {
        // Enable and add to list
        subMenu.Enable();
        _loadedSubMenus.Add(subMenu);
    }

    public void DisplaySubMenu(int index)
    {
        DisplaySubMenu(_loadedSubMenus[index]);
    }

    public void DisplaySubMenu(string subMenuName)
    {
        foreach (MenuInstance menu in _menus)
        {
            if (menu.name == subMenuName) { DisplaySubMenu(menu); break; }
        }
    }
    #endregion



    // Temp Time Management
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameSpeed(float speed)
    {
        if (speed < 0) return;
        Time.timeScale = speed;
    }



    /*// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
