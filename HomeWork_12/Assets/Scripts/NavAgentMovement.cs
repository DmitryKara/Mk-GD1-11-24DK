using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NavAgentMovement : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    public float normalSpeed = 3.5f;
    public float swampSpeed = 1.5f;
    public string swampAreaName = "Swamp";
    public float samplePositionRadius = 1.0f;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = new PlayerController();
        playerController.Enable();
    }

    private void OnEnable()
    {
        playerController.Gameplay.Mouse.performed += Mouse_Performed;
    }

    private void OnDisable()
    {
        playerController.Gameplay.Mouse.performed -= Mouse_Performed;
    }

    private void Mouse_Performed(InputAction.CallbackContext context)
    {
        OnClickMouse();
    }

    private void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed;
    }

    private void Update()
    {
        CheckAgentArea();
        cam.transform.position = new Vector3(agent.transform.position.x, cam.transform.position.y, agent.transform.position.z);
    }

    private void OnClickMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, 1.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(navHit.position);
            }
        }
    }

    private void CheckAgentArea()
    {
        if (agent.isOnNavMesh)
        {
            if (NavMesh.SamplePosition(agent.transform.position, out NavMeshHit hit, samplePositionRadius, NavMesh.AllAreas))
            {
                int swampAreaIndex = NavMesh.GetAreaFromName(swampAreaName);
                if ((hit.mask & (1 << swampAreaIndex)) != 0)
                {
                    agent.speed = swampSpeed;
                }
                else
                {
                    agent.speed = normalSpeed;
                }
            }
        }
    }
}