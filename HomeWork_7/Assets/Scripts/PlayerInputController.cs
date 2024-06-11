using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Transform playerCamera;
    private IControllable iControllable;
    private PlayerController playerController;   

    public void Awake()
    {
        playerController = new PlayerController();
        playerController.Enable();

        iControllable = GetComponent<IControllable>();

        if (iControllable == null )
        {
            Debug.Log("Controllable is NULL!!");
        }
    }

    public void OnEnable()
    {
        playerController.Gameplay.Jump.performed += Jump_performed;
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        iControllable.Jump();
    }

    public void OnDisable()
    {
        playerController.Gameplay.Jump.performed -= Jump_performed;
    }

    public void Update()
    {
        var inputDirection = playerController.Gameplay.Movement.ReadValue<Vector2>();
        var cameraForward = playerCamera.forward;
        cameraForward.y = 0;
        var direction = cameraForward.normalized * inputDirection.y + playerCamera.right * inputDirection.x;

        iControllable.Move(direction);
    }
}
