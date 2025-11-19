// ...existing code...
using UnityEngine;
using UnityEngine.InputSystem;

public class Melissa_2_BallMovement : MonoBehaviour
{
    public float moveSpeed = 8f;         // velocidade de movimento padrão
    public float jumpForce = 5f;         // força do pulo normal

    private float currentSpeed;          // velocidade atual, alterada na água
    private Rigidbody rb;                // referência ao Rigidbody do objeto
    private float lastJumpTime = 0f;     // tempo do último toque de pulo
    private float doubleJumpThreshold = 0.3f; // intervalo máximo entre toques para super jump

    // Novo Input System
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    private Vector2 moveInput = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = moveSpeed;
    }

    void OnEnable()
    {
        if (moveAction != null && moveAction.action != null)
            moveAction.action.Enable();

        if (jumpAction != null && jumpAction.action != null)
        {
            jumpAction.action.Enable();
            jumpAction.action.performed += OnJumpPerformed;
        }
    }

    void OnDisable()
    {
        if (moveAction != null && moveAction.action != null)
            moveAction.action.Disable();

        if (jumpAction != null && jumpAction.action != null)
        {
            jumpAction.action.performed -= OnJumpPerformed;
            jumpAction.action.Disable();
        }
    }

    void Update()
    {
        // Movimento horizontal com novo Input System (fallback para Input legado)
        float moveX;
        float moveZ;

        if (moveAction != null && moveAction.action != null)
        {
            moveInput = moveAction.action.ReadValue<Vector2>();
            moveX = moveInput.x;
            moveZ = moveInput.y;
        }
        else
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }

        Vector3 movement = new Vector3(moveX, 0, moveZ) * currentSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Fallback para pulo usando Input legado (se jumpAction não estiver configurada)
        if ((jumpAction == null || jumpAction.action == null) && Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastJumpTime <= doubleJumpThreshold)
                Jump(jumpForce * 2); // super jump
            else
                Jump(jumpForce);     // pulo normal

            lastJumpTime = Time.time;
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        // Quando usar botão do novo Input System, o performed é acionado.
        if (Time.time - lastJumpTime <= doubleJumpThreshold)
            Jump(jumpForce * 2); // super jump
        else
            Jump(jumpForce);     // pulo normal

        lastJumpTime = Time.time;
    }

    private void Jump(float force)
    {
        // Zera a velocidade vertical antes de aplicar a força para consistência
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        // Ao entrar na água, reduz velocidade
        if (other.CompareTag("Agua"))
        {
            currentSpeed = moveSpeed / 2f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Ao sair da água, retorna velocidade normal
        if (other.CompareTag("Agua"))
        {
            currentSpeed = moveSpeed;
        }
    }
}
// ...existing code...