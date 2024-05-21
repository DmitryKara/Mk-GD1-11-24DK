using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreThePyramid : MonoBehaviour
{
    public Vector3 currentPosition;
    public Quaternion currentRotation;

    public void Start()
    {
        currentPosition = transform.position;
        currentRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetItem();
        }
    }

    public void ResetItem()
    {
        Rigidbody targetBody = GetComponent<Rigidbody>();

        if (targetBody != null)
        {
            targetBody.velocity = Vector3.zero;
            targetBody.angularVelocity = Vector3.zero;
        }

        transform.rotation = currentRotation;
        transform.position = currentPosition;
    }
}
