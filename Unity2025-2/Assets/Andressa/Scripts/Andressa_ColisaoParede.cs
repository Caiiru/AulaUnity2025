// Seu script ReturnToStart DEVE ser assim:

using UnityEngine;

public class Andressa_ReturnToStart : MonoBehaviour
{
    public Transform startPoint;
    public string wallTag = "ParedeUm";
    public float speedIncreaseAmount = 5.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(wallTag))
        {
            Andressa_MovingWall wallScript = collision.gameObject.GetComponent<Andressa_MovingWall>();

            if (wallScript != null)
            {
                wallScript.speed += speedIncreaseAmount;
             
            }

            transform.position = startPoint.position;
        }
    }
}