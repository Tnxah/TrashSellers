using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using TMPro;
using System;

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
            //Username = login,
            Password = password,
            RequireBothUsernameAndEmail = false
            
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
        print("registration error: " + error);
        statusField.text = ("registration error");
    }

    public void Login(string email, string password)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);

    }

    private void OnLoginSuccess(LoginResult result)
    {
        print("successful login");
        statusField.text = "successful login";

    }

    private void OnLoginFailure(PlayFabError error)
    {
        print("login failed");
        statusField.text = "login failed";
    }

    public void ResetPassword(string email)
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email,
            TitleId = "67F9D"
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnResetSuccess, OnResetFailure);
    }

    private void OnResetFailure(PlayFabError error)
    {
        print(error);
        statusField.text = "reset failure";
    }

    private void OnResetSuccess(SendAccountRecoveryEmailResult result)
    {
        print(result);
        statusField.text = "succesful reset";
    }
}

