using UnityEngine;

public class JoaoPaulo_AcidState : MonoBehaviour
{
    [Header("Configura��o")]
    public float acidDuration = 5f;
    public Material acidMaterial;
    public Material normalMaterial;
    public GameObject acidTrailVFX; 

    [Header("Estado Atual")]
    public bool isAcid = false;

    private float acidTimer;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (acidTrailVFX != null)
            acidTrailVFX.SetActive(false);
    }

    void Update()
    {
        if (isAcid)
        {
            acidTimer -= Time.deltaTime;
            if (acidTimer <= 0)
            {
                DisableAcidState();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Acido"))
        {
            EnableAcidState();
        }
    }

    public void EnableAcidState()
    {
        isAcid = true;
        acidTimer = acidDuration;

        if (acidMaterial != null)
            rend.material = acidMaterial;

        if (acidTrailVFX != null)
            acidTrailVFX.SetActive(true);
    }

    public void DisableAcidState()
    {
        isAcid = false;

        if (normalMaterial != null)
            rend.material = normalMaterial;

        if (acidTrailVFX != null)
            acidTrailVFX.SetActive(false);
    }
}