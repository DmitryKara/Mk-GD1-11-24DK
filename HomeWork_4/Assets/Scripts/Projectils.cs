using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectils : MonoBehaviour
{  
    public float force;

    public virtual void Launch(Vector3 direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}
