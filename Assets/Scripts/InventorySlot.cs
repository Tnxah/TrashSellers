using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image icon;
    private string objectName;
    private int number;

    //UIside

    public TextMeshProUGUI slotName;
    public TextMeshProUGUI objectsNumber;

    public void Add(Object obj, int number = 1)
    {
        //icon;
        this.objectName = obj.name;
        this.number = number;

        UpdateSlot();
    }

    public void Increase(int num = 1)
    {
        number += num;

        UpdateSlot();
    }

    public void Decrease(int num = 1)
    {
        number -= num;
        if (number <= 0)
        {
            Delete();
        }
    }

    public void Delete()
    {
        //Delete/Clear slot
    }

    private void UpdateSlot()
    {
        slotName.text = objectName;
        objectsNumber.text = number.ToString();
    }
}
