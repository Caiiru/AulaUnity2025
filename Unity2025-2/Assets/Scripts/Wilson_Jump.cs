// ...existing code...
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wilson_Jump : MonoBehaviour
{

    private Rigidbody rb;


    [SerializeField] private float jump_force;
    [SerializeField] private float crush_force;

    [SerializeField] private float jump_time;
    private float jump_timer;

    [SerializeField] private float fall_force;

    private bool is_grounded;

    // New Input System
    public InputActionReference jumpAction;  // Button (ex: Space)
    public InputActionReference crushAction; // Button (ex: LeftCtrl)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump_timer = jump_time;
    }

    void OnEnable()
    {
        if (jumpAction != null && jumpAction.action != null)
        {
            jumpAction.action.Enable();
            jumpAction.action.performed += OnJumpPerformed;
        }

        if (crushAction != null && crushAction.action != null)
        {
            crushAction.action.Enable();
            crushAction.action.performed += OnCrushPerformed;
        }
    }

    void OnDisable()
    {
        if (jumpAction != null && jumpAction.action != null)
        {
            jumpAction.action.performed -= OnJumpPerformed;
            jumpAction.action.Disable();
        }

        if (crushAction != null && crushAction.action != null)
        {
            crushAction.action.performed -= OnCrushPerformed;
            crushAction.action.Disable();
        }
    }

    void Update()
    {
        // Fallback legacy input handling (se actions não atribuídas)
        if ((jumpAction == null || jumpAction.action == null) && Input.GetKeyUp(KeyCode.Space) && is_grounded)
        {
            DoJump();
        }

        if ((crushAction == null || crushAction.action == null) && Input.GetKeyDown(KeyCode.LeftControl) && !is_grounded)
        {
            DoCrush();
        }

        is_Grounded();

        if (is_grounded == false)
        {
            jump_timer -= Time.deltaTime;
        }
        else
        {
            jump_timer = jump_time;
        }

        if (jump_timer <= 0)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -fall_force, rb.linearVelocity.z);
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        if (is_grounded)
            DoJump();
    }

    private void OnCrushPerformed(InputAction.CallbackContext ctx)
    {
        if (!is_grounded)
            DoCrush();
    }

    private void DoJump()
    {
        rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
    }

    private void DoCrush()
    {
        rb.AddForce(Vector3.down * crush_force, ForceMode.VelocityChange);
    }

    void is_Grounded()
    {

        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 1, LayerMask.GetMask("Floor")))
        {

            if (hit.collider != null)
            {
                is_grounded = true;
            }
        }
        else
        {
            is_grounded = false;
        }



    }

}
// ...existing code...