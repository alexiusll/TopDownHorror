using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EventObjectActivator : MonoBehaviour
{

    [Tooltip("Drag and drop the game object that should be activated or deactivated")]
    public GameObject objectToActivate;

    [Tooltip("Choose the event whose completion should be checked from the Event Manager")]
    public string eventToCheck;

    [Tooltip("Activate the game object when the chosen event was completed. Leave unchecked if you want to deactivate the game object instead")]
    public bool activeIfComplete;

    [Tooltip("Activate a delay before the activation")]
    public bool waitBeforeActivate;

    [Tooltip("Enter the duration for the delay in seconds")]
    public float waitTime;

    private bool initialCheckDone;

    public UnityEvent onActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialCheckDone)
        {
            initialCheckDone = true;

            CheckCompletion();
        }
    }


    public void CheckCompletion()
    {
        if (EventManager.instance.CheckIfComplete(eventToCheck))
        {
            if (waitBeforeActivate)
            {
                Logger.DebugLog("开启协程，等待时间为:" + waitTime);
                StartCoroutine(waitCo());
            }
            else
            {
                Logger.DebugLog("设置游戏对象[" + objectToActivate.name + "], 状态为:" + (activeIfComplete ? "启用" : "不启用"));
                objectToActivate.SetActive(activeIfComplete);
            }
        }
    }

    IEnumerator waitCo()
    {
        yield return new WaitForSeconds(waitTime);
        Logger.DebugLog("设置游戏对象[" + objectToActivate.name + "], 状态为:" + (activeIfComplete ? "启用" : "不启用"));
        objectToActivate.SetActive(activeIfComplete);

        // onActivate?.Invoke(); 这里使用了 空检查调用 (?.)，意思是：
        // 如果 onActivate 不为 null，则执行 Invoke()，调用所有已注册的监听器。
        // 如果 onActivate 为 null，则不会执行任何操作，避免 NullReferenceException。
        onActivate?.Invoke();
    }
}
