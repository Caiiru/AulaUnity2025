using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject walls;

    private int enemiesDestroyed = 0;
    public void EnemyDestroyed()
    {
        enemiesDestroyed++;

        if(enemiesDestroyed >= 2)
        {
            Destroy(walls);
        }

    }
}
