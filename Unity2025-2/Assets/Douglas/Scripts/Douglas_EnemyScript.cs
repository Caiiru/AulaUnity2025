using UnityEngine;

public class Douglas_EnemyScript : MonoBehaviour
{
    [Header("References")]
    private Rigidbody rb;
    private Douglas_EnemyManager enemyManager;

    [Header("Parameters")]
    [SerializeField] public float enemySpeed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        enemyManager = FindObjectOfType<Douglas_EnemyManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward *  enemySpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            float randomAngle = Random.Range(120f, 240f);
            transform.Rotate(0f, randomAngle, 0f);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TRON"))
        {
            if(enemyManager != null)
                enemyManager.EnemyDestroyed();
            
            Destroy(gameObject);

        }
    }
}
