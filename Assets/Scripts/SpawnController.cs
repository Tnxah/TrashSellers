using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;

    private Random rnd = new Random();
    public int spawnDelay = 30;
    public float spawnChance = 50;
    public float spawnRadius = 600;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SlowUpdate());
    }


    IEnumerator SlowUpdate()
    {
        var items = ItemManager.instance.itemPrefabs;

        while (true) { 
            var rand = rnd.Next(0, 100);
            print(rand);
            if (rand < spawnChance)
            {
                    var position = UnityEngine.Random.insideUnitCircle * (spawnRadius);
                    Vector3 pos = PlayerScript.instance.transform.position + new Vector3(position.x, 0, position.y);
                    Instantiate(items[new Random().Next(items.Count)], pos, Quaternion.identity);
            
            }


            yield return new WaitForSeconds(spawnDelay);
        }

    }
}
