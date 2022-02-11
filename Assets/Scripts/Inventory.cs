using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField]
    private int inventorySize;

    public List<Object> inventory;

    public delegate void OnInventoryChanged(string name);
    public OnInventoryChanged onInventoryChangedCallback;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }

        InitializeInventory();
    }

    private void InitializeInventory()
    {
        if (inventory == null)
        {
            inventory = new List<Object>();
        }
    } 

    private void ExpandInventory(int newSize)
    {
        this.inventorySize = newSize;
    }

    public void Add(Object obj)
    {
        if (inventory.Count >= inventorySize)
        {
            return;
        }

        inventory.Add(obj);
        
        
        onInventoryChangedCallback.Invoke(obj.name);
        //Destroy(obj.gameObject);
        obj.gameObject.SetActive(false);
    }

    public void Remove(string name)
    {
        if (inventory.Count <= 0)
        {
           // return;
        }
        print("Remove " + inventory.Find(x => x.name.Equals(name)));
        inventory.Remove(inventory.Find(x => x.name.Equals(name)));

        onInventoryChangedCallback.Invoke(name);
    }
}
