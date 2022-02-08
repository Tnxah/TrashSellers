using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ItemsManager : MonoBehaviour
{
    private Random rnd = new Random();
    private int time = 5;
    private float spawnChance = 50;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SlowUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SlowUpdate()
    {
        while (true) { 
        var rand = rnd.Next(0, 100);
        print(rand);
        if (rand < spawnChance)
        {
            print("Random item");
        }
        yield return new WaitForSeconds(5);
    }

    }
}
