using UnityEngine;
using UnityEngine.SceneManagement;

public class Fernanda_TeleportarFases : MonoBehaviour
{
    [SerializeField] private string cenaDestino; // nome da cena

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou no portal!");
            SceneManager.LoadScene(cenaDestino);
        }
    }
}
