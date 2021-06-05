using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using TMPro;

public class RegLog : MonoBehaviour
{

    public TextMeshProUGUI statusField;

    public void Register(string login, string email, string password)
    {
        if (password.Length < 6)
        {
            print("Password must have at least 6 chars");
            statusField.text = ("password must have at least 6 chars");
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Username = login,
            Password = password
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);




    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        print("Registration successed");
        statusField.text = "registration successed";
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        print("registration error");
        statusField.text = ("registration error");
    }

}

