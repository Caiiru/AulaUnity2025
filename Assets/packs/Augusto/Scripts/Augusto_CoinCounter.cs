using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject finalWall;

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        finalWall = GameObject.FindWithTag("Wall");
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            Destroy(collision.gameObject);
            Instantiate(enemy);

            if (coins >= 5)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemyObj in enemies)
                {
                    Destroy(enemyObj);
                }

                Destroy(finalWall);
            }
        }
    }
}
