using UnityEngine;

public class Melissa_2_Plataforma : MonoBehaviour
{
    public float descendSpeed = 20f;   // velocidade que a plataforma desce por segundo
    public float descendDistance = 70f; // dist�ncia total que a plataforma vai se mover para baixo

    private bool isTriggered = false;   // flag para garantir que a plataforma s� des�a uma vez
    private Vector3 targetPos;          // posi��o final de descida calculada ao ser acionada

    void OnCollisionEnter(Collision collision)
    {
        // detecta colis�o com um objeto chamado "Sphere"
        // s� dispara a primeira vez que a colis�o ocorre
        if (!isTriggered && collision.gameObject.name == "Sphere")
        {
            isTriggered = true;
            // calcula a posi��o alvo com base na dist�ncia de descida
            targetPos = transform.position + Vector3.down * descendDistance;
        }
    }

    void Update()
    {
        // se a plataforma foi acionada, move suavemente em dire��o � posi��o alvo
        if (isTriggered)
        {
            // MoveTowards garante que a plataforma se mova a uma velocidade constante, frame a frame
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                descendSpeed * Time.deltaTime // ajusta a velocidade pelo tempo de frame
            );
        }
    }
}
