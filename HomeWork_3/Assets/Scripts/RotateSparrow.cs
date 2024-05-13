using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float speed;
    private float returnSpeed;
    private Vector2 lastPosition;
    private Quaternion startRotation;

    public void Start()
    {
        startRotation = transform.rotation;
        speed = 0.5f;
        returnSpeed = 5.0f;
    }
    public void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float rotationY = (touch.position.x - lastPosition.x) * speed;
                transform.Rotate(Vector3.up, rotationY, Space.World);
                lastPosition = touch.position;
            }
        }
        else if (Input.touchCount == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, returnSpeed * Time.deltaTime);
        }
    }
}
