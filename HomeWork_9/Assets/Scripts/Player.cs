using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    private PlayerController controller;
    private Rigidbody2D body;
    private bool isGrounded;
    private Vector2 moveInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        controller = new PlayerController();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        controller.Enable();
        controller.Gameplay.Move.performed += Move_performed;
        controller.Gameplay.Move.canceled += Move_canceled;
        controller.Gameplay.Jump.performed += Jump_performed;
    }

    void Move_performed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        animator.SetBool("Move", true);
    }

    void Move_canceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
        animator.SetBool("Move", false);
    }

    void Jump_performed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            Jump();
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 movement = new Vector2(moveInput.x * moveSpeed, body.velocity.y);
        body.velocity = movement;

        if (moveInput.x != 0)
        {
            spriteRenderer.flipX = moveInput.x < 0;
        }
    }

    void Jump()
    {
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetTrigger("Jumped");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.1f)
        {
            isGrounded = true;
        }
    }

    void OnDisable()
    {
        controller.Gameplay.Move.performed -= Move_performed;
        controller.Gameplay.Move.canceled -= Move_canceled;
        controller.Gameplay.Jump.performed -= Jump_performed;
    }
}
