using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followTarget;

    public Vector3 followOffset = new Vector3(0,-3,4); 
    // Update is called once per frame

    void Update()
    {
        if (followTarget != null)
        {
            transform.LookAt(followTarget.transform.position);
            this.transform.position = followTarget.transform.position - followOffset;
        }
        


    }
}
