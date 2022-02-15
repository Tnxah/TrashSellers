﻿using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    
    public List<GameObject> itemPrefabs;
    
    public string catalogVersion = "main";
    public string currency = "CG";

    

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }



    public void InitObjects()
    {
        GetCatalogItemsRequest request = new GetCatalogItemsRequest();
        request.CatalogVersion = catalogVersion;

        PlayFabClientAPI.GetCatalogItems(request,
            result => {
                List<CatalogItem> items = result.Catalog;              
                foreach (var item in items)
                {
                    var prefab = itemPrefabs.Find(x => x.name.Equals(item.ItemId))?.GetComponent<Item>();
                    prefab.cost = (int)item.VirtualCurrencyPrices[currency];
                    prefab.description = item.Description;
                }

            },
            error => {
                print(error.ErrorMessage);
            });
    }

    public Object GetObject(string name)
    {
        return itemPrefabs.Find(x => x.name.Equals(name)).GetComponent<Object>();
    }

}
