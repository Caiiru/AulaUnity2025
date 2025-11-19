using UnityEngine;

public class Alvo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plataforma"))
        {
            Destroy(other.gameObject);
        }
    }
}
