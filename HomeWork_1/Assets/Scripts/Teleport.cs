using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float timeSpawn = 3.0f;
    public int numberOfTeleport = 10;

    public void Start()
    {
        InvokeRepeating("Spawn", 0, timeSpawn);
    }

    public void Spawn()
    {
        for (int i = 0; i <= numberOfTeleport; i++)
        {
            transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        }
    }
}
