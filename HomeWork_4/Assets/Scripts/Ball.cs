using UnityEngine;

public class Ball : Projectils
{
    public void Start()
    {
        Destroy(gameObject, 10.0f);
    }
}
