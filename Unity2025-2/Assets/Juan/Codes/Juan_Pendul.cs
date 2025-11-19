using UnityEngine;

public class Juan_Pendul : MonoBehaviour
{
    [Header("Movimento do Pêndulo")]
    public float velocidade = 2f; // velocidade da oscilação
    public float anguloMaximo = 45f; // ângulo máximo de balanço

    [Header("Força de Arremesso")]
    public float forcaEmpurrao = 10f; // força aplicada ao player
    public ForceMode modoForca = ForceMode.Impulse;

    private float tempo;

    void Update()
    {
        tempo += Time.deltaTime * velocidade;
        float angulo = Mathf.Sin(tempo) * anguloMaximo;
        transform.localRotation = Quaternion.Euler(0, 0, angulo);
    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.rigidbody;
        if (rb != null)
        {
            // Direção do empurrão baseada no movimento atual do pêndulo
            Vector3 direcao = transform.right * Mathf.Sign(Mathf.Cos(tempo));
            rb.AddForce(direcao * forcaEmpurrao, modoForca);
        }
    }
}

