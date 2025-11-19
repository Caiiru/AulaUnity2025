using UnityEngine;

public class Douglas_light_bulb_trail : MonoBehaviour
{
    [Header("Animation Parameters")]
    [Tooltip("Velocidade de rotacao.")]
    [SerializeField] private float rotationSpeed = 1f;

    [Header("References")]
    [SerializeField] private Douglas_GameManager gameManager;
    [SerializeField] private Douglas_PlayerLightControl playerLightControl;
    void Start()
    {
        gameManager = GameObject.FindFirstObjectByType<Douglas_GameManager>(); // Procura e vincula o tipo de objeto a variavel
        playerLightControl = GameObject.FindFirstObjectByType<Douglas_PlayerLightControl>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed); // Faz o obj rodar
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Caso colida com o player
        {
            playerLightControl.ActiveTrail(20f); // Adiciona 20 de energia a bateria

            

            Destroy(gameObject); // Destroi o obj
        }
    }
}
