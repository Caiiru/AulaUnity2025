using UnityEngine;

public class Javier_GameManager : MonoBehaviour
{
    // Padr�o Singleton: permite que este script seja facilmente acessado de qualquer outro script
    public static Javier_GameManager instance;

    [Header("Configura��es de Respawn")]
    [Tooltip("Onde a bola deve nascer/renascer.")]
    public Transform pontoDeRespawn;

    [Tooltip("O prefab da bola que ser� criado.")]
    public GameObject prefabDaBola;

    private void Awake()
    {
        // Configura��o do Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Cria a primeira bola no in�cio do jogo
        if (prefabDaBola != null && pontoDeRespawn != null)
        {
            Instantiate(prefabDaBola, pontoDeRespawn.position, pontoDeRespawn.rotation);
        }
    }

    public void RespawnBola()
    {
        // Fun��o que ser� chamada quando a bola "morrer"
        Instantiate(prefabDaBola, pontoDeRespawn.position, pontoDeRespawn.rotation);
    }
}