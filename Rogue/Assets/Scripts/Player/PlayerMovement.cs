using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;

    //references
    Rigidbody2D rb;
    PlayerStats Player;



    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    // Update is c alled once per frame
    void Update()
    {
        InputManagement();
    }


    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        if(GameManager.instance.isGameOver)
        {
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);

        moveDir = new Vector2(moveX, moveY).normalized;
        if (moveDir != Vector2.zero)
        {
            lastMovedVector = moveDir;
        }

    }

    void Move()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        rb.velocity = new Vector2(moveDir.x * Player.CurrentMoveSpeed, moveDir.y * Player.CurrentMoveSpeed);
    }
}
