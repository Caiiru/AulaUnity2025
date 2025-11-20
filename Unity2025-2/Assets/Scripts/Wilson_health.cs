using System;
using UnityEngine;

public class Wilson_health : MonoBehaviour, IBreakable
{

    [SerializeField] private GameObject destroyed_game_object;

    void IBreakable.Break()
    {
        if (destroyed_game_object != null)
        {
            Instantiate(destroyed_game_object, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
