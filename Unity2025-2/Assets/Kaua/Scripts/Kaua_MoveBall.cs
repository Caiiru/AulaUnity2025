using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Kaua_MoveBall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveForce = 1.0f;
    [SerializeField] float jumpForce = 6.0f;
    [SerializeField] bool isGrounded;

    HashSet<Kaua_BreakablePlatform> touchedPlatforms = new HashSet<Kaua_BreakablePlatform>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveForce);

        if (Keyboard.current.aKey.isPressed)
        {
            rb.AddForce(Vector3.left * moveForce);
        }

        else if (Keyboard.current.sKey.isPressed)
        {
            rb.AddForce(Vector3.back * moveForce);
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            rb.AddForce(Vector3.right * moveForce);
        }

        else if (Keyboard.current.wKey.isPressed)
        {
            rb.AddForce(Vector3.forward * moveForce);
        }

        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryRegisterPlatformFromGameObject(collision.gameObject);

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("EndBuff"))
        {
            isGrounded = true;
            moveForce = 1f;
            jumpForce = 6f;
        }

        if (collision.gameObject.CompareTag("SpeedCoin"))
        {
            moveForce = 2f;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("JumpCoin"))
        {
            jumpForce = 13f;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("RestorePlatform"))
        {
            isGrounded = true;
            RestoreTouchedPlatforms();
        }

        if (collision.gameObject.CompareTag("NextPhase"))
        {
            SceneManager.LoadScene("CenaFase2_Kaua");
        }
    }

    // --- Helpers ---
    void TryRegisterPlatformFromGameObject(GameObject obj)
    {
        if (obj == null) return;

        Kaua_BreakablePlatform platform = obj.GetComponent<Kaua_BreakablePlatform>()
            ?? obj.GetComponentInParent<Kaua_BreakablePlatform>()
            ?? obj.GetComponentInChildren<Kaua_BreakablePlatform>();

        if (platform != null)
        {
            if (!touchedPlatforms.Contains(platform))
            {
                touchedPlatforms.Add(platform);
            }
        }
    }

    void RestoreTouchedPlatforms()
    {
        Kaua_BreakablePlatform[] arr = new Kaua_BreakablePlatform[touchedPlatforms.Count];
        touchedPlatforms.CopyTo(arr);

        int restored = 0;
        foreach (var p in arr)
        {
            if (p == null) continue;
            p.CancelBreakingAndRestore();
            restored++;
        }

        touchedPlatforms.Clear();
    }
}