using UnityEngine;

public class MoveGun : MonoBehaviour
{
    void Update()
    {
        float rotationUP = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.left, rotationUP);
    }
}
