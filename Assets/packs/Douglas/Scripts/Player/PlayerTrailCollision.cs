using UnityEngine;

public class PlayerTrailCollision : MonoBehaviour
{
    
    bool canSpawn = true;
    [SerializeField] GameObject trailPrefab;

    [SerializeField] TrailRenderer trailRenderer;
    

    [SerializeField] float spawnDelay = 0.5f;
    float delayTimer = 0f;

    [SerializeField] private PlayerLightControl lightControl;
    
    void Start()
    {
        lightControl = GetComponent<PlayerLightControl>();
    }


    void Update()
    {
        if (lightControl.TrailActive == false)
        {
            Debug.Log("Está funcionando");
        }

        float intensityMinimum = 1.2f; 
        trailRenderer.emitting = lightControl.TrailActive && lightControl.playerLight.intensity > intensityMinimum;

    }

}
