using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public List<Material> materials;
    private Renderer render;

    public void Start()
    {
        render = GetComponent<Renderer>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        render.material = materials[Random.Range(0, materials.Count)];
    }
}
