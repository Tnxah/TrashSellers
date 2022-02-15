using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance;

    public Inventory inventory;

    public int money = 0;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

    }
}
