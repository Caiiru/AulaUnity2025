using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wilson_destroyedobject : MonoBehaviour
{
    private List<GameObject> pieces = new List<GameObject>();

    private float piece_alpha = 1;
    [SerializeField] private float fade_speed = 1;
    
    private float start_fade_timer = 2;
    private float fade_timer = 1;

    private float size = 1;

    void Start()
    {
        add_children_to_list();
    }

    void Update()
    {
        if (start_fade_timer > 0) 
        {
            start_fade_timer -= Time.deltaTime; 
        }
        else 
        {
            if (size > 0) 
            { 
                size = Mathf.Lerp(0, 1, fade_timer);
                for (int i = 0; i < pieces.Count; i++) 
                { 
            
                   pieces[i].transform.localScale = new Vector3(size,size,size);
            
                }
                fade_timer -= Time.deltaTime * 0.5f;
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }

    void add_children_to_list() 
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pieces.Add(transform.GetChild(i).gameObject);
        }
    }
}
