using Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class Repository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookingSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

        public List<Bookings> GetBookings()
        {
            List<Bookings> bookings = new();
            SqlConnection connection = new(connectionString);
            string sql = "Select * FROM Bookings";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                DateTime startdate = (DateTime)reader["StartDate"];
                DateTime enddate = (DateTime)reader["EndDate"];
                int pitchid = (int)reader["PitchId"];
                int bookerid = (int)reader["BookerId"];

                Bookings booking = new Bookings()
                {
                    Id = id,
                    StartDate = startdate,
                    EndDate = enddate,
                    PitchId = pitchid,
                    BookerId = bookerid
                };

                bookings.Add(booking);
            }

            return bookings;
        }

        public void MakeBooking(Bookings bookings)
        {
            SqlConnection connection = new(connectionString);
            //string sql = $"INSERT INTO Bookings (StartDate, EndDate, PitchId, BookerId) VALUES ('{bookings.StartDate}', '{bookings.EndDate}', '{bookings.PitchId}', '{bookings.BookerId}');";
            string sql = $"INSERT INTO Bookings (StartDate, EndDate, PitchId, BookerId) VALUES (@StartDate, @EndDate, @PitchId, @BookerId);";
            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@StartDate", bookings.StartDate);
            command.Parameters.AddWithValue("@EndDate", bookings.EndDate);
            command.Parameters.AddWithValue("@PitchId", bookings.PitchId);
            command.Parameters.AddWithValue("@BookerId", bookings.BookerId);
            connection.Open();
            command.ExecuteNonQuery();
        }



        public List<Pitches> GetPitches()
        {
            List<Pitches> Pitches = new();
            SqlConnection connection = new(connectionString);
            string sql = "Select * FROM Pitches";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                int number = (int)reader["Number"];

                Pitches pitch = new Pitches()
                {
                    Id = id,
                    Number = number
                };

                Pitches.Add(pitch);
            }

            return Pitches;
        }

        public void MakePitch(Pitches pitches)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"INSERT INTO Pitches (Number) VALUES ('{pitches.Number}');";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Booker> GetBooker()
        {
            List<Booker> booker = new();
            SqlConnection connection = new(connectionString);
            string sql = "Select * FROM Booker";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string name = (string)reader["Name"];
                string mail = (string)reader["Mail"];

                Booker book = new Booker()
                {
                    Id = id,
                    Name = name,
                    Mail = mail
                };

                booker.Add(book);
            }

            return booker;
        }

        public void MakeBooker(Booker booker)
        {
            SqlConnection connection = new(connectionString);
            string sql = $"INSERT INTO Booker (Name, Mail) VALUES ('{booker.Name}', '{booker.Mail}');";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
