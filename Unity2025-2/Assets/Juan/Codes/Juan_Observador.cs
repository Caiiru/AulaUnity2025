using UnityEngine;

public class Juan_Observador : MonoBehaviour
{
    public Transform jogador;

    void Update()
    {
        if (jogador == null) return;

        // Faz o plano olhar para o jogador
        transform.LookAt(jogador, Vector3.up);

        // Corrige a inclinação do Plane (porque o forward dele não é o eixo "frente" certo)
        transform.Rotate(90f, 0f, 0f);
    }
}
