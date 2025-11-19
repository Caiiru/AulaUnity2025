using UnityEngine;

public class Andressa_CameraFollow : MonoBehaviour
{
    [Header("Alvo a seguir (Jogador)")]
    public Transform target;

    [Header("Posição da câmera em relação ao jogador")]
    public float height = 5f;
    public float distance = 7f;

    [Header("Velocidade de suavização")]
    public float positionSmoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    [Header("Suavidade de rotação")]
    public float rotationSmoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // === Direção fixa atrás do jogador no eixo X ===
        Vector3 behindDirection = -Vector3.right; // Eixo X negativo → “atrás” da bola
        Vector3 desiredPosition = target.position + behindDirection * distance + Vector3.up * height;

        // Movimento suave
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, positionSmoothTime);

        // Faz a câmera olhar para a bola (mas de forma suave)
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}
