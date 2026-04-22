using Microsoft.Data.SqlClient;

namespace GameApp.GUI;

class DatabaseHandler
{
    private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";



    public List<Game> GetGames()
    {
        List<Game> games = new();
        using SqlConnection connection = new(connectionString);
        string sql = "SELECT Name, Description, [Release Date], Developer, Publisher, [Age Rating], [Age reason1], [Age reason2], [Age reason3] FROM GameInfo;";
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        Game game = new();
        while (reader.Read())
        {
            string name = reader["Name"] as string;
            string description = reader["Description"] as string;
            DateTime releasedate = (DateTime)reader["Release Date"];
            string developer = reader["Developer"] as string;
            string publisher = reader["Publisher"] as string;
            int agerating = (int)reader["Age Rating"];
            string agereason1 = reader["Age reason1"] as string;
            string agereason2 = reader["Age reason2"] as string;
            string agereason3 = reader["Age reason3"] as string;
            game = new()
            {
                Name = name,
                Description = description,
                ReleaseDate = releasedate,
                Developer = developer,
                Publisher = publisher,
                AgeRating = agerating,
                AgeReason1 = agereason1,
                AgeReason2 = agereason2,
                AgeReason3 = agereason3
            };

            games.Add(game);
        }
        return games;
    }
}
