using UnityEngine;

public class JoaoPaulo_AcidSymbolPart : MonoBehaviour
{
    [Header("Configura��es")]
    public bool isActive = false;
    public float activeDuration = 2f;

    [Header("Materiais")]
    public Material normalMaterial;
    public Material activeMaterial; 

    private float timer;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // define o material inicial
        if (rend != null && normalMaterial != null)
            rend.material = normalMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        var acidState = other.GetComponent<JoaoPaulo_AcidState>();
        if (acidState != null && acidState.isAcid)
        {
            Activate();
        }
    }

    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isActive = false;

                // volta ao material original
                if (rend != null && normalMaterial != null)
                    rend.material = normalMaterial;
            }
        }
    }

    public void Activate()
    {
        isActive = true;
        timer = activeDuration;

        // aplica o material ativo
        if (rend != null && activeMaterial != null)
            rend.material = activeMaterial;
    }
}
