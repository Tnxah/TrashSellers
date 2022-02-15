using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public string currency = "CG";
    private void Start()
    { LoginWithEmailAddressRequest request = new LoginWithEmailAddressRequest();
        request.Email = "tnxah.j@gmail.com";
        request.Password = "123123123";
        
        PlayFabClientAPI.LoginWithEmailAddress(request, result => { UpdateCatalogItems(); }, error => { });
        if (!instance)
        {
            instance = this;
            
            //UpdateCatalogItems();
        }  
    }

    private void UpdateCatalogItems()
    {
        GetCatalogItemsRequest request = new GetCatalogItemsRequest();
        request.CatalogVersion = "main";

        PlayFabClientAPI.GetCatalogItems(request, 
            result => {
                List<CatalogItem> items = result.Catalog;
                print(items.ToString());
                foreach (var item in items)
                {
                    
                    print(ItemsManager.instance.itemPrefabs[0]);
                    ItemsManager.instance.itemPrefabs.Find(x => x.name.Equals(item.ItemId)).GetComponent<Item>().cost = (int)item.VirtualCurrencyPrices[currency];

                }

            }, 
            error => { 
        
            });
        print(((Item)Shop.instance.GetObject("stick")).cost + "CENA");
    }

    public Object GetObject(string name)
    {
        return ItemsManager.instance.itemPrefabs.Find(x => x.name.Equals(name)).GetComponent<Object>();
    }

}
