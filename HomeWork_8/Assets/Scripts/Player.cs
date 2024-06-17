using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool isRight = true;
    public Parallax parallax;

    private PlayerController controller;

    public void Awake()
    {
        controller = new PlayerController();
        controller.Enable();
    }

    private void Change_performed(InputAction.CallbackContext context)
    {
        Flip();
    }

    public void Flip()
    {
        isRight = !isRight;
        transform.rotation = isRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);

        if (parallax != null)
        {
            parallax.ChangeDirection();
        }
    }

    public void OnEnable()
    {
        controller.Direction.Change.performed += Change_performed;
    }

    public void OnDisable()
    {
        controller.Direction.Change.performed -= Change_performed;
    }
}
