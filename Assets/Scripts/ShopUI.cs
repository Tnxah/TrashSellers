using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    IShopCustomer shopCustomer;

    private void TryBuyObject(string name)
    {
        if (shopCustomer.TryToPay(Shop.instance.GetObject(name).cost))
        {
            shopCustomer.Buy(name);
        }
    }
}
