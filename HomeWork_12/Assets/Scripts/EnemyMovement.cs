using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 10f;

    private Vector3 patrolDirection;
    private Vector3 targetPosition;

    void Start()
    {
        patrolDirection = Vector3.right;
        targetPosition = transform.TransformPoint(patrolDirection * patrolDistance);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        patrolDirection = -patrolDirection;

        targetPosition = transform.TransformPoint(patrolDirection * patrolDistance);
    }
}
