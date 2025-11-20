using UnityEngine;

public class world_limit : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform check_point_1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = check_point_1.transform.position;
        }
    }
}
