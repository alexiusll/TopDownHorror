using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.TouchScreenKeyboard;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UImanager : MonoBehaviour
{
    public Button test1;
    public Button test2;
    public Button test3;
    public Button quit;

    public GameObject quitPrompt;
    public GameObject menu;

    [Header("Linked Scenes")]
    public string mainMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenQuitPrompt()
    {
        test1.interactable = false;
        test2.interactable = false;
        test3.interactable = false;
        quit.interactable = false;

        quitPrompt.SetActive(true);
    }

    public void CloseQuitPrompt()
    {
        test1.interactable = true;
        test2.interactable = true;
        test3.interactable = true;
        quit.interactable = true;

        quitPrompt.SetActive(false);

    }

    public void OpenMenu()
    {
        Debug.Log("打开菜单 ");
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Debug.Log("关闭菜单 ");
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        test1.interactable = true;
        test2.interactable = true;
        test3.interactable = true;
        quit.interactable = true;
        quit.interactable = true;
        CloseQuitPrompt();
        CloseMenu();

        SceneManager.LoadScene(mainMenuScene);
    }
}
