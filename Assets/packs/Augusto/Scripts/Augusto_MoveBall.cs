using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    [SerializeField] Rigidbody myRigibody;
    [SerializeField] float force = 2f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isInverted;
    [SerializeField] Vector3 originalGravity;

    void Start()
    {
        myRigibody = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigibody.AddForce(Vector3.forward * force);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigibody.AddForce(Vector3.left * force);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myRigibody.AddForce(Vector3.back * force);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigibody.AddForce(Vector3.right * force);
        }
        else if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            myRigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        else if (Input.GetKey(KeyCode.Space) && isInverted)
        {
            myRigibody.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
            isInverted = false;
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "GravityIce")
        {
            isInverted = true;
        }

        if (collision.gameObject.tag == "GravityIce")
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
        }

        if (collision.gameObject.tag == "NormalGravityIce")
        {
            Physics.gravity = originalGravity;
        }

        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("Fase 2 - Au");
        }

        if (collision.gameObject.tag == "Restart")
        {
            SceneManager.LoadScene("Hub");
        }
    }
}
