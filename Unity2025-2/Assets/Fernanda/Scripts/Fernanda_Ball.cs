using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;   

public class Fernanda_Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    Vector3 posicaoInicial = new Vector3(-1.42f, 0.76f, -0.77f);
    float velocidade = 0.05f;
    float forcaPulo = 5f;
    float parada = 0.10f;
    bool podePular = false;

    void Start()
    {

    }

    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
            rb.AddForce(Vector3.forward * velocidade, ForceMode.Impulse);

        if (Keyboard.current.aKey.isPressed)
            rb.AddForce(Vector3.left * parada, ForceMode.Impulse);

        if (Keyboard.current.dKey.isPressed)
            rb.AddForce(Vector3.right * parada, ForceMode.Impulse);

        if (Keyboard.current.sKey.isPressed)
            rb.AddForce(Vector3.back * parada, ForceMode.Impulse);

        // S� pula se puder
        if (Keyboard.current.spaceKey.wasPressedThisFrame && podePular)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            podePular = false; // impede m�ltiplos pulos at� encostar de novo
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Chao"))
        {
            podePular = true;
        }

        if (collision.gameObject.CompareTag("Barreira"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
