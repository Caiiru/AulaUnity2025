using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    [SerializeField] public Spike spike; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spike.ActivateSpike();
        }
    }
}