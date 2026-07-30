using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public bool activateOnAwake;

    [Header("Dialog Lines")]
    [Tooltip("Set the dialog scriptable object")]
    public Dialog dialog;

    [Tooltip("Display a name tag")]
    public bool displayName = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activateOnAwake)
        {
            // 禁止玩家移动
            PlayerMovement.instance.canMove = false;

            // 不再启用
            activateOnAwake = false;

            DialogManager.instance.ShowDialogAuto(dialog.portraits, dialog.lines, displayName);
        }
    }
}
