using Entities;
using Microsoft.Data.SqlClient;
using System;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        public void DeleteEmployee(int id)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"DELETE FROM Employees WHERE EmployeeID = {id};";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Employee FindEmployeeBy(int id)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"SELECT EmployeeID, FirstName, LastName FROM Employees WHERE EmployeeID = {id};";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee employee = new();
            while (reader.Read())
            {
                int employeeid = (int)reader["EmployeeID"];
                string firstname = (string)reader["FirstName"];
                string lastname = (string)reader["LastName"];
                employee = new()
                {
                    Id = employeeid,
                    Firstname = firstname,
                    Lastname = lastname,
                };
            }
            return employee;
        }

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

        public void Insert(Employee employee)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"INSERT INTO Employees (FirstName, LastName) VALUES ('{employee.Firstname}', '{employee.Lastname}');";
            SqlCommand command = new SqlCommand (sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Employee employee)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"UPDATE Employees SET FirstName = '{employee.Firstname}', LastName = '{employee.Lastname}' WHERE EmployeeID = {employee.Id};";
            SqlCommand command = new SqlCommand (sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
