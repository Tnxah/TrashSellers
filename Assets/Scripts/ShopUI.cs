using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour, IInteractible
{
    private IShopCustomer shopCustomer;
    public GameObject shopUI;

    private void Start()
    {
    }
    public void TryBuyObject(string name)
    {
        if (shopCustomer.TryToPay(ItemManager.instance.GetObject(name).cost))
        {
            shopCustomer.Buy(name);
        }
    }

    public void Interact()
    {
        shopCustomer = PlayerScript.instance.gameObject.GetComponent<IShopCustomer>();
        shopUI.SetActive(true);
    }
}
