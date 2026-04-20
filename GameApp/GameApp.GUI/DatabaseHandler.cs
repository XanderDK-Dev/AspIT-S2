using Microsoft.Data.SqlClient;

namespace GameApp.GUI;

class DatabaseHandler
{
    private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";



    public List<Game> GetGames()
    {
        List<Game> games = new();
        SqlConnection connection = new(connectionString);
        string sql = "SELECT Name, Description, [Release Date], Developer, Publisher, [Age reason1], [Age reason2], [Age reason3] FROM GameInfo;";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        Game game = new();
        while (reader.Read())
        {
            string name = (string)reader["Name"];
            string description = (string)reader["Description"];
            DateTime releasedate = (DateTime)reader["Release Date"];
            string developer = (string)reader["Developer"];
            string publisher = (string)reader["Publisher"];
            string agereason1 = (string)reader["Age reason1"];
            string agereason2 = (string)reader["Age reason2"];
            string agereason3 = (string)reader["Age reason3"] ?;

            game = new()
            {
                Name = name,
                Description = description,
                ReleaseDate = releasedate,
                Developer = developer,
                Publisher = publisher,
                AgeReason1 = agereason1,
                AgeReason2 = agereason2,
                AgeReason3 = agereason3
            };

            games.Add(game);
        }
        return games;
    }
}
