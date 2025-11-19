using UnityEngine;

public class Douglas_PortalEnd : MonoBehaviour
{
    [Header("Animation Parameters")]
    [Tooltip("Velocidade de rotacao")]
    [SerializeField] private float rotationSpeed = 1f;

    [Header("References")]
    [Tooltip("O objeto de destino.")]
    [SerializeField] GameObject portalDestination;
    [SerializeField] Rigidbody playerRb;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World); // Rota no eixo Y ou seja, horizontalmente em uma velocidade (rotationSpeed).
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Quando colide com o player
        {
            Douglas_ProtalLobby portal = portalDestination.GetComponent<Douglas_ProtalLobby>(); // Pega o script "ProtalLobby" do objeto de destino (Escrevi errado e agora n quero editar tudo kkkkkkkkkk) e adiciona a uma variavel portal
            portal.portalActivated = true;  // Seta a variavel portalActivated do objeto de destino para true
            other.transform.position = portalDestination.transform.position; // Teleporta o player para a posicao do objeto de destino.
            playerRb = other.GetComponent<Rigidbody>(); // Pega o Rigidibody do player
            playerRb.linearVelocity = Vector3.zero; // Faz ele parar para n spawnar andando pra frente
            playerRb.angularVelocity = Vector3.zero; // Faz ele parar de girar
            
        }
    }
}
