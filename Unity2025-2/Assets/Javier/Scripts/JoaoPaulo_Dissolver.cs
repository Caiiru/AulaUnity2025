using System.Collections;
using UnityEngine;

public class JoaoPaulo_Dissolver : MonoBehaviour
{
    [Header("Configura��es")]
    public float dissolveDuration = 2f;   
    public float reappearDelay = 3f;      
    public float reappearDuration = 2f;   

    private float dissolveStrength;
    private Material dissolverMaterial;
    private bool isDissolving = false;
    private Collider col;

    void Start()
    {
        dissolverMaterial = GetComponent<Renderer>().material;
        col = GetComponent<Collider>();
    }

    private IEnumerator Dissolve()
    {
        float elapsedTime = 0f;

       
        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(0f, 1f, elapsedTime / dissolveDuration);
            dissolverMaterial.SetFloat("_ThresHold", dissolveStrength);
            yield return null;
        }

  
        if (col != null)
            col.enabled = false;

       
        yield return new WaitForSeconds(reappearDelay);

    
        elapsedTime = 0f;
        while (elapsedTime < reappearDuration)
        {
            elapsedTime += Time.deltaTime;
            dissolveStrength = Mathf.Lerp(1f, 0f, elapsedTime / reappearDuration);
            dissolverMaterial.SetFloat("_ThresHold", dissolveStrength);
            yield return null;
        }

      
        if (col != null)
            col.enabled = true;

        isDissolving = false; 
    }

    public void StartDissolve()
    {
        if (!isDissolving)
        {
            isDissolving = true;
            StartCoroutine(Dissolve());
        }
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            StartDissolve();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartDissolve();
    }
}
