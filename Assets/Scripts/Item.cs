using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Object, IInteractible
{
    public string spawnChance;


    public Item(string name, int cost, string spawnChance)
    {
        this.name = name;
        this.cost = cost;
        this.spawnChance = spawnChance;
    }

    public void Interact()
    {
        Inventory.instance.Add(this);
        
    }
}
