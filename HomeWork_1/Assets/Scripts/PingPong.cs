using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Vector3 direction = new Vector3(1.0f, 0, 0);
    public float speed = 1.0f;

    public void Update()
    {
        if (transform.position.x >= 10.0f)
        {
            direction = -direction;
        }
        else if (transform.position.x <= -10.0f)
        {
            direction = -direction;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}
