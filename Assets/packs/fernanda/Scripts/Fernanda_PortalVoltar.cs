using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // verifica se quem entrou no portal é o jogador
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Loby");
            print("Mudar cena");
        }
    }
}
