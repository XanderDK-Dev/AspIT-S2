using Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new();
            SqlConnection connection = new(connectionString);
            string sql = "SELECT FirstName, LastName FROM Employees;";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee employee = new();
            while (reader.Read())
            {
                //int employeeid = (int)reader["EmployeeID"];
                string firstname = (string)reader["FirstName"];
                string lastname = (string)reader["LastName"];
                employee = new()
                {
                    //Id = employeeid,
                    Firstname = firstname,
                    Lastname = lastname
                };

                employees.Add(employee);
            }
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"UPDATE Employees SET FirstName = '{employee.Firstname}', LastName = '{employee.Lastname}' WHERE EmployeeID = {employee.Id};";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
