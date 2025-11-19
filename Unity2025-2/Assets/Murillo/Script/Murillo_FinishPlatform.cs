using UnityEngine;
using TMPro; // Importante para usar TextMeshPro

public class Murillo_FinishPlatform : MonoBehaviour
{
    public GameObject finishTextObject;

    void Start()
    {
        if (finishTextObject != null)
        {
            finishTextObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Esta é a nova verificação, muito mais confiável!
        // Ela verifica se o objeto que entrou tem um Rigidbody, e se a Tag DESSE Rigidbody é "Player".
        if (other.attachedRigidbody != null && other.attachedRigidbody.CompareTag("Player"))
        {
            Debug.Log("Jogador finalizou o jogo!");

            if (finishTextObject != null)
            {
                finishTextObject.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}