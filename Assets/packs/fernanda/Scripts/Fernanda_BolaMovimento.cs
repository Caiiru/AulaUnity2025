using UnityEngine;

public class BolaMovimento : MonoBehaviour
{
    [SerializeField] float velocidade = 10f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.linearVelocity = Vector3.back * velocidade;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
    }
}
