using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed;

    public void Update()
    {
        Vector3 cameraPosition = player.position + offset;
        Vector3 cameraMove = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed);
        transform.position = new Vector3(cameraMove.x, cameraMove.y, transform.position.z);
    }
}
