using UnityEngine;

public class Alessandro_CameraFollow : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;
    [SerializeField] Vector3 offset;

    void Start()
    {
        if(objectToFollow == null)
        {
            Debug.LogError("Object to follow is not assigned.");
            return;
        }
        offset = transform.position - objectToFollow.position;
    }

    void Update()
    {
        if (Physics.gravity.y < 0)
        {
            offset = new Vector3(offset.x, Mathf.Abs(offset.y), offset.z);
        }
        else if (Physics.gravity.y > 0)
        {
            offset = new Vector3(offset.x, -Mathf.Abs(offset.y), offset.z);
        }

        transform.position = objectToFollow.position + offset;
    }
}
