using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float forcaMovimento = 10f;
    public float forcaPulo = 3f;
    public float atrito = 0f;
    public string tagChao = "Chao";

    private Rigidbody rb;
    public bool estaNoChao = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = atrito; // controla o "deslizamento"
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movimento horizontal
        Vector3 direcao = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) direcao += Vector3.forward;
        if (Input.GetKey(KeyCode.D)) direcao += Vector3.back;
        if (Input.GetKey(KeyCode.S)) direcao += Vector3.left;
        if (Input.GetKey(KeyCode.W)) direcao += Vector3.right;

        rb.AddForce(direcao.normalized * forcaMovimento, ForceMode.Force);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            estaNoChao = false; // evita múltiplos pulos
        }
    }

    void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.CompareTag(tagChao))
        {
            estaNoChao = true;
        }
    }

    void OnCollisionExit(Collision colisao)
    {
        if (colisao.gameObject.CompareTag(tagChao))
        {
            estaNoChao = false;
        }
    }
}
