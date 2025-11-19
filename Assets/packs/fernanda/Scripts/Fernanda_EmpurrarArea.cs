using UnityEngine;

public class AreaDeVento : MonoBehaviour
{
    [SerializeField] float forcaVento = 3f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bola"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Direção fixa global: Z negativo
                Vector3 direcao = Vector3.back;

                // Remove componente vertical
                direcao.y = 0;
                direcao.Normalize();

                // Aplica força contínua
                rb.AddForce(direcao * forcaVento * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
}
