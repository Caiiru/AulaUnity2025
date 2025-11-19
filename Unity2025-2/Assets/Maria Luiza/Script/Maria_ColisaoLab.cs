using UnityEngine;

public class Maria_ColisaoLab : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter (Collider other)
    {
        thePlayer.transform.position = teleportTarget.position;
    }
        
    }

