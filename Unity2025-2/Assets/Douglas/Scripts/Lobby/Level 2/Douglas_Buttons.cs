using UnityEngine;
using System.Collections;
public class Douglas_Buttons : MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("O botao esta ativo?")]
    [SerializeField] private bool activated = false;
    [Tooltip("Tempo que o botao fica ativo")]
    [SerializeField] private float timer;

    [Header("References")]
    [SerializeField] private Douglas_GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindFirstObjectByType<Douglas_GameManager>(); // Acha o objeto GameManager e seta ele na referencia
    }

    void OnTriggerEnter (Collider other)
    {
        if (!activated) // Se n estiver ativo
        {
            if (other.gameObject.CompareTag("Player")) // Ao colidir com o jogador
            {
                gameManager.LightControlTimer(timer); // Ativa a funcao LightControlTimer do gameManager passando o valor da variavel timer como parametro da funcao.
                StartCoroutine(ActivationTimerCoroutine(timer));    // Ativa a co-rotina ActivationTimerCoroutine passando o valor da variavel timer como parametro da co-rotina.
            }
        }
    }

    private IEnumerator ActivationTimerCoroutine(float timer) // A co-rotina basicamente e uma funcao com timer, ou seja, alem dela reproduzir codigo vc pode passar um valor de tempo para ela realizar outra parte da funcao no final do tempo
    {   
        activated = true; // Deixa o botao ativo
        transform.position = new Vector3(transform.position.x, -0.17f, transform.position.z); // Abaixa o botao (dando a impressao de que ele foi pressionado)
        yield return new WaitForSeconds(timer); // Apos um tempo dado pela variavel timer executa a segunda parte da funcao.
        activated = false; // Deixa o botao desativado
        transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z); // Faz o botao voltar pra posicao inicial.
    }
}