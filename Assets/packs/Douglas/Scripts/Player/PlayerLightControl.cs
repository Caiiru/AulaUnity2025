using UnityEngine;

public class PlayerLightControl : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Componente da Luz do personagem.")]
    [SerializeField] public Light playerLight;
    [Tooltip("Componente de Renderer que controla a aparencia do game object.")]
    [SerializeField] private Renderer render;
    [Tooltip("Componente que cria o rastro de luz.")]
    [SerializeField] public TrailRenderer trailRenderer;
    [SerializeField] GameObject trailPrefab;
    [SerializeField] Transform spawnPointTrail;


    [Header("Batery Parameters")]
    [Tooltip("Carga maxima da bateria.")]
    [SerializeField] private float maxBatery = 100f; 
    [Tooltip("Taxa de drenagem da bateria (por segundo).")]   
    [SerializeField] private float bateryDrain = 3f;
    [Tooltip("Carga atual da bateria.")]
    public float bateryLevel;

    [Header("Light Parametres")]
    [Tooltip("Brilho maximo da luz.")]
    [SerializeField] private float maxBright = 100f;
    [Tooltip("Area maxima da luz.")]
    [SerializeField] private float maxRange = 100f;
    [Tooltip("Rastro de luz ativo.")]
    public bool TrailActive = false;

    [Header("Trail Parameters")]
    public bool canSpawn = true;
    [SerializeField] float spawnDelay = 0.5f;
    float delayTimer = 0f;
    public GameObject playerModel;
    [SerializeField] float trailDestroyTime = 5f;
    
    void Awake()
    {
        render = GetComponent<Renderer>();  // Pega o componente Renderer automaticamente.
        trailRenderer = GetComponent<TrailRenderer>(); // Pega o componente TrailRenderer (componente do player)
        trailRenderer.emitting = false; // TrailRenderer começa false (desligado)
       
    }

    void Update()
    {
        LightControl(); // Chama a funcao que controla a bateria.
        LightBrightControl();   // Chama a funcao que controla o brilho.

        if(canSpawn)
        {
            if (Time.time > delayTimer)
                SpawnTronTrail();// chama funcao que controla o spawner de trail.  
        }

    }

    private void LightControl()
    {
        if (bateryLevel <= 0)   // Se bateria menor igual a 0
        {
            playerLight.enabled = false;    // Luz acende,
            TrailActive = false;
            canSpawn = false; // não spawna colisores do trail.
        }
        else
        {
            playerLight.enabled = true; // Luz apaga,  
        }

        if (bateryLevel > 0)    // Se a bateria for maior que 0.
        {
            bateryLevel -= bateryDrain * Time.deltaTime;    // Drena a bateria em uma taxa por segundo.
            bateryLevel = Mathf.Max(bateryLevel, 0);    // Impede que a bateria fique abaixo de 0.   
            
        }

        if (TrailActive && bateryLevel > 0)
        {
            canSpawn = true;
        }
    }

    private void LightBrightControl()
    {
        float bateryPercentage = bateryLevel / maxBatery; // Calcula a porcentagem atual de bateria.

        playerLight.intensity = maxBright * bateryPercentage;   // Define a intensidade do brilho para um valor igual a porcentagem de bateria vezes o brilho maximo.
        playerLight.range = maxRange * bateryPercentage;     // Define a area do brilho para um valor igual a porcentagem de bateria vezes a area maxima.

        if (playerLight.intensity > 0f)
        {
            float brightnessProportion = playerLight.intensity / maxBright;
            brightnessProportion = Mathf.Clamp01(brightnessProportion); // Garante que o valor fique sempre entre 0 e 1.

            render.material.SetColor("_EmissionColor", render.material.color * brightnessProportion);  // Garante que a cor do material seja igual a cor da luz com uma correcao de 1.2.
        }
        else
            render.material.SetColor("_EmissionColor", Color.black); // Se a intensidade for menor a 1.2, a emissão é desligada.
            
    }

    public void BateryCharge(float level)   // Funcao publica que carrega a bateria usando outros objetos.
    {
        bateryLevel += level;   // aumenta a carga de bateria em um valor dado pelo outro obj.
        bateryLevel = Mathf.Min(bateryLevel, maxBatery);    // Garante que a bateria nunca ultrapasse o maximo.
    }

    public void ActiveTrail(float chargeAmount) // função pública que ativa o trail de acordo com a bateria do player
    {
        BateryCharge(chargeAmount);
        TrailActive = true;
    }

    void SpawnTronTrail() // Função que cuida do spawn do trail.
    {
        GameObject newTrail = Instantiate(trailPrefab, spawnPointTrail.position, playerModel.transform.rotation); //spawna o trail na posição do Empty Object logo atrás do player
        delayTimer = Time.time + spawnDelay;

        Destroy(newTrail, trailDestroyTime); // Destroi o objeto após 0.5 segundos
        delayTimer = Time.time + spawnDelay;
    }
}
