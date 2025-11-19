using UnityEngine;

public class Alessandro_ColetarCristal : MonoBehaviour
{
    [Header("Portal a ser liberado")]
    public GameObject portal; // arraste o portal aqui

    [Header("Prefab da Part�cula (opcional)")]
    public GameObject particulaPrefab; // part�culas ao coletar

    void Start()
    {
        if (portal != null)
        {
            portal.SetActive(false); // portal come�a bloqueado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // cria part�cula de coleta
            if (particulaPrefab != null)
            {
                Instantiate(particulaPrefab, transform.position, Quaternion.identity);
            }

            // ativa o portal
            if (portal != null)
            {
                portal.SetActive(true);
            }

            // destr�i o cristal
            Destroy(gameObject);
        }
    }
}
