using UnityEngine;

public class Melissa_2_BateVolta : MonoBehaviour
{
    public Transform SpawnPoint; // ponto para onde o objeto ser� teleportado ao colidir
    private Rigidbody rb;        // refer�ncia ao Rigidbody do objeto para manipular f�sica

    void Start()
    {
        // captura o Rigidbody associado a este GameObject
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // checa se colidiu com outro objeto chamado "BateVolta" e se o spawn est� definido
        if (collision.gameObject.name == "BateVolta" && SpawnPoint != null)
        {
            // teleporta o objeto para o spawn com a mesma rota��o
            transform.SetPositionAndRotation(SpawnPoint.position, SpawnPoint.rotation);

            // zera a velocidade linear e angular para evitar movimento residual
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
