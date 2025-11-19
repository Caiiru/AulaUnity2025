using UnityEngine;

public class Alessandro_MoveObstaculoFrenteTras : MonoBehaviour
{
    public float distancia = 3f;   // dist�ncia m�xima que o obst�culo se move
    public float velocidade = 2f;  // velocidade da oscila��o
    public bool inverterInicio = false; // come�a no sentido contr�rio

    private Vector3 posicaoInicial;
    private float faseInicial;

    void Start()
    {
        posicaoInicial = transform.position;

        // se inverterInicio for true, come�a na fase oposta (180� de diferen�a)
        faseInicial = inverterInicio ? Mathf.PI : 0f;
    }

    void Update()
    {
        // movimento suave para frente e para tr�s no eixo Z
        float deslocamento = Mathf.Sin(Time.time * velocidade + faseInicial) * distancia;
        transform.position = posicaoInicial + Vector3.forward * deslocamento;
    }
}
