using UnityEngine;

public class MoveObstaculoFrenteTras : MonoBehaviour
{
    public float distancia = 3f;   // distância máxima que o obstáculo se move
    public float velocidade = 2f;  // velocidade da oscilação
    public bool inverterInicio = false; // começa no sentido contrário

    private Vector3 posicaoInicial;
    private float faseInicial;

    void Start()
    {
        posicaoInicial = transform.position;

        // se inverterInicio for true, começa na fase oposta (180° de diferença)
        faseInicial = inverterInicio ? Mathf.PI : 0f;
    }

    void Update()
    {
        // movimento suave para frente e para trás no eixo Z
        float deslocamento = Mathf.Sin(Time.time * velocidade + faseInicial) * distancia;
        transform.position = posicaoInicial + Vector3.forward * deslocamento;
    }
}
