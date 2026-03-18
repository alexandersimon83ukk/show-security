using System.Data.SqlClient;

namespace ShowSecurity.Samples;

public class UserRepository
{
    public void GetUserDetails(string userInputUsername)
    {
        string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // CODEQL FINDING HERE:
            // The variable 'userInputUsername' flows directly into the SQL query string.
            string query = "SELECT * FROM Users WHERE Username = '" + userInputUsername + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // ... process results ...
            }
        }
    }
}
