using UnityEngine;

public class Robot : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;

        if (sideForce != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;

        if (forwardForce != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }
    }
}
