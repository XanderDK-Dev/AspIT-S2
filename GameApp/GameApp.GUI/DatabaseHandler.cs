using Microsoft.Data.SqlClient;

namespace GameApp.GUI;

class DatabaseHandler
{
    private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

    public List<Game> GetGames()
    {
        List<Game> games = new();
        SqlConnection connection = new(connectionString);
        string sql = "SELECT Name, Description FROM GameInfo;";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        Game game = new();
        while (reader.Read())
        {
            string name = (string)reader["Name"];
            string description = (string)reader["Description"];
            game = new()
            {
                Name = name,
                Description = description
            };

            games.Add(game);
        }
        return games;
    }
}
