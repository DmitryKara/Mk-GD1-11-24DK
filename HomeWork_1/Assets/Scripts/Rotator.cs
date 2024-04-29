using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}