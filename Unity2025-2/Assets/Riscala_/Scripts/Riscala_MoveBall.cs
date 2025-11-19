using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class MoveBall : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float force = 5f;
    [SerializeField] bool isStopped = true;
    public float respawnDelay = 1f;
    public Transform targetPlace;
    public Transform respawn;
    private bool canMove;
    public float fogIncrease = 0.003f;
    public float fogDeacrese = 0.005f;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Phase2"){
            fogIncrease = 0.017f;
        }
        else
        {
            fogIncrease = 0.003f;
        }
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        canMove = true;
        if (rb == null)
        {
            Debug.LogError("Rigidbody n�o encontrado neste GameObject!");
        }
        
    }

    void Update()
    {
        if (rb == null) return;

        
        if (canMove)
        {
            if (Keyboard.current.wKey.isPressed)
                rb.AddForce(Vector3.forward * force);

            if (Keyboard.current.aKey.isPressed)
                rb.AddForce(Vector3.left * force);

            if (Keyboard.current.sKey.isPressed)
                rb.AddForce(Vector3.back * force);

            if (Keyboard.current.dKey.isPressed)
                rb.AddForce(Vector3.right * force);
        }

        if (rb.linearVelocity.magnitude < 0.01f)
        {
            isStopped = true;
        }
        else if (rb.linearVelocity.magnitude > 0.05f)
        {
            isStopped = false;
        }

        if (isStopped && RenderSettings.fogEndDistance < 20)
        {
            RenderSettings.fogEndDistance += fogIncrease;
        }
        else if (!isStopped && RenderSettings.fogEndDistance > 9)
        {
            RenderSettings.fogEndDistance -= fogDeacrese;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish1"))
        {
            SceneManager.LoadScene("Phase2");
        }
        else
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    

}