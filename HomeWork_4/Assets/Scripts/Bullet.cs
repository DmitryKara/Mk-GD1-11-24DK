using UnityEngine;

public class Bullet : Projectils
{
    public void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
