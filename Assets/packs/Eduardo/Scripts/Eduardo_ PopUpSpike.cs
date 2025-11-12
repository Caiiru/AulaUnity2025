using UnityEngine;
using System.Collections;

public class PopUpSpike : MonoBehaviour
{
    [SerializeField] public float popUpHeight = 1f; 
    [SerializeField] public float popUpSpeed = 2f; 
    [SerializeField] public float delayBeforePopUp = 1f; 

    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 poppedUpPosition;
    [SerializeField] private bool isPoppedUp = false;

    void Start()
    {
        initialPosition = transform.position;
        poppedUpPosition = initialPosition + Vector3.up * (popUpHeight * 3f);
        StartCoroutine(PopUpSequence());
    }

    IEnumerator PopUpSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayBeforePopUp);

            float timer = 0f;
            while (timer < 1f)
            {
                transform.position = Vector3.Lerp(initialPosition, poppedUpPosition, timer);
                timer += Time.deltaTime * popUpSpeed;
                yield return null;
            }
            transform.position = poppedUpPosition;
            isPoppedUp = true;

            yield return new WaitForSeconds(delayBeforePopUp); 

            timer = 0f;
            while (timer < 1f)
            {
                transform.position = Vector3.Lerp(poppedUpPosition, initialPosition, timer);
                timer += Time.deltaTime * popUpSpeed;
                yield return null;
            }
            transform.position = initialPosition;
            isPoppedUp = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); 
        }
    }
}
