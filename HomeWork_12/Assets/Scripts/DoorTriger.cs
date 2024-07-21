using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform door;
    public float openHeight = 5f;
    public float speed = 2f;
    public NavMeshSurface navMeshSurface;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private Coroutine doorCoroutine;

    private void Start()
    {
        closedPosition = door.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleDoorMovement(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        HandleDoorMovement(other, false);
    }

    private void HandleDoorMovement(Collider other, bool open)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 targetPosition = open ? openPosition : closedPosition;

            if (doorCoroutine != null)
                StopCoroutine(doorCoroutine);

            doorCoroutine = StartCoroutine(MoveDoor(targetPosition));
        }
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(door.position, targetPosition) > 0.01f)
        {
            door.position = Vector3.Lerp(door.position, targetPosition, Time.deltaTime * speed);

            if (navMeshSurface != null)
            {
                navMeshSurface.BuildNavMesh();
            }

            yield return null;
        }
        door.position = targetPosition;

        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
        }
    }
}
