using UnityEngine;
using UnityEngine.InputSystem;

public class Melissa_1_GameController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Transform SpawnPoint;

    private Rigidbody rb;

    // Input System (novo)
    public InputActionReference moveAction;
    private Vector2 moveInput = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (SpawnPoint != null)
            transform.position = SpawnPoint.position;
    }

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
        // Movimento com novo Input System (Vector2) com fallback para Input legado
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

        Vector3 dir = new Vector3(moveX, 0, moveZ) * moveSpeed;

        // Se estiver em contato com parede lento, reduz velocidade horizontal
        if (IsTouchingLento)
        {
            dir *= 0.1f; // 10% da velocidade original
        }

        // Aplica a velocidade mantendo gravidade
        rb.linearVelocity = new Vector3(dir.x, rb.linearVelocity.y, dir.z);
    }

    private bool IsTouchingLento = false;

    void OnCollisionEnter(Collision collision)
    {
        string n = collision.gameObject.name.ToLower();

        // Teleportar pro spawn se bater na parede batevolta
        if (n == "batevolta" && SpawnPoint != null)
        {
            transform.SetPositionAndRotation(SpawnPoint.position, SpawnPoint.rotation);
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (n == "lento")
        {
            IsTouchingLento = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.ToLower() == "lento")
        {
            IsTouchingLento = false;
        }
    }
} 