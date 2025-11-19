using UnityEngine;
using UnityEngine.InputSystem;

public class Maria_MoveBall : MonoBehaviour
{

    [SerializeField] Rigidbody myRB;
    [SerializeField] float force = 2.5f;
    public bool isGrounded;
    public float jumpforce = 6f;
    public float scaleFactor = 0.5f;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Keyboard.current.wKey.isPressed)
        {
            myRB.AddForce(Vector3.forward * force);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            myRB.AddForce(Vector3.left * force);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            myRB.AddForce(Vector3.right * force);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            myRB.AddForce(Vector3.back * force);
        }

        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            myRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }




    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}






