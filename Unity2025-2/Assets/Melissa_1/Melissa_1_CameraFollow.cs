using UnityEngine;

public class Melissa_1_TopDownCameraFollow : MonoBehaviour
{
    public Transform target;        // a bolinha
    public float height = 10f;      // altura da câmera acima da bolinha
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target == null) return;

        // posição desejada diretamente acima da bolinha
        Vector3 desiredPos = target.position + Vector3.up * height;

        // suavizar movimento
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;

        // olhar diretamente para baixo
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}
