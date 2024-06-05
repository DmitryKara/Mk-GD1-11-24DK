using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public new List<GameObject> gameObject;

    private GameObject instance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameObject == null || gameObject.Count == 0)
            {
                Debug.LogError("GameObject is NULL!!!");
                return;
            }

            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(0.5f, 5.0f), Random.Range(-5.0f, 5.0f));
            instance = Instantiate(gameObject[Random.Range(0, gameObject.Count)], position, rotation);

            instance.AddComponent<RandomMovement>();
        }
    }
}
