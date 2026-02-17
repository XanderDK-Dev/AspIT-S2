using Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        
        public List<Employee> GetAllEmployees() 
        {
            List<Employee> employees = new();
            SqlConnection connection = new(connectionString);
            string sql = "SELECT EmployeeID, FirstName, LastName FROM Employees";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["EmployeeID"];
                string firstname = (string)reader["FirstName"];
                string lastname = (string)reader["LastName"];

                Employee employee = new()
                {
                    Id = id,
                    Firstname = firstname,
                    Lastname = lastname,
                };

                employees.Add(employee);
            }

            return employees;
        }
    }
}
