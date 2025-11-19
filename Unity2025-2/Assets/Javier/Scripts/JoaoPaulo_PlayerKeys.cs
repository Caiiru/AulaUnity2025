using UnityEngine;
using System.Collections.Generic;

public class JoaoPaulo_PlayerKeys : MonoBehaviour
{
    private HashSet<string> keys = new HashSet<string>();

    public void AddKey(string keyID)
    {
        keys.Add(keyID);
        Debug.Log("Pegou chave: " + keyID);
    }

    public bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }
}
