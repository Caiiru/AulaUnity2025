using UnityEngine;
using UnityEngine.InputSystem;

public class Juan_Camera : MonoBehaviour
{
    public Transform alvo;        
    public float distancia = 8f;         // distância inicial
    public float zoomMin = 3f;          
    public float zoomMax = 15f;         
    public float zoomVelocidade = 2f;   

    [Header("Orbit")]
    public float sensibilidadeX = 120f;  // velocidade rotação no eixo horizontal
    public float sensibilidadeY = 80f;   // velocidade rotação no eixo vertical
    public float limiteYMin = -20f;      // ângulo mínimo de inclinação
    public float limiteYMax = 60f;       // ângulo máximo de inclinação

    private float anguloX = 0f;
    private float anguloY = 20f; // posição inicial um pouco inclinada

    void LateUpdate()
    {
        if (alvo == null) return;

        // --- Novo Input System (Mouse.current) com fallback para o sistema antigo ---
        var mouse = Mouse.current;
        if (mouse != null)
        {
            // Scroll
            float scroll = mouse.scroll.ReadValue().y;
            distancia -= scroll * zoomVelocidade;
            distancia = Mathf.Clamp(distancia, zoomMin, zoomMax);

            // Orbit com botão direito
            if (mouse.rightButton.isPressed)
            {
                Vector2 delta = mouse.delta.ReadValue();
                anguloX += delta.x * sensibilidadeX * Time.deltaTime;
                anguloY -= delta.y * sensibilidadeY * Time.deltaTime;
                anguloY = Mathf.Clamp(anguloY, limiteYMin, limiteYMax);
            }
        }
        else
        {
            // Fallback para Input legado (compatibilidade)
            float scroll = Input.GetAxis("Mouse ScrollWheel"); 
            distancia -= scroll * zoomVelocidade;
            distancia = Mathf.Clamp(distancia, zoomMin, zoomMax);

            if (Input.GetMouseButton(1))
            {
                anguloX += Input.GetAxis("Mouse X") * sensibilidadeX * Time.deltaTime;
                anguloY -= Input.GetAxis("Mouse Y") * sensibilidadeY * Time.deltaTime;
                anguloY = Mathf.Clamp(anguloY, limiteYMin, limiteYMax);
            }
        }

        // Constrói a rotação a partir dos ângulos
        Quaternion rotacao = Quaternion.Euler(anguloY, anguloX, 0);

        // Calcula a posição da câmera atrás do alvo
        Vector3 posicao = rotacao * new Vector3(0, 0, -distancia) + alvo.position;

        // Aplica
        transform.rotation = rotacao;
        transform.position = posicao;
    }
}