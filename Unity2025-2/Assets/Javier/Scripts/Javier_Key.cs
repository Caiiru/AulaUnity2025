using UnityEngine;

public class Javier_Key : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    public string keyID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Javier_PlayerKeys playerKeys = other.GetComponent<Javier_PlayerKeys>();
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