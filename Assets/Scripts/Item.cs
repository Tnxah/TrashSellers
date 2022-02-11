using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Object, IInteractible
{
    public float cost;

    public void Interact()
    {
        Inventory.instance.Add(this);
        
    }
}
