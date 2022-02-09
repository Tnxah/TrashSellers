using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractible
{
    private new string name;
    private float cost;

    public void Interact()
    {
        Destroy(gameObject);
    }
}
