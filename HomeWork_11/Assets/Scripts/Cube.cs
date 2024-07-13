using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class Cube : MonoBehaviour
{
    public Vector3 cubeSize = new Vector3(1.0f, 0.2f, 1.0f);

    void Start()
    {
        GenerateCubes();
    }

    public void GenerateCubes()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices =
        {
            // Низ
            new Vector3(0, 0, 0),
            new Vector3(cubeSize.x, 0, 0),
            new Vector3(cubeSize.x, 0, cubeSize.z),
            new Vector3(0, 0, cubeSize.z),

            // Верх
            new Vector3(0, cubeSize.y, 0),
            new Vector3(cubeSize.x, cubeSize.y, 0),
            new Vector3(cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(0, cubeSize.y, cubeSize.z),

            // Перед
            new Vector3(0, 0, cubeSize.z),
            new Vector3(cubeSize.x, 0, cubeSize.z),
            new Vector3(cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(0, cubeSize.y, cubeSize.z),

            // Зад
            new Vector3(0, 0, 0),
            new Vector3(cubeSize.x, 0, 0),
            new Vector3(cubeSize.x, cubeSize.y, 0),
            new Vector3(0, cubeSize.y, 0),

            // Левая грань
            new Vector3(0, 0, 0),
            new Vector3(0, 0, cubeSize.z),
            new Vector3(0, cubeSize.y, cubeSize.z),
            new Vector3(0, cubeSize.y, 0),

            // Правая грань
            new Vector3(cubeSize.x, 0, 0),
            new Vector3(cubeSize.x, 0, cubeSize.z),
            new Vector3(cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(cubeSize.x, cubeSize.y, 0)
        };

        int[] triangles =
        {
            0, 2, 1,
            0, 3, 2,

            7, 6, 5,
            7, 5, 4,

            8, 9, 10,
            8, 10, 11,

            12, 14, 13,
            12, 15, 14,

            16, 17, 18,
            16, 18, 19,

            20, 22, 21,
            20, 23, 22
        };

        Vector3[] normals =
        {
            Vector3.down, Vector3.down, Vector3.down, Vector3.down,

            Vector3.up, Vector3.up, Vector3.up, Vector3.up,

            Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward,

            Vector3.back, Vector3.back, Vector3.back, Vector3.back,

            Vector3.left, Vector3.left, Vector3.left, Vector3.left,

            Vector3.right, Vector3.right, Vector3.right, Vector3.right
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.RecalculateNormals();
    }
}
