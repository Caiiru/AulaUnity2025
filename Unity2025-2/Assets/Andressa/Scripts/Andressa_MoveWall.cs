using System.Collections;
using UnityEngine;

public class Andressa_MovingWall : MonoBehaviour
{
    // A velocidade de movimento
    public float speed = 2.0f;

    // A posi��o final quando desce
    public Transform downPosition;

    // A posi��o inicial quando sobe
    private Vector3 initialPosition;

    // O tempo que a parede fica em baixo
    public float waitTime = 2.0f;

    void Start()
    {
        // Salva a posi��o inicial da parede
        initialPosition = transform.position;

        // Inicia a coroutine que controla o ciclo de movimento
        StartCoroutine(MoveWallRoutine());
    }

    IEnumerator MoveWallRoutine()
    {
        while (true)
        {
            // Move a parede para baixo
            yield return StartCoroutine(MoveToPosition(downPosition.position));

            // Espera pelo tempo definido
            yield return new WaitForSeconds(waitTime);

            // Move a parede de volta para cima
            yield return StartCoroutine(MoveToPosition(initialPosition));

            // Espera antes de reiniciar o ciclo, se necess�rio
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        // Enquanto n�o chegou na posi��o alvo
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // Move um pouco em dire��o ao alvo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null; // Espera 1 frame e continua
        }
    }
}