using UnityEngine;

public class Eduardo_CameraFollow : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;

    void Start()
    {
        if (objectToFollow != null)
            offset = transform.position - objectToFollow.position;
    }

    void LateUpdate()
    {
        if (objectToFollow == null)
            return;

        transform.position = objectToFollow.position + offset;
    }
}
