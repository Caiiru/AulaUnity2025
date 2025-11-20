// ...existing code...
using UnityEngine;
using UnityEngine.InputSystem;

public class Wilson_input_movement : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float move_force;
    [SerializeField] private float max_velocity;

    [SerializeField] private GameObject camera_pivot;

    // Novo Input System
    public InputActionReference moveAction;
    private Vector2 moveInput = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 7;
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

    // Update is called once per frame
    void Update()
    {
        float horizontal_dir;
        float vertical_dir;

        // Lê input do novo Input System (com fallback para o legado)

        moveInput = moveAction.action.ReadValue<Vector2>();
        horizontal_dir = moveInput.x;
        vertical_dir = moveInput.y;


        // Usa rb.velocity (linearVelocity não existe na API padrão)
        if (rb.linearVelocity.magnitude <= max_velocity)
        {
            if (Mathf.Abs(vertical_dir) > 0f)
            {
                rb.AddForce(-camera_pivot.transform.forward * move_force * vertical_dir * Time.deltaTime);
            }
            if (Mathf.Abs(horizontal_dir) > 0f)
            {
                rb.AddForce(-camera_pivot.transform.right * move_force * horizontal_dir * Time.deltaTime);
            }
        }
    }
}
// ...existing code...