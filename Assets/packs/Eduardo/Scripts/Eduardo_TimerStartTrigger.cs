using UnityEngine;

public class TimerStartTrigger : MonoBehaviour
{
    public TimerTrigger timerController; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerController.StartTimer();
        }
    }
}