using UnityEngine;

public class Kaua_BreakableWall : MonoBehaviour
{
    public GameObject brokenPrefab;
    public void Break()
    {
        if (brokenPrefab != null)
        {
            Instantiate(brokenPrefab, transform.position, transform.rotation, transform.parent);
        }
        Destroy(gameObject);
    }
}
