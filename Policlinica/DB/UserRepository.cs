using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace Policlinica.DB;

public class UserRepository
{
    MySqlConnection connection;

    public UserRepository(IOptions<DatabaseConnection> connect)
    {
        connection = new MySqlConnection(connect.Value.ConnectionString);
    }


    public void InsertUser(Users users)
    {
        var sql1 = "INSERT INTO Polyclinica.users (id, name, password) VALUES (0, @name, @password); ";
        var sql2 = "SELECT max(id) as id FROM Polyclinica.users;";

    }


    public List<Users> GetUsersByTest()
    {
        List<Users> result = new List<Users>();
        string sql = "select  * from users";
        try
        {
            connection.Open();
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new Users
                    {
                        Id = dr.GetInt32("id"),
                        Name = dr.GetString("name"),
                        Password = dr.GetString("password"),
                       
                    });
                }
            }

            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return result;
    }
}