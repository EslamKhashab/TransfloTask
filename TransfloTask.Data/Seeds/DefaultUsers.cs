using System.Data.SqlClient;
using TransfloTask.Data.Entites;

namespace TransfloTask.Data.Seeds
{
    public static class DefaultUsers
    {
        private static List<string> names = new List<string> {"Emma", "Liam", "Olivia", "Noah", "Ava", "William", "Sophia", "James", "Isabella", "Oliver",
                                                           "Charlotte", "Benjamin", "Amelia", "Elijah", "Mia", "Lucas", "Harper", "Mason", "Evelyn",
                                                           "Logan", "Abigail", "Alexander", "Emily", "Ethan", "Ella", "Jacob", "Elizabeth", "Michael",
                                                           "Camila", "Daniel", "Luna", "Henry", "Sofia", "Jackson", "Avery", "Sebastian", "Mila",
                                                           "Aiden", "Aria", "Matthew", "Scarlett", "Samuel", "Victoria", "David", "Madison", "Joseph",
                                                           "Chloe", "Carter", "Grace", "Owen", "Penelope", "Wyatt", "Riley", "John", "Aubrey",
                                                           "Jack", "Zoey", "Luke", "Lily", "Jayden", "Hannah", "Dylan", "Lillian", "Grayson",
                                                           "Natalie", "Levi", "Addison", "Isaac", "Eleanor", "Gabriel", "Audrey", "Julian", "Ellie",
                                                           "Anthony", "Stella", "Jaxon", "Paisley", "Lincoln", "Nova", "Joshua", "Brooklyn", "Christopher",
                                                           "Everly", "Andrew", "Isabelle", "Theodore", "Genesis", "Caleb", "Emilia", "Ryan", "Emilie",
                                                           "Asher", "Valentina", "Nathan", "Willow", "Thomas", "Caroline", "Leo", "Naomi", "Isaiah",
                                                           "Aaliyah", "Charles", "Ariana" };
        private static Random random = new Random();
        public static void Initialize(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drivers", connection);
                connection.Open();
                string createTableCommand = "IF NOT EXISTS (SELECT * FROM sys.tables t JOIN sys.schemas s ON (t.schema_id = s.schema_id)  WHERE s.name = 'dbo' AND t.name = 't1') CREATE TABLE dbo.Drivers (Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,FirstName varchar(50),LastName VARCHAR(50),Email VARCHAR(50),PhoneNumber VARCHAR(50));";
                string checkTableCommand = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Drivers';";
                using (SqlCommand command = new SqlCommand(checkTableCommand, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        using (SqlCommand createCommand = new SqlCommand(createTableCommand, connection))
                        {
                            createCommand.ExecuteNonQuery();
                        }
                    }

                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    connection.Close();
                    List<Driver> drivers = new List<Driver>();
                    for (int i = 0; i < 100; i++)
                    {

                        string firstName = RandomString(random, 5, 10);
                        string lastName = RandomString(random, 5, 10);
                        string email = $"{firstName}.{lastName}{random.Next(1000, 9999)}@example.com";
                        string phoneNumber = $"({random.Next(100, 999)}) {random.Next(100, 999)}-{random.Next(1000, 9999)}";
                        drivers.Add(new Driver
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            PhoneNumber = phoneNumber
                        });
                    }
                    connection.Open();

                    foreach (Driver driver in drivers)
                    {
                        string sql = "INSERT INTO Drivers (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            command.Parameters.AddWithValue("@FirstName", driver.FirstName);
                            command.Parameters.AddWithValue("@LastName", driver.LastName);
                            command.Parameters.AddWithValue("@Email", driver.Email);
                            command.Parameters.AddWithValue("@PhoneNumber", driver.PhoneNumber);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static string RandomString(Random random, int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength + 1);
            return names[length];
        }
    }
}