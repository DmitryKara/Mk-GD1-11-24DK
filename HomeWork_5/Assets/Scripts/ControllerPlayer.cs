using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public VerticalCameraTilt verticalCameraTilt;
    public Transform cameraTransform;
    public float speed = 10.0f;
    public float mouseSensitivity = 20.0f;

    private CharacterController controller;
    private JumpController jumpController;

    public CharacterController Controller
    {
        get { return controller = controller ?? GetComponent<CharacterController>(); }
    }

    public JumpController JumpController
    {
        get { return jumpController = jumpController ?? GetComponent<JumpController>(); }
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        jumpController = GetComponent<JumpController>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed;
        Vector3 gravityMovement = new Vector3(0, jumpController.gravity, 0);
        Controller.Move((transform.TransformDirection(movement) + gravityMovement) * Time.deltaTime);

        transform.Rotate(Vector3.up, mouseX * mouseSensitivity * Time.deltaTime);

        verticalCameraTilt.UpdateVerticalTilt(new Vector2(0.0f, mouseY));

        jumpController.ApplyGravity();

        if (Input.GetKeyDown(KeyCode.Space) && Controller.isGrounded)
        {
            jumpController.Jump();
        }
    }
}
