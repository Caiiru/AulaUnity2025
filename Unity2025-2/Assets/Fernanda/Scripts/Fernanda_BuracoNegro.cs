using UnityEngine;

public class Fernanda_Alvo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plataforma"))
        {
            Destroy(other.gameObject);
        }
    }
}
