using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // 单例
    public static DialogManager instance;

    [Header("Initialization")]
    //Game objects used by this code
    public TMP_Text dialogText;
    public GameObject dialogBox;

    [Header("Dialog")]
    public int currentLine;
    public Sprite[] dialogPortraits;
    public string[] dialogLines;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("创建了2个 DialogManager 对象");
            instance.gameObject.SetActive(false); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 调用对话框的方法。需要字符串数组行 + bool 用于调用唤醒/进入时激活的对话框
    public void ShowDialogAuto(Sprite[] portraits, string[] newLines, bool isPerson)
    {
        // Debug.Log("ShowDialogAuto...");

        if (newLines.Length != 0)
        {
            dialogPortraits = portraits;
            dialogLines = newLines;

            currentLine = 0;

            //CheckIfName();
            //CheckIfPortrait();

            dialogText.text = dialogLines[currentLine];
            dialogBox.SetActive(true);
        }
    }
}
