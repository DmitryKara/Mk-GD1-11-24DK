using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private MoveDirection moveDirection;
    [SerializeField] private Camera cameraPlayer;

    public void SpawnCube(Vector3 spawnPosition, Vector3 cubeSize, MoveDirection moveDir)
    {
        GameObject cube = new GameObject("MovingCube");

        cube.AddComponent<MeshFilter>();
        cube.AddComponent<MeshRenderer>();
        var movingCube = cube.AddComponent<MovingCube>();
        var cubeGenerator = cube.AddComponent<Cube>();

        cubeGenerator.cubeSize = cubeSize;
        cubeGenerator.GenerateCubes();

        cube.transform.position = spawnPosition;
        movingCube.MoveDirection = moveDir;
        movingCube.cubeSize = cubeSize;

        cameraPlayer.transform.position = new Vector3(
            cameraPlayer.transform.position.x,
            cameraPlayer.transform.position.y + cubeSize.y,
            cameraPlayer.transform.position.z
        );
    }
}
