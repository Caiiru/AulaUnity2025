using Unity.VisualScripting;
using UnityEngine;

public class ProtalLobby : MonoBehaviour
{
    [Header("Game Parameters")]
    [Tooltip("O portal esta ativo?")]
    public bool portalActivated = false;

    [Header("Animation Parameters")]
    [Tooltip("Velocidade de rotacao.")]
    [SerializeField] private float rotationSpeed = 1f;
    [Tooltip("Material pra quando estiver ativo.")]
    [SerializeField] private Material materialOn;
    [Tooltip("Material pra quando estiver desativado.")]
    [SerializeField] private Material materialOff;

    [Header("References")]
    [Tooltip("Objeto de destino.")]
    [SerializeField] private Transform portalDestination;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Light portalLight;

    void Update()
    {
        Activated(); // Chama afuncao que muda o materal quando ativo
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World); // Faz girar
    }

    void OnTriggerEnter(Collider other)
    {
        if (!portalActivated) // Caso nao esteja ativado
        {
            if (other.CompareTag("Player")) // Caso colida com o jogador
            {
                other.transform.position = portalDestination.position; // Teleporta o jogador para o objeto de destino
                playerRb = other.GetComponent<Rigidbody>(); // Pega o Rigidibody do player
                playerRb.linearVelocity = Vector3.zero; // Faz ele parar para n spawnar andando pra frente
                playerRb.angularVelocity = Vector3.zero; // Faz ele parar de girar
            }
        }
    }

    void Activated()
    {
        if (portalActivated) // Caso esteva ativo
        {
            mesh.sharedMaterial = materialOn; // Define o material para materialON
            portalLight.enabled = true; // Acende a luz do portal
        }
        else
        {
            mesh.sharedMaterial = materialOff; // Caso contrario, define materialOff
            portalLight.enabled = false; // Apaga a luz do portal
        }
    }
}