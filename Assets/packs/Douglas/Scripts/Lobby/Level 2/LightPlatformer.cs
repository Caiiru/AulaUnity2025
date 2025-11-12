using UnityEngine;

public class LightPlatformer : MonoBehaviour
{

    [Header("Parameters")]
    [Tooltip("A plataforma esta ativa?")]
    [SerializeField] private bool activated = false;

    [Header("References")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Collider colider;
    [SerializeField] private Renderer render;

    void Awake()
    {
        gameManager = GameObject.FindFirstObjectByType<GameManager>(); // Procura e atribui o objeto gameManager a variavel 
        colider = gameObject.GetComponent<Collider>(); // Pega o componente e vincula a variavel
        render = gameObject.GetComponent<Renderer>(); // Pega o componente e vincula a variavel
    }

    void Update()
    {
        if (gameManager.lightsOn) // Se as luzes estiverem acesas 
            activated = true; // Fica ativo
        else
            activated = false;

        Activated(); // Chama a funcao que faz ficar visivel e com colisao caso esteja ativo
    }

    void Activated() 
    {
        if (activated) // Se estiver ativo
        {
            render.enabled = true; // Tem aparencia
            colider.enabled = true; // Tem colisao
        }
        else
        {
            render.enabled = false; // Fica invisivel
            colider.enabled = false; // Sem colisao
        }
    }
}
