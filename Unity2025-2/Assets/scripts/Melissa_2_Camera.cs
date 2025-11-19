using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Melissa_2_Camera : MonoBehaviour
{
    public Transform target;           // refer�ncia ao objeto que a c�mera segue (bolinha)
    public Vector3 offset = new Vector3(0, 38, -120); // deslocamento da c�mera em rela��o ao alvo
    public float smoothSpeed = 0.2f;   // suavidade do movimento da c�mera

    public GameObject waterOverlay;    // plano azul que simula efeito de �gua

    private bool inWater = false;      // indica se a bolinha est� dentro da �gua

    void LateUpdate()
    {
        if (target == null) return;

        // calcula posi��o desejada da c�mera com base no alvo + offset
        Vector3 desiredPos = target.position + offset;
        // move suavemente a c�mera usando Lerp (interpola linearmente)
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        // mant�m a c�mera olhando para o alvo
        transform.LookAt(target);

        // ativa/desativa o plano azul dependendo se est� na �gua
        if (waterOverlay != null)
            waterOverlay.SetActive(inWater);
    }

    void OnTriggerEnter(Collider other)
    {
        // detecta entrada em �gua por nome do objeto
        if (other.gameObject.name == "Agua")
            inWater = true;
    }

    public void ResetWaterEffect()
    {
        // permite resetar manualmente o efeito de �gua
        inWater = false;
    }
}
