using UnityEngine;

public class Maria_GirarAbelha : MonoBehaviour
{
    public float rotateSpeed = 1.2f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed, Space.World);
    }
}
