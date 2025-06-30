using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("Khai báo")]
    public Rigidbody2D playerRB;
    public Animator animator;
    
    [Header("Player")]
    public float playerSpeed;
    public float playerCurHealth;
    public float playerMaxHealth;

    private float moveHor;
    private float moveVer;
    private Transform playerTransform;
    private Vector3 input;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }         
    }

    private void Start()
    {
        playerCurHealth = playerMaxHealth;
    }

    void Update()
    {
        moveHor = Input.GetAxisRaw("Horizontal");
        moveVer = Input.GetAxisRaw("Vertical");
        input = new Vector3(moveHor, moveVer).normalized;

        animator.SetFloat("moveX", moveHor);
        animator.SetFloat("moveY", moveVer);        
        animator.SetBool("isMoving", MoveCheck());
        if (input != Vector3.zero)
        {
            animator.SetFloat("lastX", input.x);
            animator.SetFloat("lastY", input.y);
        }
    }
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(input.x * playerSpeed, input.y * playerSpeed);
    }

    private bool MoveCheck()
    {
        return input != Vector3.zero;
    }    

    public void TakeDamage(float damage)
    {
        playerCurHealth -= damage;
    }    
}
