using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forms : MonoBehaviour
{
    DataBaseConnector db;

    bool SignUp = true;
    bool SignIn = false;

    bool remember = false;

    public GameObject signUp;
    public GameObject signIn;

    public InputField loginUp;
    public InputField loginIn;
    public InputField passwordIn;
    public InputField passwordUp;
    public InputField passwordUp2;
    public InputField emailUp;


    private string login;
    private string password;
    private string password2;
    private string email;   
 

    public void SignUpButton()
    {
        login = loginUp.text;
        password = passwordUp.text;
        password2 = passwordUp2.text;
        email = emailUp.text;



        if (db.LoginExist(login))
        {
            print("Account with this login already exists");
            return;
        }
        if (db.EmailExist(email))
        {
            print("Account with this email already exists");
            return;
        }
        if (!password.Equals(password2))
        {
            print("Passwords doesn't match");
            return;
        }

        db.SignUp(login, password, email);

        SignUp = false;
        SignIn = true;

    }
    public void SignInButton()
    {
        login = loginIn.text;
        password = passwordIn.text;

        if (!db.LoginExist(login))
        {
            print("There is no account with this login");
            return;
        }

        db.SignIn(login, password);
    }


    void FixedUpdate()
    {
        signIn.active = SignIn;
        signUp.active = SignUp;





    }
}
