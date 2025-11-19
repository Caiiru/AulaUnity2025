using UnityEngine;

public class Eduardo_SpikeTrigger : MonoBehaviour
{
    [SerializeField] public Eduardo_Spike spike; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spike.ActivateSpike();
        }
    }
}