using UnityEngine;

public class Douglas_PlayerTrailCollision : MonoBehaviour
{
    
    bool canSpawn = true;
    [SerializeField] GameObject trailPrefab;

    [SerializeField] TrailRenderer trailRenderer;
    

    [SerializeField] float spawnDelay = 0.5f;
    float delayTimer = 0f;

    [SerializeField] private Douglas_PlayerLightControl lightControl;
    
    void Start()
    {
        lightControl = GetComponent<Douglas_PlayerLightControl>();
    }


    void Update()
    {
        if (lightControl.TrailActive == false)
        {
            Debug.Log("Est� funcionando");
        }

        float intensityMinimum = 1.2f; 
        trailRenderer.emitting = lightControl.TrailActive && lightControl.playerLight.intensity > intensityMinimum;

    }

}
