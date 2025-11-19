using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Kaua_BreakablePlatform : MonoBehaviour
{
    [Header("Config")]
    public string playerTag = "Player"; 
    public float breakTime = 5f;
    public bool startBroken = false;    

    [Header("Visuals")]
    public Material highlightMaterial;
    public Color startColor = Color.white;
    public Color warningColor = Color.red;
    public GameObject brokenPrefab;

    // control
    Collider col;
    Renderer rend;
    Material instMaterial;
    Coroutine breakingCoroutine;
    bool isBroken = false;

    void Awake()
    {
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();

        if (rend != null)
        {
            instMaterial = rend.material;
            startColor = instMaterial.HasProperty("_Color") ? instMaterial.color : startColor;
        }

        if (startBroken)
            BreakNow();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;

        if (collision.gameObject.CompareTag(playerTag))
        {
            foreach (var contact in collision.contacts)
            {
                StartBreaking();
                return;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (isBroken) return;

        if (collision.gameObject.CompareTag(playerTag))
        {
            //StopBreaking();
        }
    }

    void StartBreaking()
    {
        if (breakingCoroutine == null)
            breakingCoroutine = StartCoroutine(BreakRoutine());
    }

    void StopBreaking()
    {
        if (breakingCoroutine != null)
        {
            StopCoroutine(breakingCoroutine);
            breakingCoroutine = null;
            RestoreVisual();
        }
    }

    IEnumerator BreakRoutine()
    {
        float t = 0f;

        if (highlightMaterial != null && rend != null)
        {
            rend.material = highlightMaterial;
            instMaterial = rend.material;
            if (instMaterial.HasProperty("_Color")) startColor = instMaterial.color;
        }

        while (t < breakTime)
        {
            t += Time.deltaTime;
            float p = Mathf.Clamp01(t / breakTime);
            if (instMaterial != null && instMaterial.HasProperty("_Color"))
            {
                instMaterial.color = Color.Lerp(startColor, warningColor, p);
            }

            if (breakTime - t < 1f) instMaterial.color = Color.Lerp(startColor, warningColor, Mathf.PingPong(Time.time * 8f, 1f));

            yield return null;
        }

        breakingCoroutine = null;
        BreakNow();
    }

    void BreakNow()
    {
        if (isBroken) return;
        isBroken = true;

        if (brokenPrefab != null)
        {
            Instantiate(brokenPrefab, transform.position, transform.rotation);
        }

        if (col != null) col.enabled = false;

        if (rend != null) rend.enabled = false;

        // Destroy(gameObject, 5f);
    }

    void RestoreVisual()
    {
        if (instMaterial != null && instMaterial.HasProperty("_Color"))
            instMaterial.color = startColor;
    }

    public void ResetPlatform()
    {
        isBroken = false;
        if (col != null) col.enabled = true;
        if (rend != null) rend.enabled = true;
        RestoreVisual();
    }

    public void CancelBreakingAndRestore()
    {
        if (breakingCoroutine != null)
        {
            StopCoroutine(breakingCoroutine);
            breakingCoroutine = null;
        }

        RestoreVisual();

        if (col != null) col.enabled = true;
        if (rend != null) rend.enabled = true;

        isBroken = false;
    }
}
