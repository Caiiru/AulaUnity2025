using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Velocidade de movimento.")]
    [SerializeField] private float speed = 35f;
    [Tooltip("Velocidade de rotacao.")]
    [SerializeField] private float rotationSpeed = 300f;
    [Tooltip("Forca do pulo.")]
    [SerializeField] private float jumpStrengh = 4f;
    private float rotation = 0f;
    private float aceleration = 0f;
    private bool isGrounded;

    [Header("Lifes Parameters")]
    public bool isAlive = true;

    [Header("References")]
    [Tooltip("Componente de Rigidibody.")]
    [SerializeField] private Rigidbody rb;
    [Tooltip("Componente do GammeManager.")]
    [SerializeField] private GameManager gameManager;

    [Header("Audio Reference")]
    [SerializeField] private AudioSource audiosource;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Pega o componente do Rigidibody do player.
        gameManager = GameObject.FindFirstObjectByType<GameManager>(); // Procura o primeiro obj com o script GameManager.
    }

    void Update()
    {
        if (isAlive) // Caso esteja vivo
            InputKeys(); // Chama a funcao que le os controles
        else
        {
            rb.linearVelocity = Vector3.zero; // Caso esteja "Morto" desativa todos os controles e para o objeto
            rb.angularVelocity = Vector3.zero; // Para a rotacao tbm
        }
    }

    void FixedUpdate()
    {
        Moviment(); // Funcao que gerencia o movimento e rotacao do player.
        Jump(); // Funcao que cuida do pulo.
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Verifica se esta em contato com o chao.
            isGrounded = true;
    }

    void OnCollisionExit(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("Ground")) // Verifica quando nao esta em contato com o chao.
            isGrounded = false;
    }

    void InputKeys()
    {
        if (Input.GetKey(KeyCode.W)) // Ve se esta precionando a tecla W e entao adiciona um valor positivo a aceleracao.
            aceleration = 1;
        else if (Input.GetKey(KeyCode.S))
            aceleration = -1;
        else
            aceleration = 0;

        if (Input.GetKey(KeyCode.D))    // Ve qual lado o player quer girar e adiciona um valor positivo ou negativo a velocidade de rotacao.
            rotation = rotationSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            rotation = -rotationSpeed * Time.deltaTime;
        else
            rotation = 0;
    }

    void Moviment()
    {
        if (isGrounded)
        {
            Vector3 moveDirection = transform.forward * aceleration * speed;
            rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);
        }

        //rb.AddForce(transform.forward * (speed * aceleration), ForceMode.Force); // Se estiver no chao adiciona uma forca pra frente igual a direcao (aceleration) * velocidade (speed)

        if (rotation != 0)
        {
            Quaternion turn = Quaternion.Euler(0f, rotation, 0f);   // Cria uma variavel do tipo Quaternion que carrega os valores Euler do eixo x,y e z. (no caso o unico com valor e o Y sendo igual a rotacao)
            rb.MoveRotation(rb.rotation * turn);    // Adiciona uma rotacao ao rigidibody igual a rotacao atual vezes a variavel de cima.
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Se estiver no chao e precionar espaco adiciona um impulso pra cima.
            rb.AddForce(Vector3.up * jumpStrengh, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DarkSide"))
        {
            if (audiosource != null && !audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
    }
}
