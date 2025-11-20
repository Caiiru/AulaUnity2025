using UnityEngine;

public class Wilson_CameraFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera; 

    [SerializeField] private Vector3 follow_offset;

    void Start()
    {
        
    }

    
    void Update()
    {
        gameObject.transform.position = player.transform.position;
    }
}
