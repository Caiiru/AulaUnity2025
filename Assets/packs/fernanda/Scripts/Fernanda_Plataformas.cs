using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    [SerializeField] private List<GameObject> listaPlataformas;
    float[] temporizador = { 1, 2, 3, 4, 5, 6 };
    float velocidade = 2f;
    [SerializeField] Transform alvo;

    void Start()
    {
        // Cria uma lista temporária embaralhada
        List<GameObject> plataformasAleatorias = new List<GameObject>(listaPlataformas);
        EmbaralharLista(plataformasAleatorias);

        // Inicia o movimento sequencial
        StartCoroutine(MoverPlataformasSequenciais(plataformasAleatorias));
    }

    IEnumerator MoverPlataformasSequenciais(List<GameObject> plataformas)
    {
        foreach (GameObject plataforma in plataformas)
        {
            if (plataforma == null) continue;

            // Espera tempo aleatório antes de começar
            float tempo = temporizador[Random.Range(0, temporizador.Length)];
            yield return new WaitForSeconds(tempo);

            // Move a plataforma até o alvo
            while (Vector3.Distance(plataforma.transform.position, alvo.position) > 0.1f)
            {
                Vector3 direcao = (alvo.position - plataforma.transform.position).normalized;
                plataforma.transform.position += direcao * velocidade * Time.deltaTime;
                yield return null;
            }

            // Destrói a plataforma e espera o próximo loop
            Destroy(plataforma);
            yield return null;
        }
    }

    // Função para embaralhar a lista
    void EmbaralharLista(List<GameObject> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            GameObject temp = lista[i];
            int randomIndex = Random.Range(i, lista.Count);
            lista[i] = lista[randomIndex];
            lista[randomIndex] = temp;
        }
    }
}
