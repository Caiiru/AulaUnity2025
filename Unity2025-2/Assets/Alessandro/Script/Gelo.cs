using UnityEngine;

public class Gelo : MonoBehaviour
{
    public float velocidadeDerretimento = 0.2f;
    public float escalaMinima = 0.1f;
    public float massaMinima = 0.1f;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 escalaAtual = transform.localScale;

        // Derrete apenas no eixo Y (altura)
        if (escalaAtual.z > escalaMinima)
        {
            escalaAtual.z -= velocidadeDerretimento * Time.deltaTime;
            transform.localScale = escalaAtual;
        }
        if (escalaAtual.y > escalaMinima)
        {
            escalaAtual.y -= velocidadeDerretimento * Time.deltaTime;
            transform.localScale = escalaAtual;
        }
        if (escalaAtual.x > escalaMinima)
        {
            escalaAtual.x -= velocidadeDerretimento * Time.deltaTime;
            transform.localScale = escalaAtual;
        }

        float proporcao = Mathf.InverseLerp(escalaMinima, 1f, escalaAtual.y);
        rb.mass = Mathf.Lerp(massaMinima, 1f, proporcao);

    }
}
