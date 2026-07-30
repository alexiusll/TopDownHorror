using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用于标记某个事件的完成状态
public class EventTrigger : MonoBehaviour
{
    [Tooltip("要触发的事件名")]
    public string eventName;

    [Tooltip("是否标记为完成，若为 false 则标记为未完成。")]
    public bool markComplete;

    [Tooltip("是否在玩家进入触发器时自动标记事件。")]
    public bool markOnEnter;

    [Tooltip("事件标记后是否禁用这个 GameObject。")]
    public bool deactivateOnMarking;

    public BoxCollider2D eventCollider;

    // Start is called before the first frame update
    void Start()
    {
        if (eventCollider == null)
        {
            eventCollider = GetComponent<BoxCollider2D>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("玩家接触区域 ");
    //}

    public void MarkEvent()
    {
        if (markComplete)
        {
            Logger.DebugLog("[" + eventName + "]事件标记为 Complete");
            EventManager.instance.MarkEventComplete(eventName);
        }
        else
        {
            Logger.DebugLog("[" + eventName + "]事件标记为 Incomplete");
            EventManager.instance.MarkEventIncomplete(eventName);
        }

        gameObject.SetActive(!deactivateOnMarking);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (markOnEnter)
            {
                MarkEvent();
            }
        }
    }

    // 用于提示
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 255, 0, 0.7f);
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(new Vector3(eventCollider.offset.x, eventCollider.offset.y, -.7f), eventCollider.size);
    }
}
