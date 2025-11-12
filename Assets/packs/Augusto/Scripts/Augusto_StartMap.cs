using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene("Fase 1 - Au");
        }
    }
}
