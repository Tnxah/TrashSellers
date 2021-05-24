using MySqlConnector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private string ConnectionString;

    private string dbName = "slpunjts_unity";
    private string dbUsername = "slpunjts_tnxah";
    private string dbPassword = "RM6x84SZkPKG33L";
    private string dbServer = "185.253.217.35";
    private string dbPort = "3311";

    Account account;

    MySqlConnection conn;

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



        Select("Select * from Item");

      account = new Account();  
      
    }

    public void Select(string request)
    {

        MySqlCommand cmd = new MySqlCommand(request, conn);
        MySqlDataReader reader = cmd.ExecuteReader();

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
    
    void Update()
    {
        
    }
}
