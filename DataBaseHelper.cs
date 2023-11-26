using MySql.Data.MySqlClient;
using CheatChat.Models;
using Microsoft.Extensions.Configuration;

public class DatabaseHelper
{
    private readonly IConfiguration configuration;

    public DatabaseHelper(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public MySqlConnection GetConnection()
    {
        string server = /*configuration["mysqlConnection:server"]*/"localhost";
        string database = /*configuration["mysqlConnection:database"]*/"CheatChat";
        string user = /*configuration["mysqlConnection:user"]*/"root";
        string password = /*configuration["mysqlConnection:password"]*/"admin123";

        string connectionString = $"Server={server};Database={database};User Id={user};Password={password};";

        MySqlConnection connection = new MySqlConnection(connectionString);

        return connection;
    }
    public UserModel? logIn(string email, string password)
    {
        using (MySqlConnection connection = GetConnection())
        {
            connection.Open();

            string query = $"SELECT * FROM Users WHERE Email = '{email}'";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read() && reader is not null)
                    {
                        if (!password.Equals(reader["password"]))
                        {
                            return null;
                        }
                        UserModel result = new UserModel
                        {
                            phone_number = reader["phone_number"].ToString(),
                            first_name   = reader["first_name"].ToString(),
                            last_name    = reader["last_name"].ToString(),
                            email        = reader["email"].ToString(),

                            // Map other properties as needed
                        };
                        return result;
                    }
                }
            }
        }

        return null;
    }

}