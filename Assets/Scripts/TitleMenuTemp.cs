using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleMenuTemp : MonoBehaviour
{
    public GameObject pressStart;

    public string newGameScene;

    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {

            Debug.Log("鼠标左键被点击");

            // 这里写你的点击逻辑
            pressStart.SetActive(false);
            ShowMenu();
        }
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("点击退出游戏");

        Application.Quit();
    }

    public void NewGame(int difficulty)
    {
        Debug.Log("点击开始游戏，游戏难度:" + difficulty);

        SceneManager.LoadScene(newGameScene);

    }
}
