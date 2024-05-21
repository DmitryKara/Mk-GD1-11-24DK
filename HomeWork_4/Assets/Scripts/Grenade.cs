using System.Collections;
using UnityEngine;

public class Grenade : Projectils
{
    public float radius;
    public float forceExplosion;

    public void Start()
    {
        StartCoroutine(Countdown(5.0f));
    }

    public void OnCollisionEnter(Collision collision)
    {      
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            StopAllCoroutines();
            Explosion();
        }
    }

    IEnumerator Countdown(float time)
    {
        yield return new WaitForSeconds(time);
        Explosion();
    }

    public void Explosion()
    {
        Collider[] searchOtherCollider = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < searchOtherCollider.Length; i++)
        {
            Rigidbody rigidbody = searchOtherCollider[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(forceExplosion, transform.position, radius, 1.0f);
            }
        }

        Destroy(gameObject);
    }
}
