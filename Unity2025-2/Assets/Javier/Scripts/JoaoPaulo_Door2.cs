using UnityEngine;
using System.Collections.Generic;

public class JoaoPaulo_Door2 : MonoBehaviour
{
    [Tooltip("Lista de chaves necess�rias para abrir esta porta")]
    public List<string> requiredKeys = new List<string>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JoaoPaulo_PlayerKeys playerKeys = other.GetComponent<JoaoPaulo_PlayerKeys>();
            if (playerKeys != null)
            {
                bool hasAllKeys = true;
                foreach (string key in requiredKeys)
                {
                    if (!playerKeys.HasKey(key))
                    {
                        hasAllKeys = false;
                        break;
                    }
                }

                if (hasAllKeys)
                {
                    gameObject.SetActive(false);
                    Debug.Log("Porta aberta! Todas as chaves presentes.");
                }
                else
                {
                    Debug.Log("Faltam chaves para abrir esta porta.");
                }
            }
        }
    }
}
