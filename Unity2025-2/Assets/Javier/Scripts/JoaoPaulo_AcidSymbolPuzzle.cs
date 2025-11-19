using UnityEngine;

public class JoaoPaulo_AcidSymbolPuzzle : MonoBehaviour
{
    private JoaoPaulo_AcidSymbolPart[] parts;  
    public bool puzzleComplete = false;

    void Start()
    {
    
        parts = GetComponentsInChildren<JoaoPaulo_AcidSymbolPart>();
    }

    void Update()
    {
        if (puzzleComplete) return;

        bool allActive = true;
        foreach (var p in parts)
        {
            if (!p.isActive)
            {
                allActive = false;
                break;
            }
        }

        if (allActive)
        {
            OnPuzzleComplete();
        }
    }

    void OnPuzzleComplete()
    {
        puzzleComplete = true;
        Debug.Log("Puzzle resolvido!");
        
    }
}
