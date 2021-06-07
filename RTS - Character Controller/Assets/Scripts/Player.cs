using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    public Camera cam;
    public Vector3 cameraOffset;
    public LayerMask groundMask;
    public GameObject targetIndicator; //making later in the video...

    private NavMeshAgent agent;
    private GameObject targetObject;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (targetIndicator)
        {
            targetObject = Instantiate(targetIndicator.gameObject);
            targetObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MoveToTarget(Input.mousePosition);
        }
        CameraMovement();
    }

    private void CameraMovement()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + cameraOffset, 0.5f);
        cam.transform.LookAt(transform);
    }

    private void MoveToTarget(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, groundMask))
        {
            agent.destination = hit.point;
            if (targetObject)
            {
                targetObject.transform.position = agent.destination;
                targetObject.SetActive(true);
            }
        }
    }
}