using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;

    private Vector3 target;

    private void Start()
    {
        target = pointB.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position,pointA.position)<0.01f)
        {
            target = pointB.position;
            Debug.Log($"Ha raggiunto la posizione {pointB.position}");
        }

        else if(Vector3.Distance(transform.position,pointB.position)<0.01f)
        {
            target = pointA.position;
            Debug.Log($"Ha raggiunto la posizione{pointA.position}");
        }
    }

}
