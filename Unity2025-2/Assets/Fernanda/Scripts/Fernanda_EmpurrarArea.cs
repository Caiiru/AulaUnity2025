using UnityEngine;

public class Fernanda_AreaDeVento : MonoBehaviour
{
    [SerializeField] float forcaVento = 3f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bola"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Dire��o fixa global: Z negativo
                Vector3 direcao = Vector3.back;

                // Remove componente vertical
                direcao.y = 0;
                direcao.Normalize();

                // Aplica for�a cont�nua
                rb.AddForce(direcao * forcaVento * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
    }
}
