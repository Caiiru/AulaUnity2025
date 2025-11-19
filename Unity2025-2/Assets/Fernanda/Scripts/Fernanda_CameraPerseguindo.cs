using UnityEngine;

public class Fernanda_CameraPerseguindo : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed = 1;
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicaoDesejada = player.position + offset;
        float passo = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, passo);
    }
}
