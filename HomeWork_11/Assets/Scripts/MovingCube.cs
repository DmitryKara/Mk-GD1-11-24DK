using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static MovingCube LastCube { get; private set; }
    public MoveDirection MoveDirection { get; set; }

    public Vector3 cubeSize = new Vector3(1.0f, 0.2f, 1.0f);

    [SerializeField] private float moveSpeed = 1.0f;
    private static bool isFirstCube = true;

    private void OnEnable()
    {
        if (LastCube == null)
        {
            LastCube = GameObject.Find("Platform").GetComponent<MovingCube>();
        }

        CurrentCube = this;
        GetComponent<Renderer>().material.color = GetRandomColor();

        if (LastCube != null)
        {
            transform.localScale = new Vector3(LastCube.transform.localScale.x, transform.localScale.y, LastCube.transform.localScale.z);
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    internal void Stop()
    {
        moveSpeed = 0.0f;

        if (isFirstCube)
        {
            isFirstCube = false;
            LastCube = this;
            return;
        }

        float hangover = GetHangover();

        float max = MoveDirection == MoveDirection.Z ? LastCube.transform.localScale.z : LastCube.transform.localScale.x;

        if (Mathf.Abs(hangover) >= max)
        {
            LastCube = null;
            CurrentCube = null;

            SceneManager.LoadScene(0);
            isFirstCube = true;
            return;
        }

        float direction = hangover > 0 ? 1.0f : -1.0f;

        if (MoveDirection == MoveDirection.Z)
        {
            SplitCubeOnZ(hangover, direction);
        }
        else
        {
            SplitCubeOnX(hangover, direction);
        }

        LastCube = this;
    }

    private float GetHangover()
    {
        return MoveDirection == MoveDirection.Z ?
            transform.position.z - LastCube.transform.position.z :
            transform.position.x - LastCube.transform.position.x;
    }

    private void SplitCubeOnX(float hangover, float direction)
    {
        float newXSize = LastCube.transform.localScale.x - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.x - newXSize;

        float newXPosition = hangover < 0 ? LastCube.transform.position.x : LastCube.transform.position.x + hangover;
        transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        float fallingBlockXPosition = hangover < 0 ?
            transform.position.x - fallingBlockSize :
            transform.position.x + newXSize * direction;

        SpawnDropCube(fallingBlockXPosition, fallingBlockSize);
    }

    private void SplitCubeOnZ(float hangover, float direction)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;

        float newZPosition = hangover < 0 ? LastCube.transform.position.z : LastCube.transform.position.z + hangover;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float fallingBlockZPosition = hangover < 0 ?
            transform.position.z - fallingBlockSize :
            transform.position.z + newZSize * direction;

        SpawnDropCube(fallingBlockZPosition, fallingBlockSize);
    }

    private void SpawnDropCube(float fallingBlockPosition, float fallingBlockSize)
    {
        GameObject cube = new GameObject("FallingCube");

        if (MoveDirection == MoveDirection.Z)
        {
            cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockPosition);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize, transform.localScale.y, transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockPosition, transform.position.y, transform.position.z);
        }

        cube.AddComponent<Cube>();
        cube.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
        cube.AddComponent<Rigidbody>();

        Destroy(cube.gameObject, 1.0f);
    }

    private void Update()
    {
        if (moveSpeed > 0)
        {
            Vector3 moveOffset = MoveDirection == MoveDirection.Z ?
                transform.position -= transform.forward * moveSpeed * Time.deltaTime :
                transform.position -= transform.right * moveSpeed * Time.deltaTime;
        }
    }
}