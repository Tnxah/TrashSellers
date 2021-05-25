using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseConnector : MonoBehaviour
{
    private string ConnectionString;

    private string dbName = "slpunjts_unity";
    private string dbUsername = "slpunjts_tnxah";
    private string dbPassword = "RM6x84SZkPKG33L";
    private string dbServer = "185.253.217.35";
    private string dbPort = "3311";

    Account account; 

    MySqlConnection conn;

    MySqlDataReader reader;

    private void Awake()
    {
        ConnectionString = string.Format("server={0};port={1};uid={2};pwd={3};database={4}",
            dbServer,
            dbPort,
            dbUsername,
            dbPassword,
            dbName
            );
    }

    void Start()
    {
        conn = new MySqlConnection(ConnectionString);

        conn.Open();

        account = new Account();
    }

    public void Select(string request)
    {

        MySqlCommand cmd = new MySqlCommand(request, conn);
        reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                print(reader.GetString(0));
                print(reader.GetString(1));
                print(reader.GetString(2));
            }
        }


    }

    public void SignUp(string login, string password, string email)
    {
        string signupform = "INSERT INTO Account (Login, Password, Email) VALUES ('" + login +"', '"+ password +"', '"+ email + "');";

        MySqlCommand cmd = new MySqlCommand(signupform, conn);
        reader = cmd.ExecuteReader();

        print("Account created");
        reader.Close();
    }

    public void SignIn(string login, string password)
    {
        string signupform = "SELECT _id FROM Account WHERE Login = '" + login + "' AND Password = '" + password + "'";
        string accountId;

        MySqlCommand cmd = new MySqlCommand(signupform, conn);
        reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            print("Logged in");
            reader.Read();
            accountId = reader.GetString(0);
            print(accountId);
        }
        
        reader.Close();
    }

    void Update()
    {
        
    }

    public bool LoginExist(string login)
    {
        string query = "SELECT * FROM Account WHERE Login='" + login + "'";

        MySqlCommand cmd = new MySqlCommand(query, conn);
        reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (reader.GetString(1).Equals(login))
                {
                    reader.Close();
                    return true;
                }
            }
        }
        reader.Close();
        return false;
    }
    public bool EmailExist(string email)
    {
        string query = "SELECT * FROM Account WHERE Email='" + email + "'";

        MySqlCommand cmd = new MySqlCommand(query, conn);
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (reader.GetString(3).Equals(email))
                {
                    reader.Close();
                    return true;
                }
            }
        }
        reader.Close();
        return false;
    }
}
