using Unity.VisualScripting;
using UnityEngine;

public class Javier_CameraFollow : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraSpeed = 1;
    void Start()
    {
        offset = transform.position - objectToFollow.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPos = objectToFollow.position + offset;
        float moveFactor = cameraSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, desiredPos, moveFactor);
    }
}