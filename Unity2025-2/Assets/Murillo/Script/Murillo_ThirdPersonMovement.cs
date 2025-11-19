using UnityEngine;
using UnityEngine.InputSystem;

public class Murillo_ThirdPersonMovement : MonoBehaviour
{
    [Header("Referências")]
    public Transform orientation;       // Objeto que guarda a direção para frente da câmera
    public Transform playerVisuals;     // O modelo visual do jogador (PlayerObj)
    public Rigidbody rb;                // O Rigidbody do jogador

    [Header("Movimento")]
    public float moveSpeed = 7f;

    [Header("Rotação")]
    public float rotationSpeed = 10f;

    [Header("Input (New Input System)")]
    public InputActionReference moveAction; // Atribua a action Vector2 (ex: "Move") no Inspector

    // Variáveis para guardar o input do jogador
    private float horizontalInput;
    private float verticalInput;
    private Vector2 moveInput = Vector2.zero;

    void OnEnable()
    {
        if (moveAction != null && moveAction.action != null)
            moveAction.action.Enable();
    }

    void OnDisable()
    {
        if (moveAction != null && moveAction.action != null)
            moveAction.action.Disable();
    }

    void Update()
    {
        // 1. Capturar o input do teclado/gamepad via novo Input System (com fallback)
        if (moveAction != null && moveAction.action != null)
        {
            moveInput = moveAction.action.ReadValue<Vector2>();
            horizontalInput = moveInput.x;
            verticalInput = moveInput.y;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        // 2. Alinhar a orientação com a direção da câmera
        Vector3 viewDir = Camera.main.transform.forward;
        viewDir.y = 0;
        orientation.forward = viewDir.normalized;

        // 3. Rotacionar o personagem
        HandleRotation();
    }

    void FixedUpdate()
    {
        // 4. Mover o personagem
        HandleMovement();
    }

    private void HandleRotation()
    {
        // Calcula a direção do input baseada na orientação da câmera
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Se o jogador estiver pressionando alguma tecla de movimento...
        if (inputDir != Vector3.zero)
        {
            // Calcula a rotação para a qual o personagem deve olhar
            Quaternion targetRotation = Quaternion.LookRotation(inputDir, Vector3.up);

            // Rotaciona o modelo visual do personagem suavemente em direção ao alvo
            playerVisuals.rotation = Quaternion.Slerp(playerVisuals.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void HandleMovement()
    {
        // Calcula a direção do movimento baseada na orientação da câmera
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Aplica uma força ao Rigidbody para mover o personagem
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}