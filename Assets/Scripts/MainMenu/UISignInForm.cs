using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISignInForm : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField password;

    public GameObject panel;

    private string message;

    public void RegistrationPanel()
    {
        var signUpForm = UIManager.instance.signUpForm;

        panel.SetActive(false);

        signUpForm.panel.SetActive(true);
        signUpForm.PasteCredentials(email.text, password.text);
    }

    public void ResetPassword()
    {
        AccountManager.ResetPassword(email.text, out message);
    }

    public void SignIn()
    {
        AccountManager.Login(email.text, password.text, out message);
    }

    public void PasteCredentials(string email, string password)
    {
        this.email.text = email;
        this.password.text = password;
    }
}
