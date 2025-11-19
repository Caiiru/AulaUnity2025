using UnityEngine;
using UnityEngine.SceneManagement;

public class Fernanda_Portal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // verifica se quem entrou no portal � o jogador
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Loby");
            print("Mudar cena");
        }
    }
}
