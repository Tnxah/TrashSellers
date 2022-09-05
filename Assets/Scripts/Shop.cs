using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

    }

    public void UpdateCatalogItems()
    {
        ItemManager.instance.InitObjects();
    }
}
