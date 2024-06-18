using UnityEngine;

public class VerticalCameraTilt : MonoBehaviour
{
    public Transform headTransform;
    public float speed = 30f;
    public float maxVerticalAngle = 30f;
    public float minVerticalAngle = -30f;

    private float verticalLookRotation = 0f;

    public void UpdateVerticalTilt(Vector2 input)
    {
        verticalLookRotation -= input.y * Time.deltaTime * speed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, minVerticalAngle, maxVerticalAngle);
        headTransform.localEulerAngles = new Vector3(verticalLookRotation, headTransform.localEulerAngles.y, 0f);
    }
}
