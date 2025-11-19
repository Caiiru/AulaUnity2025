using UnityEngine;

public class Kaua_CoinCounter : MonoBehaviour
{
    [SerializeField] int coins = 0;
    [SerializeField] string wallTag = "WallToBrake";
    [SerializeField] GameObject brokenPrefab;
    //bool wallsBroken = false;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "RestorePlatform")
        {
            coins++;
            Destroy(collision.gameObject);


            if (coins >= 2)
            {
                BreakWalls();
                //wallsBroken = true;
            }
        }
    }

    private void BreakWalls()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag(wallTag);

        foreach (GameObject w in walls)
        {
            w.SendMessage("Break", SendMessageOptions.DontRequireReceiver);

            //if (brokenPrefab != null)
            //{
            //    Instantiate(brokenPrefab, w.transform.position, w.transform.rotation, w.transform.parent);
            //    Destroy(w);
            //}
            //else
            //{
            //    // 3) fallback simples: destruir o objeto
            //    Destroy(w);
            //}
        }
    }
}
