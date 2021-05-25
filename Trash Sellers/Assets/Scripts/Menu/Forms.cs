﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Forms : MonoBehaviour
{
    DataBaseConnector db;

    bool SignUp = false;
    bool SignIn = false;

    bool remember = false;

    public GameObject signUp;
    public GameObject signIn;

    public GameObject loginUp;
    public GameObject loginIn;
    public GameObject passwordIn;
    public GameObject passwordUp;
    public GameObject passwordUp2;
    public GameObject emailUp;


    private string login = "";
    private string password;
    private string password2;
    private string email;   
 

    public void SignUpButton()
    {
        login = loginUp.GetComponent<TMP_InputField>().text;
        password = passwordUp.GetComponent<TMP_InputField>().text;
        password2 = passwordUp2.GetComponent<TMP_InputField>().text;
        email = emailUp.GetComponent<TMP_InputField>().text;



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
        login = loginIn.GetComponent<TMP_InputField>().text;
        password = passwordIn.GetComponent<TMP_InputField>().text;

        if (!db.LoginExist(login))
        {
            print("There is no account with this login");
            return;
        }

        db.SignIn(login, password);
    }


    void FixedUpdate()
    {
        signIn.SetActive(SignIn);
        signUp.SetActive(SignUp);
    }

    private void Start()
    {
        db = GetComponent<DataBaseConnector>();
    }

    public void In()
    {
        SignIn = true;
        SignUp = false;
    }

    public void Up()
    {
        SignUp = true;
        SignIn = false;
    }
}
