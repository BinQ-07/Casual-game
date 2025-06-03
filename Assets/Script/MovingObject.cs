using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private Transform endTarget;
    [SerializeField] private float speed;

    public void Initialize(Transform target)
    {
        endTarget = target;
    }

    void Update()
    {
        if (endTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, endTarget.position, speed * Time.deltaTime);
        }
    }
}
