﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ItemsManager : MonoBehaviour
{
    private Random rnd = new Random();
    private int waitTime = 30;
    private float spawnChance = 80;
    public GameObject itemPrefab;
    public float spawnRadius = 600;

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
                var position = UnityEngine.Random.insideUnitCircle * (spawnRadius);
                Vector3 pos = new Vector3(position.x, 0, position.y);
                Instantiate(itemPrefab, pos, Quaternion.identity);
            
        }


        yield return new WaitForSeconds(waitTime);
    }

    }
}