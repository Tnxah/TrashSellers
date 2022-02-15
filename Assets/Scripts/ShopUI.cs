using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private IShopCustomer shopCustomer;

    private void Start()
    {
        shopCustomer = PlayerScript.instance.gameObject.GetComponent<IShopCustomer>();
    }
    public void TryBuyObject(string name)
    {
        if (shopCustomer.TryToPay(ItemManager.instance.GetObject(name).cost))
        {
            shopCustomer.Buy(name);
        }
    }
}
