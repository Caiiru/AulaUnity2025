using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] private Transform ladoAPorta;
    [SerializeField] private Transform ladoBPorta;

    [Header("Configuração de Abertura (espaço local do pai)")]
    [SerializeField] private float velocidade = 0.5f;
    [SerializeField] private float zLocalAlvoLadoA = 3.45f;
    [SerializeField] private float zLocalAlvoLadoB = -3.55f;

    private bool abrir = false;
    private Vector3 alvoLocalA;
    private Vector3 alvoLocalB;

    void Start()
    {
        alvoLocalA = new Vector3(
            ladoAPorta.localPosition.x,
            ladoAPorta.localPosition.y,
            zLocalAlvoLadoA
        );
        alvoLocalB = new Vector3(
            ladoBPorta.localPosition.x,
            ladoBPorta.localPosition.y,
            zLocalAlvoLadoB
        );
    }

    void Update()
    {
        if (!abrir) return;

        Vector3 atualA = ladoAPorta.localPosition;
        Vector3 novoA = Vector3.MoveTowards(atualA, alvoLocalA, Mathf.Abs(velocidade) * Time.deltaTime);
        ladoAPorta.localPosition = novoA;

        Vector3 atualB = ladoBPorta.localPosition;
        Vector3 novoB = Vector3.MoveTowards(atualB, alvoLocalB, Mathf.Abs(velocidade) * Time.deltaTime);
        ladoBPorta.localPosition = novoB;

        if ((novoA - alvoLocalA).sqrMagnitude <= 1e-6f && (novoB - alvoLocalB).sqrMagnitude <= 1e-6f)
        {
            abrir = false;
        }
    }

    // **Nova função de Trigger**
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AbrirPorta();
        }
    }

    public void AbrirPorta()
    {
        abrir = true;
    }
}
