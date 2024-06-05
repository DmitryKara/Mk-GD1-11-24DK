using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : CreateObject
{   
    public CreateObject[] shapePrefabs;
    private bool hasChangedShape = false;
    private CreateObject createObject;

    private void OnCollisionEnter(Collision collision)
    {      
            hasChangedShape = true;

            Destroy(createObject);

        CreateObject randomPrefab = shapePrefabs[Random.Range(0, shapePrefabs.Length)];
            Instantiate(randomPrefab, transform.position, transform.rotation);
    }
}
