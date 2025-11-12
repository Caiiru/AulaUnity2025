using System.Threading;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Levels Parameters")]
    [Tooltip("As luzes estao acesas?")]
    public bool lightsOn = false;
    [Tooltip("As luzes estao em timer?.")]
    private bool lightTimer = false;

    [Header("References")]
    [SerializeField] private Light gameLight;

    void Update()
    {
        LightControl(); // Chama a funcao 
    }

    void LightControl()
    {
        if (lightsOn) // Caso as luzes estejam ativas
            gameLight.enabled = true; // Acende a luz global
        else
            gameLight.enabled = false;
    }

    public void LightControlTimer(float timer) // Usa o parametro timer como controle de tempo
    {
        if (!lightTimer) // Caso o timer nao esteja ativo
            StartCoroutine(LightTimerCoroutine(timer)); // Chama a co-rotina LightTimerCoroutine usando o parametro timer como cotnrole de tempo
    }

    private IEnumerator LightTimerCoroutine(float timer)
    {
        lightTimer = true; // Ativa o timer
        lightsOn = true; // ACende a luz 
        yield return new WaitForSeconds(timer); // Ao passar o tempo definido pelo parametro timer
        lightsOn = false; // Apaga a luz
        lightTimer = false; // Desativa o timer
    }
}
