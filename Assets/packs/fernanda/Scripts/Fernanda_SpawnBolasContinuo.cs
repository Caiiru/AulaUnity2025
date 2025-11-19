using UnityEngine;
using System.Collections;

public class SpawnBolasContinuoComMovimento : MonoBehaviour
{
    [SerializeField] GameObject prefabBola; // Prefab da bola
    [SerializeField] Transform pontoSpawn;  // Objeto vazio como refer�ncia
    [SerializeField] float intervalo = 5f;  // Intervalo em segundos
    [SerializeField] float velocidade = 5f; // Velocidade da bola

    void Start()
    {
        StartCoroutine(SpawnBolas());
    }

    IEnumerator SpawnBolas()
    {
        while (true)
        {
            // Instancia a bola no ponto de spawn
            GameObject bola = Instantiate(prefabBola, pontoSpawn.position, Quaternion.identity);

            // Gera cor aleat�ria
            Color corAleatoria = new Color(Random.value, Random.value, Random.value);
            Renderer rend = bola.GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = corAleatoria;

            // Adiciona um Rigidbody se n�o tiver (para aplicar movimento)
            Rigidbody rb = bola.GetComponent<Rigidbody>();
            if (rb == null)
                rb = bola.AddComponent<Rigidbody>();

            // Aplica velocidade cont�nua para a dire��o back
            rb.linearVelocity = Vector3.back * velocidade;

            yield return new WaitForSeconds(intervalo);
        }
    }
}
