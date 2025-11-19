using UnityEngine;

public class Alessandro_MoveObstaculo2 : MonoBehaviour
{
    public float distancia = 4.5f;   // amplitude do movimento
    public float velocidade = 2f;  // velocidade da oscilação
    public bool inverterInicio = false; // se true, começa do lado oposto

    private Vector3 posicaoInicial;
    private float faseInicial;

    void Start()
    {
        posicaoInicial = transform.position;

        // Se inverterInicio for true, começa com 180° de diferença (π radianos)
        faseInicial = inverterInicio ? Mathf.PI : 0f;
    }

    void Update()
    {
        float deslocamento = Mathf.Sin(Time.time * velocidade + faseInicial) * distancia;
        transform.position = posicaoInicial + Vector3.right * deslocamento;
    }
}
