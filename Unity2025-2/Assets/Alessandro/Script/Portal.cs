using UnityEngine;
using UnityEngine.SceneManagement; // necessário para trocar de cena

public class PortalTrocaCena : MonoBehaviour
{
    [Header("Nome da Cena de Destino")]
    public string nomeCena = "Fase2"; // nome da cena que será carregada

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CarregarCena();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarregarCena();
        }
    }

    void CarregarCena()
    {
        SceneManager.LoadScene(nomeCena);
    }
}

