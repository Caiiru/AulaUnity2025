using UnityEngine;

public class ColetarCristal : MonoBehaviour
{
    [Header("Portal a ser liberado")]
    public GameObject portal; // arraste o portal aqui

    [Header("Prefab da Partícula (opcional)")]
    public GameObject particulaPrefab; // partículas ao coletar

    void Start()
    {
        if (portal != null)
        {
            portal.SetActive(false); // portal começa bloqueado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // cria partícula de coleta
            if (particulaPrefab != null)
            {
                Instantiate(particulaPrefab, transform.position, Quaternion.identity);
            }

            // ativa o portal
            if (portal != null)
            {
                portal.SetActive(true);
            }

            // destrói o cristal
            Destroy(gameObject);
        }
    }
}
