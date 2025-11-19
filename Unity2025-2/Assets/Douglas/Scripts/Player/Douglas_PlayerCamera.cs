using UnityEngine;

public class Douglas_PlayerCamera : MonoBehaviour
{
   [Header("Camera Target")]
   [Tooltip("Posicao do alvo que a camera vai seguir.")]
    [SerializeField] private Transform target;

    [Header("Camera Parameters")]
    [Tooltip("Distancia da camera em relacao ao alvo.")]
    [SerializeField] private float distance = 6f;
    [Tooltip("Altura da camera em relacao ao alvo.")]
    [SerializeField] private float height = 3f;
    [Tooltip("Suavidade da transicao da camera.")]
    [SerializeField] private float smoothness = 10f;

    void LateUpdate() // é chamada uma vez por frame, assim como o Update, mas com uma diferença crucial: ela é garantida a rodar DEPOIS que todas as funções Update de todos os scripts já terminaram.
    {
        Vector3 targetPosition = target.position - (target.forward * distance); // Variavel do tipo Vector3 que recebe o valor da posicao do alvo - a posicao da frente do alvo * distancia, ou seja, cria uma distancia pra camera ficar do alvo.
        targetPosition.y = target.position.y + height; // Garante que a altura da camera sempre seja a posicao do alvo mais uma altura predefinida 
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime); // Faz uma transicao da posicao do primeiro parametro ate o segundo, em um tempo igual ao valor do terceiro parametro.
        transform.LookAt(target.transform); // forca a camera a olhar na direcao do parametro.
    }
}
