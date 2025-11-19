using UnityEngine;
using UnityEngine.SceneManagement;

public class Kaua_DeadZone : MonoBehaviour
{
    [SerializeField] string killTag = "Player";
    [SerializeField] Transform respawnPoint; // arraste o spawn no inspector
    [SerializeField] bool reloadSceneOnDeath = true; // se true, recarrega a cena ao inv�s de respawn

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(killTag)) return;

        if (reloadSceneOnDeath)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        if (respawnPoint != null)
        {
            // move o jogador para o respawn e zera velocidade
            other.transform.position = respawnPoint.position;
            Rigidbody rb = other.attachedRigidbody;
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
