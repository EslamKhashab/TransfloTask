using System.Data.SqlClient;
using TransfloTask.Data.Entites;
namespace TransfloTask.Data.Repositories
{
    public class DriverRepository: IDriverRepository
    {
        private readonly string connectionString = "Server=.;Initial Catalog=TransfloDB;trusted_connection=true;";

        public IEnumerable<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drivers", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new Driver
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"]
                    });
                }
            }
            return drivers;
        }

        public Driver GetDriverById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drivers WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Driver
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"]
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public void InsertDriver(Driver driver)
        {
            string cmd = "INSERT INTO Drivers (FirstName, LastName, Email, PhoneNumber) VALUES (@firstName, @lastName, @email, @phoneNumber)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmd, conn))
                {
                    command.Parameters.AddWithValue("@firstName", driver.FirstName);
                    command.Parameters.AddWithValue("@lastName", driver.LastName);
                    command.Parameters.AddWithValue("@email", driver.Email);
                    command.Parameters.AddWithValue("@phoneNumber", driver.PhoneNumber);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateDriver(Driver driver)
        {
            string cmd = "UPDATE Drivers SET FirstName = @firstName, LastName = @lastName, Email = @email, PhoneNumber = @phoneNumber WHERE Id = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmd, conn))
                {
                    command.Parameters.AddWithValue("@id", driver.Id);
                    command.Parameters.AddWithValue("@firstName", driver.FirstName);
                    command.Parameters.AddWithValue("@lastName", driver.LastName);
                    command.Parameters.AddWithValue("@email", driver.Email);
                    command.Parameters.AddWithValue("@phoneNumber", driver.PhoneNumber);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteDriver(int id)
        {
            string cmd = "DELETE FROM Drivers WHERE Id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(cmd, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}