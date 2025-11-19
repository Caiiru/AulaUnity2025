using UnityEngine;

public class JoaoPaulo_Key : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    public string keyID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JoaoPaulo_PlayerKeys playerKeys = other.GetComponent<JoaoPaulo_PlayerKeys>();
            if (playerKeys != null)
            {
                playerKeys.AddKey(keyID);
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {

    }
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 150f, 0) * Time.deltaTime, Space.World);
    }
}