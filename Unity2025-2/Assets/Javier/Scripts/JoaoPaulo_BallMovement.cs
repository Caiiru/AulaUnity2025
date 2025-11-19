using NUnit.Framework.Constraints;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoaoPaulo_BallMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float moveForce = 1.0f;
    public float jumpForce = 20.0f;
    bool isGrounded;
    bool isLight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Acido")
        {
            Debug.Log(collision.gameObject.name);
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camForward = UnityEngine.Camera.main.transform.forward;
        Vector3 camRight = UnityEngine.Camera.main.transform.right;

        // ignorar eixo Y
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            moveDir += camForward;
        if (Keyboard.current.sKey.isPressed)
            moveDir -= camForward;
        if (Keyboard.current.dKey.isPressed)
            moveDir += camRight;
        if (Keyboard.current.aKey.isPressed)
            moveDir -= camRight;

        rb.AddForce(moveDir * moveForce);

        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            if (!isLight)
            {
                GetComponent<MeshRenderer>().material.color = new Color(80, 80, 80);
                isLight = true;
                Debug.Log("Luz ligada");
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = Color.black;
                isLight = false;
                Debug.Log("Luz desligada");
            }

        }
    }
}
