using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public float velocidade = 2f;
    public float distancia = 7f;
    public bool esquerda = false;
    private Vector3 posicaoInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Mathf.PingPong(Time.time * velocidade, distancia);
        if (!esquerda)
        {
            transform.position = posicaoInicial + Vector3.right * movimento;
        }
        else
        {
            transform.position = posicaoInicial + Vector3.left * movimento;
        }
        
    }
}
