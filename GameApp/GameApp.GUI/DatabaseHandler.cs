using Microsoft.Data.SqlClient;
using System.Windows.Controls.Primitives;

namespace GameApp.GUI;

class DatabaseHandler
{
    private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";



    public List<Game> GetGames()
    {
        List<Game> games = new();
        using SqlConnection connection = new(connectionString);
        string sql = "SELECT Name, Description, [Release Date], Developer, Publisher, [Age Rating], [Age reason1], [Age reason2], [Age reason3], [Main Img], Img1, Img2, Img3, Img4, Img5, Img6 FROM GameInfo;";
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
            // Read the varbinary(MAX) as a byte array
            byte[] mainImgBytes = reader["Main Img"] as byte[];
            byte[] Img1Bytes = reader["Img1"] as byte[];
            byte[] Img2Bytes = reader["Img2"] as byte[];
            byte[] Img3Bytes = reader["Img3"] as byte[];
            byte[] Img4Bytes = reader["Img4"] as byte[];
            byte[] Img5Bytes = reader["Img5"] as byte[];
            byte[] Img6Bytes = reader["Img6"] as byte[];

            // Convert it to a hex string for your Game object, checking for nulls 
            string mainimg = mainImgBytes != null ? Convert.ToHexString(mainImgBytes) : "";
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
                AgeReason3 = agereason3,
                MainImg = mainimg,
                img1 = Img1Bytes != null ? Convert.ToHexString(Img1Bytes) : "",
                img2 = Img2Bytes != null ? Convert.ToHexString(Img2Bytes) : "",
                img3 = Img3Bytes != null ? Convert.ToHexString(Img3Bytes) : "",
                img4 = Img4Bytes != null ? Convert.ToHexString(Img4Bytes) : "",
                img5 = Img5Bytes != null ? Convert.ToHexString(Img5Bytes) : "",
                img6 = Img6Bytes != null ? Convert.ToHexString(Img6Bytes) : "",
            };

            games.Add(game);
        }
        return games;
    }

    public void MakeGame(Game games)
    {
        SqlConnection connection = new(connectionString);
        //VERIFY @ LOCATIONS
        string sql = $"INSERT INTO GameInfo (Name, Description, [Release Date], Developer, Publisher, [Age Rating], [Age reason1], [Age reason2], [Age reason3], [Main Img], Img1, Img2, Img3, Img4, Img5, Img6) VALUES (@Name, @Description, [@Release Date], @Developer, @Publisher, [@Age Rating], [@Age reason1], [@Age reason2], [@Age reason3], [@Main Img], @Img1, @Img2, @Img3, @Img4, @Img5, @Img6);";
        using SqlCommand command = new(sql, connection);
        command.Parameters.AddWithValue("@Name", games.Name);
        command.Parameters.AddWithValue("@Description", games.Description);
        command.Parameters.AddWithValue("@Release Date", games.ReleaseDate);
        command.Parameters.AddWithValue("@Publisher", games.Publisher);
        command.Parameters.AddWithValue("@Developer", games.Developer);
        command.Parameters.AddWithValue("@Age Rating", games.AgeRating);
        command.Parameters.AddWithValue("@Age reason1", games.AgeReason1);
        command.Parameters.AddWithValue("@Age reason2", games.AgeReason2);
        command.Parameters.AddWithValue("@Age reason3", games.AgeReason3);
        command.Parameters.AddWithValue("@Main Img", games.MainImg);
        command.Parameters.AddWithValue("@Img1", games.img1);
        command.Parameters.AddWithValue("@Img2", games.img2);
        command.Parameters.AddWithValue("@Img3", games.img3);
        command.Parameters.AddWithValue("@Img4", games.img4);
        command.Parameters.AddWithValue("@Img5", games.img5);
        command.Parameters.AddWithValue("@Img6", games.img6);
        connection.Open();
        command.ExecuteNonQuery();
    }
}

//UPDATE GameInfo
//SET[img2] = (SELECT BulkColumn
//                   FROM OPENROWSET(BULK N'C:\Users\70835\Downloads\ss_408190ffc2160a8e0786ac5118ddc1f94b5b9b6a.600x338 (1).jpg', SINGLE_BLOB) AS ImageSource)
//WHERE ID = 4
