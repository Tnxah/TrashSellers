using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager
{
    public static void Register(string username, string email, string password, out string message)
    {
        var request = new RegisterPlayFabUserRequest();
        request.Username = username;
        request.Email = email;
        request.Password = password;

        var status = "SuccesS";

        PlayFabClientAPI.RegisterPlayFabUser(request, result =>
        {

        }, error => 
        {
            status = error.ErrorMessage;
            Debug.Log(error.ErrorMessage);
        });

        message = status;
    }
    public static void Login(string email, string password, out string message)
    {
        var request = new LoginWithEmailAddressRequest();
        request.Email = email;
        request.Password = password;

        var statusMessage = "SuccesS";

        PlayFabClientAPI.LoginWithEmailAddress(request, result => {
            //Shop.instance.UpdateCatalogItems();

            PlayfabStatisticsManager.LoadStatistics();
            //JobManager.Init();

            SceneMangementService.LoadGameScene();
        }, error => {
            statusMessage = error.ErrorMessage;
            Debug.Log(error.ErrorMessage);
        });

        message = statusMessage; 
    }

    public static void ResetPassword(string email, out string message)
    {
        var request = new SendAccountRecoveryEmailRequest();
        request.Email = email;
        request.TitleId = "67F9D";

        var statusMessage = "Password reset mail senT";

        PlayFabClientAPI.SendAccountRecoveryEmail(request, result => { }, error => { });



        message = statusMessage;
        
    }

}
