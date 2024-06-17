using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Vector2 inputDirection;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        inputDirection = value.Get<Vector2>();

        UpdateAnimation();
    }

    void Update()
    {
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        float isoX = inputDirection.x - inputDirection.y;
        float isoY = (inputDirection.x + inputDirection.y) / 2;

        Vector2 move = new Vector2(isoX, isoY).normalized;
        rb.velocity = move * speed;
    }

    void UpdateAnimation()
    {
        animator.SetFloat("MoveX", inputDirection.x);
        animator.SetFloat("MoveY", inputDirection.y);
        animator.SetBool("isMoving", inputDirection != Vector2.zero);

        if (inputDirection.x > 0 && inputDirection.y > 0)
        {
            animator.Play("Up");
        }
        else if (inputDirection.x < 0 && inputDirection.y > 0)
        {
            animator.Play("Left");
        }
        else if (inputDirection.x > 0 && inputDirection.y < 0)
        {
            animator.Play("Right");
        }
        else if (inputDirection.x < 0 && inputDirection.y < 0)
        {
            animator.Play("Down");
        }
    }
}
