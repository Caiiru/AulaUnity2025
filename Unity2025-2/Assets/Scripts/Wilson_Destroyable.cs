using UnityEngine;

public class Wilson_Destroyable : MonoBehaviour
{
    
    [SerializeField] private GameObject destroyed_object;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die() 
    {
    
        Instantiate(destroyed_object, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}
