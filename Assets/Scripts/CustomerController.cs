using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour, IShopCustomer
{
    private PlayerScript player;


    private void Start()
    {
        player = PlayerScript.instance;
    }

    public void Buy(string name)
    {
        print(ItemManager.instance.GetObject(name));
        player.inventory.Add(ItemManager.instance.GetObject(name));
    }

    public bool TryToPay(int amount)
    {
        
        if (amount <= player.money)
        {
            player.money -= amount;
            print("Enough money");
            return true;
        }
        else
        {
            print("Not enough money");
            return false;
        }
    }
}
