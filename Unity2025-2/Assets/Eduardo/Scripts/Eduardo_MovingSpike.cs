using UnityEngine;

public class Eduardo_MovingSpike : MonoBehaviour
{
    [SerializeField] public float speed = 2f;       
    [SerializeField] public float moveDistance = 5f; 

    [SerializeField] private float startZ;
    [SerializeField] private int direction = 1; 

    void Start()
    {
        startZ = transform.position.z;
    }

    void Update()
    {
        float targetZ = startZ + moveDistance * direction;

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZ);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.z - targetZ) < 0.01f)
        {
            direction *= -1;       
            startZ = transform.position.z; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); 
        }
    }
}