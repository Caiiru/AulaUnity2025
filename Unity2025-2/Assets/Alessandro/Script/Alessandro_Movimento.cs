using UnityEngine;
using UnityEngine.InputSystem;

public class Alessandro_Movimento : MonoBehaviour
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
        if (Keyboard.current.aKey.isPressed) direcao += Vector3.forward;
        if (Keyboard.current.dKey.isPressed) direcao += Vector3.back;
        if (Keyboard.current.sKey.isPressed) direcao += Vector3.left;
        if (Keyboard.current.wKey.isPressed) direcao += Vector3.right;

        rb.AddForce(direcao.normalized * forcaMovimento, ForceMode.Force);

        // Pulo
        if (Keyboard.current.spaceKey.isPressed && estaNoChao)
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
