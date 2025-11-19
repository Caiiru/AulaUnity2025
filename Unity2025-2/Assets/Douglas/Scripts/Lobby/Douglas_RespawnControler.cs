using UnityEngine;
using System.Collections;

public class Douglas_RespawnControler : MonoBehaviour
{
    [Header("Spawn Point")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTime = 5f;

    [Header("References")]
    [SerializeField] private Douglas_GameManager gameManager;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Renderer playerRender;
    [SerializeField] private Douglas_PlayerControl playerControl;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            StartCoroutine(SpawnAnimationCoroutine(spawnTime, playerPosition, playerRender, playerControl));
        }
    }

    private IEnumerator SpawnAnimationCoroutine(float time, Transform playerPosition, Renderer playerRender, Douglas_PlayerControl playerControl)
    {   
        playerControl.isAlive = false;
        // Starta a animacao nessa linha.
        playerRender.enabled = false; // Desativa a aparencia do player (Deixa invisivel)
        yield return new WaitForSeconds(time); // Espera o tempo time para rodar a parte de baixo do codigo (Configurar time para ser o tempo da animacao)
        playerPosition.transform.position = spawnPoint.position; // Teleporta o jogador para a posicao do Spawn Point
        playerRender.enabled = true; // Deixa o player visivel de novo
        // Starta a animacao de voltar a aparecer
        playerControl.isAlive = true;
    }
}
