using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    [Header("事件设置")]
    public List<string> events;
    public List<bool> completedEvents;

    // Start is called before the first frame update
    void Start()
    {
        // 设置为单例
        instance = this;
    }

    public int GetEventNumber(string eventToFind)
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i] == eventToFind)
            {
                return i;
            }
        }

        Debug.LogError("Event " + eventToFind + " does not exist");
        return -1;
    }

    // 检查事件是否被标记为 complete
    public bool CheckIfComplete(string eventToCheck)
    {
        if (GetEventNumber(eventToCheck) != -1)
        {
            return completedEvents[GetEventNumber(eventToCheck)];
        }

        return false;
    }

    public void MarkEventComplete(string eventToMark)
    {
        completedEvents[GetEventNumber(eventToMark)] = true;

        UpdateLocalEventObjects();
    }

    public void UpdateLocalEventObjects()
    {
        // FindObjectsOfType<T>() 是 Unity 提供的方法。获取所有加载的 Type 类型对象的列表。
        // 下面表示查找所有挂载了 EventObjectActivator 脚本的 GameObject
        EventObjectActivator[] eventObjects = Object.FindObjectsByType<EventObjectActivator>();

        Logger.DebugLog("更新当前场景中<EventObjectActivator>类型对象的状态...");
        if (eventObjects.Length > 0)
        {
            for (int i = 0; i < eventObjects.Length; i++)
            {
                eventObjects[i].CheckCompletion();
            }
        }
    }

    public void MarkEventIncomplete(string questToMark)
    {
        completedEvents[GetEventNumber(questToMark)] = false;

        UpdateLocalEventObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
