using UnityEngine;

public class Juan_JogadorAgua : MonoBehaviour
{
    [Header("Referências")]
    public Transform sol;              
    public Transform pontoRespawn;     

    [Header("Configurações de Escala")]
    public float velocidadeEvaporar = 0.5f; // diminui por segundo
    public float velocidadeRecuperar = 0.3f; // cresce por segundo
    public float escalaMinima = 0.1f;       

    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        if (Evaporando()) // está no sol
        {
            // diminui a escala até o mínimo
            transform.localScale -= Vector3.one * velocidadeEvaporar * Time.deltaTime;

            if (transform.localScale.x <= escalaMinima)
            {
                Reaparecer();
            }
        }
        else // está na sombra
        {
            // cresce de volta até a escala original
            transform.localScale = Vector3.MoveTowards(
                transform.localScale,
                escalaOriginal,
                velocidadeRecuperar * Time.deltaTime
            );
        }
    }

    bool Evaporando()
    {
        // Raycast do sol até o jogador
        Vector3 direcao = transform.position - sol.position;

        if (Physics.Raycast(sol.position, direcao, out RaycastHit hit))
        {
            // Se o primeiro objeto atingido é o jogador → está exposto
            if (hit.transform == transform)
            {
                return true;
            }
        }
        return false;
    }

    void Reaparecer()
    {
        // Volta ao respawn com tamanho original
        transform.position = pontoRespawn.position;
        transform.localScale = escalaOriginal;
    }
}
