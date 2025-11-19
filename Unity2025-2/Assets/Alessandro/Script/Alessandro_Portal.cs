using UnityEngine;
using UnityEngine.SceneManagement; // necess�rio para trocar de cena

public class Alessandro_PortalTrocaCena : MonoBehaviour
{
    [Header("Nome da Cena de Destino")]
    public string nomeCena = "Fase2"; // nome da cena que ser� carregada

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

