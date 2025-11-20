using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wilson_CameraLook : MonoBehaviour
{
    [Header("New Input System")]
    public InputActionReference lookAction; // Vector2 (delta X,Y)

    [Header("Config")]
    public float sensitivity = 1.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnEnable()
    {
        if (lookAction != null && lookAction.action != null)
            lookAction.action.Enable();
    }

    void OnDisable()
    {
        if (lookAction != null && lookAction.action != null)
            lookAction.action.Disable();
    }

    void Update()
    {
        Vector2 delta = Vector2.zero;

        // Preferred: read from assigned InputAction (Vector2)
        if (lookAction != null && lookAction.action != null)
        {
            delta = lookAction.action.ReadValue<Vector2>();
        }
        else
        {
            // Fallback to Mouse.current (new input) if available
            var mouse = Mouse.current;
            if (mouse != null)
            {
                delta = mouse.delta.ReadValue();
            }
            else
            {
                // Legacy fallback
                delta.x = Input.GetAxis("Mouse X");
                delta.y = Input.GetAxis("Mouse Y");
            }
        }

        // Aplicar rotação horizontal (yaw) — comportamento original
        float yaw = delta.x * sensitivity * Time.deltaTime * 100f; // multiplicador para ajustar escala
        transform.Rotate(0f, yaw, 0f);
    }
}