using UnityEngine;

public class JoaoPaulo_Door : MonoBehaviour
{
    public string requiredKey; //aqui vai criar um campo na interface da unity e tu s� coloca o id da chave que desbloqueia a porta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JoaoPaulo_PlayerKeys playerKeys = other.GetComponent<JoaoPaulo_PlayerKeys>();
            if (playerKeys != null && playerKeys.HasKey(requiredKey))
            {
                gameObject.SetActive(false); 
                Debug.Log("Porta aberta com chave: " + requiredKey);
            }
        }
    }
}
