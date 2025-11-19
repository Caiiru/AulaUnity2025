using UnityEngine;

public class Douglas_PendulumColision : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float power = 100f;
    
        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 collisionDirection = (collision.transform.position - transform.position).normalized;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(collisionDirection * power, ForceMode.Impulse);
        }
    }
}
