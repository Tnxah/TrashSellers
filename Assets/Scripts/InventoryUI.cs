using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private int lastInventorySize = 0;
    private Dictionary<string, InventorySlot> inventorySlots = new Dictionary<string, InventorySlot>();

    public List<GameObject> UISlots = new List<GameObject>();

    private List<Object> inventory;

    public GameObject inventoryPanel;
   

    void Start()
    {
        Inventory.instance.onInventoryChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    private void UpdateUI()
    {
        print("Update UI");
        if (lastInventorySize > Inventory.instance.inventory.Count)
        {
            //Decrease

        }

        inventory = Inventory.instance.inventory;

        for (int i = lastInventorySize; i < inventory.Count; i++)
        {
            if (!inventorySlots.ContainsKey(inventory[i].name))
            {
                var slot = GetFreeSlot().GetComponent<InventorySlot>();
                slot.Add(inventory[i]);

                inventorySlots.Add(inventory[i].name, slot);
                slot.gameObject.SetActive(true);
            }
            else
            {
                inventorySlots[inventory[i].name].Increase();
            }
        }
        lastInventorySize = inventory.Count;
    }

    private GameObject GetFreeSlot()
    {
        foreach (var slot in UISlots)
        {
            if (!slot.activeSelf)
            {
                return slot;
            }
        }
        return null;
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
    }
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }
}
