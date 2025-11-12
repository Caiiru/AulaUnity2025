using UnityEngine;

public class TimerEndTrigger : MonoBehaviour
{
    public TimerTrigger timerController; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerController.StopTimer();
        }
    }
}
