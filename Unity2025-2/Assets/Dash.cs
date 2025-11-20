using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{

    [SerializeField] float dash_force;
    [SerializeField] Transform camera_pivot;

    Rigidbody rb;

    // New Input System
    public InputActionReference dashAction; // Button (ex: Left Shift)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        if (dashAction != null && dashAction.action != null)
        {
            dashAction.action.Enable();
            dashAction.action.performed += OnDashPerformed;
        }
    }

    void OnDisable()
    {
        if (dashAction != null && dashAction.action != null)
        {
            dashAction.action.performed -= OnDashPerformed;
            dashAction.action.Disable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Fallback para input legado
        if ((dashAction == null || dashAction.action == null) && Keyboard.current != null)
        {
            if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
            {
                DoDash();
            }
        }
        
    }

    private void OnDashPerformed(InputAction.CallbackContext ctx)
    {
        DoDash();
    }

    private void DoDash()
    {
        if (rb == null || camera_pivot == null) return;
        rb.AddForce(-camera_pivot.transform.forward * dash_force, ForceMode.Impulse);
    }
}