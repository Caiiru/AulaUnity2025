using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Ball_movement : MonoBehaviour
{
    [SerializeField] Rigidbody myRigibody;
    [SerializeField] float force = 2.5f;
    [SerializeField] bool isGrounded;
    [SerializeField] float timer = 0f;
    [SerializeField] float targetTime = 5f;

    void Start()
    {
        myRigibody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigibody.AddForce(Vector3.left);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            myRigibody.AddForce(Vector3.back);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            myRigibody.AddForce(Vector3.right);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            myRigibody.AddForce(Vector3.forward);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRigibody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        // Debug.Log("Colidi com:" + collision.gameObject.name);

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            Destroy(gameObject); 
        }

        if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene("CenaFase2_Eduardo");
        }
    }
}
