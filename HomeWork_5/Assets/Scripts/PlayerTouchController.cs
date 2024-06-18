using UnityEngine;

public class PlayerTouchController : MonoBehaviour
{
    public RectTransform jumpArea;
    public VerticalCameraTilt verticalCameraTilt;
    public SimpleTouchController leftController;
    public SimpleTouchController rightController;
    public Transform headTrans;
    public float speedMovements = 5f;
    public float speedContinuousLook = 30f;
    public float speedProgressiveLook = 30f;

    private CharacterController _characterController;
    private JumpController jumpController;
    [SerializeField] bool continuousRightController = true;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        jumpController = GetComponent<JumpController>();
        rightController.TouchEvent += RightController_TouchEvent;
    }

    public bool ContinuousRightController
    {
        set { continuousRightController = value; }
    }

    void RightController_TouchEvent(Vector2 value)
    {
        if (!continuousRightController)
        {
            verticalCameraTilt.UpdateVerticalTilt(value);
        }
    }

    void Update()
    {
        Vector3 moveDirection = (transform.forward * leftController.GetTouchPosition.y +
                                 transform.right * leftController.GetTouchPosition.x) *
                                 speedMovements * Time.deltaTime;

        _characterController.Move(moveDirection);

        if (continuousRightController)
        {
            transform.Rotate(Vector3.up, rightController.GetTouchPosition.x * Time.deltaTime * speedProgressiveLook);
            verticalCameraTilt.UpdateVerticalTilt(rightController.GetTouchPosition);
        }

        jumpController.ApplyGravity();

        if (_characterController.isGrounded && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && IsInJumpArea())
        {
            jumpController.Jump();
        }
    }

    bool IsInJumpArea()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 worldPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(jumpArea, touchPosition, null, out worldPoint);
            return jumpArea.rect.Contains(worldPoint);
        }
        return false;
    }

    void OnDestroy()
    {
        rightController.TouchEvent -= RightController_TouchEvent;
    }
}
