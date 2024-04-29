using UnityEngine;

public class Scaler : MonoBehaviour
{
    public Vector3 direction = new Vector3(1.0f, 1.0f, 1.0f);
    public float maxSize = 10.0f;
    public float speed = 1.0f;


    void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale += direction * speed * Time.deltaTime;
        }
    }
}
