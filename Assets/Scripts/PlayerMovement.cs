using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; // 需要引入 InputSystem 库

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    // 这是一个属性特性，在 Unity 中使用它可以让私有变量在 Unity 编辑器中显示为可编辑的字段。
    // 这意味着，即使 speed 是私有的，它也可以在 Unity 编辑器的 Inspector 窗口中显示并编辑。
    [SerializeField] private int speed = 5;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    public GameObject UI;

    [HideInInspector]
    public bool canMove = true;

    // 加载脚本示例的时候调用
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // 设置单例
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("创建了2个 PlayerMovement 对象");
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnOpenMenu(InputValue value)
    {
        UImanager uiManager = UI.GetComponent<UImanager>(); 
        if (!uiManager.menu.activeSelf)
        {
            canMove = false;
            uiManager.OpenMenu();
        }
        else
        {
            canMove = true;
            uiManager.CloseMenu();
        }

    }

    // OnMovement 方法会用于 Player Input 组件
    private void OnMovement(InputValue value)
    {
        if (canMove)
        {
            movement = value.Get<Vector2>();

            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetFloat("moveX", movement.x);
                animator.SetFloat("moveY", movement.y);

                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }

    }

    // 用于物理运动，固定帧调用
    private void FixedUpdate()
    {
        if (canMove)
        {
            // 方法一 velocity
            // 需要设置 linear drag 摩擦力, 否则玩家不会停下来
            // 但是这种方式可能不够线性,因为玩家一开始被施加很大的速度
            //if (movement.x != 0 || movement.y != 0)
            //{
            //    // 刚体的 线性速度
            //    rb.velocity = movement * speed;
            //}

            // 方法二 MovePosition ,可能不够物理?

            // 将向量标准化，避免水平位移和斜方向位移速度不同的问题（似乎本身就不会有这个问题...)
            Vector2 movementNorm = movement.normalized;
            rb.MovePosition(rb.position + movementNorm * speed * Time.fixedDeltaTime);
            // Time.fixedDeltaTime 的值就等于 0.02
            // Debug.Log("FixedDeltaTime: " + Time.fixedDeltaTime);
            // Debug.Log("movementNorm: " + movementNorm.ToString());

            // 方法三 施加一个力
            // rb.AddForce(movement * speed);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 什么也不做
    }

    // Update is called once per frame
    void Update()
    {
        // 什么也不做
    }
}
