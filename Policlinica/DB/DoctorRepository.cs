using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace Policlinica.DB;

public class DoctorRepository
{
    MySqlConnection connection;

    public DoctorRepository(IOptions<DatabaseConnection> connect)
    {
        connection = new MySqlConnection(connect.Value.ConnectionString);
    }
    public List<Doctors> GetDoctorsByTest()
    {
        List<Doctors> result = new List<Doctors>();
        string sql = "select  * from doctors";
        try
        {
            connection.Open();
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    result.Add(new Doctors
                    {
                        Id = dr.GetInt32("id"),
                        Title = dr.GetString("title"),
                        Description = dr.GetString("description"),
                       
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
    
    
