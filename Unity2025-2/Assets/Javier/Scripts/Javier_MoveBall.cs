using UnityEngine;
using UnityEngine.InputSystem;

public class Javier_MoveBall : MonoBehaviour
{
    [Header("Configurações da Bola")]
    public bool isGrounded;
    public float velocidade = 1f;
    public float jumpforce = 1f;// Velocidade de movimento da bola
    private Rigidbody rb;          // Componente Rigidbody para física



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    void Start()
    {
        // Pega o componente Rigidbody anexado a esta bola
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // --- Movimento da Bola ---

        // Pega o input das teclas WASD ou setas direcionais
        float movimentoHorizontal = Input.GetAxis("Horizontal"); // A e D
        float movimentoVertical = Input.GetAxis("Vertical");   // W e S

        // Cria um vetor de movimento baseado no input
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);

        // Aplica uma força na bola para movê-la
        rb.AddForce(movimento * velocidade);

        //
        
    }

 
}