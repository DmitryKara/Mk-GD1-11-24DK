using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    private Spawner[] spawners;
    private Spawner currentSpawner;
    private int spawnerIndex;
    private GameInputController inputController;

    private void Awake()
    {
        inputController = new GameInputController();
        inputController.Enable();
        spawners = FindObjectsOfType<Spawner>();
    }

    public void OnEnable()
    {
        inputController.SpawnCube.Keyboard.performed += Spawn_Cube;
    }

    public void OnDisable()
    {
        inputController.SpawnCube.Keyboard.performed -= Spawn_Cube;
    }

    private void Spawn_Cube(InputAction.CallbackContext context)
    {
        Spawn();
    }

    private void Spawn()
    {
            if (MovingCube.CurrentCube != null)
            {
                MovingCube.CurrentCube.Stop();
            }

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            Vector3 cubeSize = new Vector3(1.0f, 0.2f, 1.0f);
            Vector3 spawnPosition;

            if (MovingCube.LastCube != null)
            {
                spawnPosition = new Vector3(
                    spawnerIndex == 0 ? currentSpawner.transform.position.x : MovingCube.LastCube.transform.position.x,
                    MovingCube.LastCube.transform.position.y + cubeSize.y,
                    spawnerIndex == 0 ? MovingCube.LastCube.transform.position.z : currentSpawner.transform.position.z
                );
            }
            else
            {
                return;
            }

            currentSpawner.SpawnCube(spawnPosition, cubeSize, spawnerIndex == 0 ? MoveDirection.X : MoveDirection.Z);
    }
}