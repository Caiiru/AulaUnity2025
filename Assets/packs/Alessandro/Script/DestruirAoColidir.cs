using UnityEngine;

public class ResetarPersonagemAoColidir : MonoBehaviour
{
    [Header("Prefab da Part�cula")]
    public GameObject particulaPrefab; // arraste o prefab da part�cula aqui

    [Header("Tempo antes de reaparecer (segundos)")]
    public float tempoAntesDeResetar = 1f;

    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;
    private Rigidbody rb;
    private bool estaResetando = false;

    void Start()
    {
        // guarda a posi��o e rota��o iniciais
        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava") && !estaResetando)
        {
            ExplodirEVoltar();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava") && !estaResetando)
        {
            ExplodirEVoltar();
        }
    }

    void ExplodirEVoltar()
    {
        estaResetando = true;

        // cria a part�cula
        if (particulaPrefab != null)
        {
            GameObject particula = Instantiate(particulaPrefab, transform.position, Quaternion.identity);
            Destroy(particula, 2f);
        }

        // desativa o personagem visualmente
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // aguarda um tempo e reseta
        Invoke(nameof(ResetarPersonagem), tempoAntesDeResetar);
    }

    void ResetarPersonagem()
    {
        transform.position = posicaoInicial;
        transform.rotation = rotacaoInicial;

        // reativa o personagem
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;

        estaResetando = false;
    }
}
