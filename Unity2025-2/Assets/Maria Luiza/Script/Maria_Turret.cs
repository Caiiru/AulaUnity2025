using UnityEngine;
using UnityEngine.InputSystem;

public class Maria_Turret : MonoBehaviour
{
    [SerializeField] GameObject objectToClone;
    [SerializeField] Transform positionToClone;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            GameObject aux;
            aux = Instantiate(objectToClone);
            aux.transform.position = positionToClone.position;

            aux.GetComponent<Rigidbody>().AddForce(positionToClone.forward * 10, ForceMode.Impulse);
            aux.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
