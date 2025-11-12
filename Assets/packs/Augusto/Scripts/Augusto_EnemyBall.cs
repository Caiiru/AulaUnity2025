using UnityEngine;

public class EnemySphere : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
