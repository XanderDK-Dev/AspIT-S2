using Microsoft.Data.SqlClient;

namespace DemoDBConnection
{
    internal class Program
    {

        static string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniDB;Integrated Security=True;Connect Timeout=5;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        static void Main(string[] args)
        {
            var x = GetAllToDoItems();

        }

        static List<ToDoItem> GetAllToDoItems() 
        { 
            List<ToDoItem> items = new();

            string sql = "SELECT * FROM TodoItems";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) 
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string content = reader.GetString(1);

                ToDoItem todoItem = new()
                {
                    Id = id,
                    Title = title,
                    Content = content
                };
                items.Add(todoItem);
            }
            
            
            connection.Close();
            return items;
        }
    }
}
