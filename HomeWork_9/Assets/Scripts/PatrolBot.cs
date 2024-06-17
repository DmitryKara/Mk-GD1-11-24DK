using UnityEngine;

public class PatrolBot : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float speed = 2f;

    private Transform currentTarget;
    private Vector3 initialScale;

    void Start()
    {
        currentTarget = targetPosition;
        initialScale = transform.localScale;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.01f)
        {
            if (currentTarget == startPosition)
            {
                currentTarget = targetPosition;
                FlipSprite(true);
            }
            else
            {
                currentTarget = startPosition;
                FlipSprite(false);
            }
        }
    }

    void FlipSprite(bool faceRight)
    {
        if (faceRight)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
    }
}
