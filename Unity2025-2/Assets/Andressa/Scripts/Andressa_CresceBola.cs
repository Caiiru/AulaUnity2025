using UnityEngine;

public class Andressa_CresceBola : MonoBehaviour
{
    [SerializeField] private float growFactor = 2f; // quanto a bola cresce
    [SerializeField] private Transform pontoInicial; // ponto para onde a bola volta

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto com o qual a bola colidiu tem a tag "lapide"
        if (collision.gameObject.CompareTag("lapide"))
        {
            // Aumenta a escala da bola
            Vector3 newScale = transform.localScale * growFactor;
            transform.localScale = newScale;

            // Volta para o ponto inicial mantendo o novo tamanho
            if (pontoInicial != null)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero; // zera a velocidade
                    rb.angularVelocity = Vector3.zero;
                }

                transform.position = pontoInicial.position; // volta pro início
            }
        }
    }
}
