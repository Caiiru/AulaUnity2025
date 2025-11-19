using UnityEngine;

public class Douglas_Pendulum : MonoBehaviour
{   
    [Header("Parameters")]
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int angleLimit = 75;

    void Update()
    {
        float angle = angleLimit * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(0, 90, angle);
    }
}
