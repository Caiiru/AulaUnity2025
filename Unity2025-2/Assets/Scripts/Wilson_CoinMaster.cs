using UnityEngine;

public class Wilson_Moeda : MonoBehaviour
{
    public float rotateSpeed = 1f;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed, Space.World);
    }
}