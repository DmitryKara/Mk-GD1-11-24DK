using UnityEngine;

public class JumpController : MonoBehaviour
{
    public CharacterController characterController;
    public float jumpPower = 3.0f;
    public float gravity = -9.81f;

    private float velocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Jump()
    {
        velocity = Mathf.Sqrt(jumpPower * -2.0f * gravity);
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity < 0)
        {
            velocity = -2.0f;
        }
        else
        {
            velocity += gravity * Time.deltaTime;
        }

        characterController.Move(Vector3.up * velocity * Time.deltaTime);
    }
}
