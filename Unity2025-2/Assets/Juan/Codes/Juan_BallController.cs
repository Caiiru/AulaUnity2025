using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Juan_BallController : MonoBehaviour
{
    public float velocidade = 10f;
    public float forcaPulo = 7f;
    private Rigidbody rb;
    private bool noChao;

    public Transform cameraTransform; // referência para a câmera

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Entrada WASD

        if (Keyboard.current.dKey.isPressed)
        {
            rb.AddForce(Vector3.right * velocidade, ForceMode.Force);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            rb.AddForce(Vector3.left * velocidade, ForceMode.Force);
        }
        if (Keyboard.current.wKey.isPressed)
        {
            rb.AddForce(Vector3.forward * velocidade, ForceMode.Force);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            rb.AddForce(Vector3.back * velocidade, ForceMode.Force);
        }


        // float movX = Input.GetAxis("Horizontal");
        // float movZ = Input.GetAxis("Vertical");

        // // --- Movimento relativo à câmera ---
        // Vector3 frente = cameraTransform.forward;
        // Vector3 direita = cameraTransform.right;

        // // Mantém só o plano XZ (ignora inclinação da câmera)
        // frente.y = 0;
        // direita.y = 0;
        // frente.Normalize();
        // direita.Normalize();

        // // Direção final
        // Vector3 movimento = (frente * movZ + direita * movX).normalized;

        // rb.AddForce(movimento * velocidade);
    }

    void Update()
    {
        // Pulo
        if (Keyboard.current.spaceKey.isPressed && noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            noChao = true;
        }
    }
}
