using UnityEngine;

public class Eduardo_Spike : MonoBehaviour
{
    private Rigidbody[] coneRigidbodies;
    private bool hasFallen = false;

    public Eduardo_TimerTrigger timerController; 

    void Start()
    {
        
        coneRigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in coneRigidbodies)
        {
            r.isKinematic = true;
            r.useGravity = true;
        }
    }

    public void ActivateSpike()
    {
        if (!hasFallen)
        {
            foreach (Rigidbody r in coneRigidbodies)
            {
                r.isKinematic = false; 
            }
            hasFallen = true;
            Debug.Log("Espinhos ativados! Todos caíram.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            if (timerController != null)
                timerController.StopTimer();


            Destroy(collision.gameObject);
            Debug.Log("Jogador morreu ao encostar no espinho!");
        }

        if (collision.gameObject.CompareTag("Ground") && hasFallen)
        {
            foreach (Rigidbody r in coneRigidbodies)
            {
                r.linearVelocity = Vector3.zero;
                r.angularVelocity = Vector3.zero;
                r.isKinematic = true; 
            }

            this.enabled = false;
        }
    }
}