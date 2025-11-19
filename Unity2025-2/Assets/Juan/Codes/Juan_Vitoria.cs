using UnityEngine;
using UnityEngine.SceneManagement;

public class Juan_Vitoria : MonoBehaviour
{
    [Header("Configurações")]
    public string tagDoPlayer = "Player";
    public GameObject telaDeVitoria;
    public bool usarTrigger = true;

    void Start()
    {
        if (telaDeVitoria != null)
            telaDeVitoria.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!usarTrigger) return;
        if (other.CompareTag(tagDoPlayer))
        {
            Debug.Log("[Win] Player entrou no Trigger!");
            MostrarTelaVitoria();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (usarTrigger) return;
        if (collision.collider.CompareTag(tagDoPlayer))
        {
            Debug.Log("[Win] Player colidiu!");
            MostrarTelaVitoria();
        }
    }

    void MostrarTelaVitoria()
    {
        if (telaDeVitoria != null)
        {
            telaDeVitoria.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("[Win] Tela de vitória ativada!");
        }
        else
        {
            Debug.LogWarning("[Win] Nenhuma tela de vitória atribuída!");
        }
    }

    // botão "Reiniciar"
    public void ReiniciarCena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
