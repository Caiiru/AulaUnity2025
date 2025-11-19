using UnityEngine;

public class Andressa_ColisaoCubos : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public Transform startPoint;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            transform.position = startPoint.position;
        }
    }
   
}
