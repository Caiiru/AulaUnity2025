using UnityEngine;

public class Wilson_crash : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Destroyable")) 
        {

            IBreakable breakable = collision.collider.GetComponent<IBreakable>();

            if (breakable != null && gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude >= 2)
            {

                breakable.Break();

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
  