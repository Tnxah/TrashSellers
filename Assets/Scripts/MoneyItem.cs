using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyItem : Object, IInteractible
{
    public void Interact()
    {
        PlayerScript.instance.money += cost;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    
}
