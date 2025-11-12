using UnityEngine;

public class TrailSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject trailSegment;
    [SerializeField] private float spawnInterval = 0.2f;
    [SerializeField] TrailRenderer trailRenderer;
    [SerializeField] private float segmentLifetime = 3f;

    private float timer;

    private PlayerLightControl playerLightControl;
    private float spawnTimer;


    void Start()
    {
       playerLightControl = GetComponent<PlayerLightControl>();
    }

    void Update()
    {
        if (trailRenderer.emitting)
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnColliderSegment();
                timer = 0f; 
            }
        }
    }

    private void SpawnColliderSegment()
    {
        Vector3 spawnPos = transform.position - transform.forward * 0.5f;
        GameObject segment = Instantiate(trailSegment, spawnPos, Quaternion.identity);
    }
}
