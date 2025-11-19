using UnityEngine;

public class Eduardo_TimerEndTrigger : MonoBehaviour
{
    public Eduardo_TimerTrigger timerController; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerController.StopTimer();
        }
    }
}
