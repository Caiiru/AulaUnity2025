using UnityEngine;

public class JoaoPaulo_Respawn : MonoBehaviour
{
    public float threshold = -2;
    public Vector3 respawnPosition = new Vector3(-61, 0, -53);
    

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            transform.position = respawnPosition;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou em trigger: " + other.name);
        if (other.CompareTag("ChangeFloor2"))
        {
            threshold = -2;
            respawnPosition = new Vector3(29, 0, 20);
        }
        if (other.CompareTag("ChangeFloor"))
        {
            threshold = 9;
            respawnPosition = new Vector3(189, 12, 96);
        }
        
    }
}
