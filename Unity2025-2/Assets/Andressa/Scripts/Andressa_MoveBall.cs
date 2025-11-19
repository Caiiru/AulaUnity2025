using UnityEngine;
using UnityEngine.InputSystem;

public class Andressa_MoveBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 1.5f;
    public float jumpForce = 5f;
    private bool isGrounded;

    void Start()
    {
        //Caso o rigibody do componente for nulo irá ser adicionado ao objeto.
        if (rb == null) rb = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            isGrounded = true;
        }

    }
    void FixedUpdate()
    {
        if (Keyboard.current == null)
        {
            Debug.LogWarning("Nenhum teclado detectado!");
            return;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Force);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            rb.AddForce(Vector3.left * speed, ForceMode.Force);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Force);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rb.AddForce(Vector3.back * speed, ForceMode.Force);
        }
        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
