using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLogin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest
        {
            CustomId = "testOnAndroid",
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

       

        
    }
    private void OnLoginSuccess(LoginResult result)
    {
        print("Success");
    }

    private void OnLoginFailure(PlayFabError error)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
