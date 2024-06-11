using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IControllable
{
    public float speed = 10.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.0f;

    private float velocity;
    private CharacterController controller;
    private Vector3 moveDirection;
    private FootStepAudio footstepAudio;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        footstepAudio = GetComponent<FootStepAudio>();
    }

    public void FixedUpdate()
    {
        if (controller.isGrounded && velocity < 0)
        {
            velocity = -2.0f;
        }

        MoveInternal();
        DoGravity();
    }

    public void Move(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void MoveInternal()
    {
        if (moveDirection.magnitude > 0 && controller.isGrounded)
        {
            footstepAudio.PlayFootstep();
        }
        else
        {
            footstepAudio.StopFootstep();
        }

        controller.Move(moveDirection * speed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            velocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    public void DoGravity()
    {
        velocity += gravity * Time.fixedDeltaTime;

        controller.Move(Vector3.up * velocity * Time.fixedDeltaTime);
    }
}
