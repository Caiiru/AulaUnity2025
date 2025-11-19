using System.Collections;
using UnityEngine;

public class Juan_Teleport : MonoBehaviour
{
    [Header("Config")]
    public bool useTrigger = true;                 // true -> usa OnTriggerEnter, false -> OnCollisionEnter
    public string playerTag = "Player";            // tag do player (usado se 'player' não for atribuído no inspector)
    public Transform player;                       // opcional: arraste aqui o player; se nulo o script procura pelo tag
    public Transform teleportTarget;               // ponto de destino do teleporte

    [Header("Objetos para atualizar")]
    public Transform objeto1;
    public Transform objeto2;
    public Vector3 novaPosicaoObjeto1;
    public Vector3 novaPosicaoObjeto2;

    [Header("Opções")]
    public bool zerarVelocidadeAoTeleportar = true;
    public bool enableDebugLogs = true;

    void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag(playerTag);
            if (p != null) player = p.transform;
            else if (enableDebugLogs) Debug.LogWarning("[Teleport] player não atribuído e nenhum objeto com tag '" + playerTag + "' encontrado.");
        }

        if (teleportTarget == null && enableDebugLogs)
            Debug.LogWarning("[Teleport] teleportTarget não está atribuído!");
    }

    // Trigger
    void OnTriggerEnter(Collider other)
    {
        if (!useTrigger) return;
        if (enableDebugLogs) Debug.Log("[Teleport] OnTriggerEnter: " + other.name);
        TryHandleCollision(other.gameObject);
    }

    // Colisão normal
    void OnCollisionEnter(Collision collision)
    {
        if (useTrigger) return;
        if (enableDebugLogs) Debug.Log("[Teleport] OnCollisionEnter: " + collision.gameObject.name);
        TryHandleCollision(collision.gameObject);
    }

    // Caso o player use CharacterController (ele usa OnControllerColliderHit)
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (enableDebugLogs) Debug.Log("[Teleport] OnControllerColliderHit: " + hit.gameObject.name);
        TryHandleCollision(hit.gameObject);
    }

    void TryHandleCollision(GameObject other)
    {
        // Se recebeu player por inspector, compara pelo transform; senão compara por tag
        if (player != null)
        {
            if (other.transform != player) return;
        }
        else
        {
            if (!other.CompareTag(playerTag)) return;
            player = other.transform; // cache para próximas vezes
        }

        if (enableDebugLogs) Debug.Log("[Teleport] Player detectado -> teleportando...");

        if (teleportTarget != null)
            TeleportPlayer(player);
        else if (enableDebugLogs)
            Debug.LogWarning("[Teleport] teleportTarget está nulo; não foi possível teleportar.");

        // Atualiza os dois objetos
        if (objeto1 != null) objeto1.position = novaPosicaoObjeto1;
        if (objeto2 != null) objeto2.position = novaPosicaoObjeto2;
    }

    void TeleportPlayer(Transform playerTransform)
    {
        // Se for CharacterController (ex.: jogo de plataforma que usa CharacterController)
        CharacterController cc = playerTransform.GetComponent<CharacterController>();
        if (cc != null)
        {
            StartCoroutine(TeleportCharacterController(cc));
            return;
        }

        // Se tiver Rigidbody
        Rigidbody rb = playerTransform.GetComponent<Rigidbody>();
        if (rb != null)
        {
            if (zerarVelocidadeAoTeleportar)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            rb.position = teleportTarget.position;
            rb.rotation = teleportTarget.rotation;
            if (enableDebugLogs) Debug.Log("[Teleport] Player (Rigidbody) teleportado.");
            return;
        }

        // Caso padrão: apenas move o transform
        playerTransform.position = teleportTarget.position;
        playerTransform.rotation = teleportTarget.rotation;
        if (enableDebugLogs) Debug.Log("[Teleport] Player (Transform) teleportado.");
    }

    IEnumerator TeleportCharacterController(CharacterController cc)
    {
        // Para evitar erros ao setar posição com CharacterController, desabilitamos temporariamente.
        Transform t = cc.transform;
        cc.enabled = false;
        t.position = teleportTarget.position;
        t.rotation = teleportTarget.rotation;
        yield return null; // espera um frame
        cc.enabled = true;
        if (enableDebugLogs) Debug.Log("[Teleport] Player (CharacterController) teleportado.");
    }
}
