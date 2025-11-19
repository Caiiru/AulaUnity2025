using UnityEngine;
using TMPro;

public class Eduardo_TimerTrigger : MonoBehaviour
{
    public float totalTime = 20f;
    private float currentTime;
    private bool timerActive = false;

    public TextMeshProUGUI timerText;
    public GameObject player;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (timerActive && player != null)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0)
            {
                TimerEnded();
            }
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
            timerText.text = "Tempo: " + Mathf.CeilToInt(currentTime) + "s";
    }

    private void TimerEnded()
    {
        timerActive = false;
        currentTime = 0;
        UpdateTimerText();

        if (player != null)
        {
            Destroy(player);
            Debug.Log("Tempo acabou! Jogador destru�do.");
        }
    }

    public void StartTimer()
    {
        timerActive = true;
        Debug.Log("Timer iniciado!");
    }

    public void StopTimer()
    {
        timerActive = false;
        Debug.Log("Timer parado!");
    }

}
