using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    private Dictionary<string, int> inventory;
    private string _id { get; set; }
    private string login { get; set; }
    private string password { get; set; }
    private string email { get; set; }


    private int level { get; set; }

    private int experience { get; set; }

    public void Fill(string id, string login, string password)
    {
        this._id = id;
        this.login = login;
        this.password = password;
        
    }

    public void FillInventory(string inventory)
    {
        string[] arr = inventory.Split('\n');
        foreach (string s in arr)
        {
            
        }
    }


}
