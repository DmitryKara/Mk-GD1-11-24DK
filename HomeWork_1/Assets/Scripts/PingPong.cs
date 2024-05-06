using System.Collections;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Vector3 newPoint;
    //public Transform object1;
    public float speed;
    public Vector3 currentPosition;

    public void Start()
    {
        speed = 0.01f;
        currentPosition = transform.position;
        newPoint = new Vector3(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f));
        StartCoroutine(PlusSpeed());
    }

    IEnumerator PlusSpeed()
    {
        while (speed <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            speed += 0.01f;
            transform.position = Vector3.Lerp(currentPosition, newPoint, speed);
        }
        StartCoroutine(MinusSpeed());
    }

    IEnumerator MinusSpeed()
    {
        while (speed >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            speed -= 0.01f;
            transform.position = Vector3.Lerp(currentPosition, newPoint, speed);
        }
        StartCoroutine(PlusSpeed());
    }
}
