using System.Collections;
using UnityEngine;

public class PathDisappear : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject player;
    private MeshRenderer mr;
    private Coroutine coroutine;
    [SerializeField] private bool isStopped;
    [SerializeField] private float showDelay = 0.5f;
    [SerializeField] private float hideDelay = 0.5f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player n�o atribu�do no Inspector!");
            return;
        }
        rb = player.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody n�o encontrado no GameObject do player!");
        }
        mr = GetComponent<MeshRenderer>();
        if (mr == null)
        {
            Debug.LogError("MeshRenderer n�o encontrado neste GameObject!");
        }
    }

    void Update()
    {
        if (rb == null || mr == null) return;

        if (rb.linearVelocity.magnitude < 0.01f && !isStopped)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(ShowAfterDelay(showDelay));
            isStopped = true;
        }
        else if (rb.linearVelocity.magnitude > 0.05f && isStopped)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(HideAfterDelay(hideDelay));
            isStopped = false;
        }
    }

    IEnumerator ShowAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (mr != null) mr.enabled = true;
    }

    IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (mr != null) mr.enabled = false;
    }
}